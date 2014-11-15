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

            int pageNumber = page ?? 1;

            IEnumerable<GameViewModel> games = this.Data.Games.All()
               .Where(g => g.AvailableSpots > 0)
               .AsQueryable()
               .Project()
               .To<GameViewModel>();

            int itemsPerPage = 2;

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


        [Authorize]
        public ActionResult Apply(int id)
        {
            var game = this.Data.Games.Find(id);
            var user = this.Data.Users.Find(User.Identity.GetUserId());

            if (game.AppliedPlayers.Contains(user) || game.ApprovedPlayers.Contains(user) || game.Creator.Id == user.Id)
            {
                TempData["Message"] = "Вече ви има в списъците на мача";
            }
            else
            {
                TempData["Message"] = "Вие кандидатствахте успешно";
                game.AppliedPlayers.Add(user);
                this.Data.Games.Update(game);
                this.Data.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }


        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var game = this.Data.Games.Find(id);
            GameDetailsViewModel gameDetails = Mapper.Map<GameDetailsViewModel>(game);

            return View("~/Views/Game/GameDetails.cshtml", gameDetails);
        }
    }
}