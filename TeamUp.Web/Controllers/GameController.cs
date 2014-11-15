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

    public class GameController : BaseController
    {
        public GameController(ITeamUpData data)
            : base(data)
        {
            
        }

        public ActionResult Apply(int id)
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var game = this.Data.Games.Find(id);
            GameDetailsViewModel gameDetails = Mapper.Map<GameDetailsViewModel>(game);

            return View("~/Views/Games/GameDetails.cshtml", gameDetails);
        }
    }
}