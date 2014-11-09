namespace TeamUp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TeamUp.Web.Models;
    using AutoMapper.QueryableExtensions;
    using TeamUp.Data.Contracts;

    public class HomeController : BaseController
    {
        public HomeController(ITeamUpData data)
            : base(data)
        {

        }

        public ActionResult Index()
        {
            IEnumerable<GameViewModel> games = this.Data.Games.All()
                .Where(g => g.AvailableSpots > 0)
                .Where(g => g.StartDate > DateTime.Now)
                .OrderBy(g => g.StartDate)
                .ThenBy(g => g.StartHour)
                .AsQueryable()
                .Project()
                .To<GameViewModel>();

            return View(games);
        }
    }
}