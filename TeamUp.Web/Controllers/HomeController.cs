using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamUp.Models;
using TeamUp.Web.Models;

namespace TeamUp.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            IEnumerable<GameViewModel> games = this.Data.Games.All().Select(GameViewModel.FromGame).ToList();
            return View(games);
        }
    }
}