namespace TeamUp.Web.Controllers
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TeamUp.Data.Contracts;
    using TeamUp.Models;
    using TeamUp.Web.Models;
    using Microsoft.AspNet.Identity;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using PagedList;


    public class GameController : BaseController
    {
        public GameController(ITeamUpData data)
            : base(data)
        {

        }

        public ActionResult Index(string sortingOrder, int? page)
        {
            ViewBag.CurrentSortOrder = sortingOrder;

            int itemsPerPage = 2;
            int pageNumber = page ?? 1;

            IEnumerable<GameViewModel> games = this.Data.Games.All()
               .Where(g => g.AvailableSpots > 0)
               .AsQueryable()
               .Project()
               .To<GameViewModel>();

            var firstItemTodelete = games.FirstOrDefault();

            switch (sortingOrder)
            {
                case "Spots":
                    games = games.OrderBy(g => g.AvailableSpots);
                    break;
                case "Price":
                    games = games.OrderBy(g => g.Price);
                    break;
                case "Field":
                    games = games.OrderBy(g => g.Field.Name);
                    break;
                default:
                    games = games.OrderBy(g => g.StartDate).Where(gs => gs.StartDate > DateTime.Now);
                    break;
            }

            return View(games.ToPagedList(pageNumber, itemsPerPage));
        }

        [ChildActionOnly]
        public ActionResult Apply(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }

            return View();
        }

        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }

            return View();
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var game = this.Data.Games.Find(id);
                GameDetailsViewModel gameDetails = Mapper.Map<GameDetailsViewModel>(game);

                return View("~/Views/Game/GameDetails.cshtml", gameDetails);
            }

            return View();
        }
    }
}