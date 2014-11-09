namespace TeamUp.Web.Controllers
{
    using AutoMapper.QueryableExtensions;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using TeamUp.Data.Contracts;
    using TeamUp.Web.Models;
    using System.Linq;

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