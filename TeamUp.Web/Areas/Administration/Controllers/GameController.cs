namespace TeamUp.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;


    using TeamUp.Data;
    using TeamUp.Web.Areas.Administration.Controllers.Base;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using TeamUp.Models;
    using System.Collections;
    using TeamUp.Data.Contracts;
    using System.Collections.Generic;
    using TeamUp.Web.Areas.Administration.Models;
    using System.Linq;
    using System;
    using Microsoft.AspNet.Identity;

    public class GameController : AdminController
    {
        public GameController(ITeamUpData data)
            : base(data)
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var games =
                this.Data.Games.All()
                .AsQueryable()
                .Project()
                .To<GameViewModel>()
                .ToDataSourceResult(request);

            return this.Json(games);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, GameViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                Field field = this.Data.Fields.SearchFor(f => f.Name == model.FieldName).FirstOrDefault();
                var userId = User.Identity.GetUserId();
                User currentUser = this.Data.Users.Find(userId);

                if (field == null)
                {
                    return View("Игрището не е намерено");
                }

                var game = new Game()
                {
                    StartDate = model.StartDate,
                    AvailableSpots = model.AvailableSpots,
                    HasReservetion = model.HasReservetion,
                    MinPlayers = model.MinPlayers,
                    MaxPlayers = model.MaxPlayers,
                    Price = model.Price,
                    Creator = currentUser,
                    Field = field
                };

                this.Data.Games.Add(game);
                this.Data.SaveChanges();
                model.Id = game.Id;
            }

            return Json(new[] { model}.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, GameViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                Game game = this.Data.Games.Find(model.Id.Value);
                game.StartDate = model.StartDate;
                game.AvailableSpots = model.AvailableSpots;
                game.HasReservetion = model.HasReservetion;
                game.MinPlayers = model.MinPlayers;
                game.MaxPlayers = model.MaxPlayers;
                game.Price = model.Price;

                this.Data.Games.Update(game);

                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, GameViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var game = this.Data.Games.Find(model.Id);
                this.Data.Games.Delete(game);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}