namespace TeamUp.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;
    using TeamUp.Data.Contracts;
    using TeamUp.Models;
    using TeamUp.Web.Areas.Administration.Controllers.Base;
    using TeamUp.Web.Areas.Administration.Models;
    using AutoMapper;

    public class GameController : AdminController
    {
        public GameController(ITeamUpData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            ViewBag.Fields = this.Data.Fields.All().ToList();
            return this.View();
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
                Field field = this.Data.Fields.SearchFor(f => f.Id == model.FieldId).FirstOrDefault();
                var userId = User.Identity.GetUserId();
                User currentUser = this.Data.Users.Find(userId);

                if (field == null)
                {
                    return this.View("Игрището не е намерено");
                }

                var dbModel = new Game();
                Mapper.CreateMap<GameViewModel, Game>();
                Mapper.Map(model, dbModel);

                dbModel.Creator = currentUser;
                dbModel.Field = field;

                //var game = new Game()
                //{
                //    StartDate = model.StartDate,
                //    AvailableSpots = model.AvailableSpots,
                //    HasReservetion = model.HasReservetion,
                //    MinPlayers = model.MinPlayers,
                //    MaxPlayers = model.MaxPlayers,
                //    Price = model.Price,
                //    Creator = currentUser,
                //    Field = field
                //};

                this.Data.Games.Add(dbModel);
                this.Data.SaveChanges();
                model.Id = dbModel.Id;
            }

            return Json(new[] { model}.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, GameViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var id = model.Id;
                Game game = this.Data.Games.Find(id);
                game.StartDate = model.StartDate;
                game.AvailableSpots = model.AvailableSpots;
                game.MinPlayers = model.MinPlayers;
                game.MaxPlayers = model.MaxPlayers;
                game.HasReservetion = model.HasReservetion;
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
                Game game = this.Data.Games.Find(model.Id);
                this.Data.Games.Delete(game);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}