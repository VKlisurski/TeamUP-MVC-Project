namespace TeamUp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using TeamUp.Data.Contracts;
    using TeamUp.Web.Models;

    public class HomeController : BaseController
    {
        public HomeController(ITeamUpData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 1 * 60)]
        public ActionResult LoadLatestGames()
        {
            IEnumerable<GameViewModel> games = this.Data.Games.All()
                .Where(g => g.AvailableSpots > 0)
                .Where(g => g.StartDate > DateTime.Now)
                .OrderBy(g => g.StartDate)
                .Take(4)
                .AsQueryable()
                .Project()
                .To<GameViewModel>();

            return PartialView("~/Views/Game/_GamesHome.cshtml", games);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 10 * 60)]
        public ActionResult LoadTopFields()
        {
            IEnumerable<FieldViewModel> fields = this.Data.Fields.All()
                .OrderByDescending(f => f.GamesCount)
                .Take(4)
                .AsQueryable()
                .Project()
                .To<FieldViewModel>();

            return PartialView("~/Views/Field/_FieldsHome.cshtml", fields);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 5 * 60)]
        public ActionResult LoadTopUsers()
        {
            IEnumerable<UserViewModel> users = this.Data.Users.All()
            .Where(g => g.Votes.Count > 0)
            .OrderByDescending(g => g.Votes.Average(v => v.SkillsRating))
            .ThenByDescending(g => g.Votes.Average(v => v.TeamPlayerRating))
            .Take(4)
            .AsQueryable()
            .Project()
            .To<UserViewModel>();

            if (users.Count() > 0)
            {
                return PartialView("~/Views/Users/_UsersHome.cshtml", users);
            }
            else
            {
                return this.View();
            }
        }
    }
}