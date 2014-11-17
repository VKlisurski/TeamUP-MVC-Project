namespace TeamUp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using PagedList;
    using TeamUp.Data.Contracts;
    using TeamUp.Web.Models;
    using TeamUp.Web.Models.Fields;

    public class FieldController : BaseController
    {
        public FieldController(ITeamUpData data)
            : base(data)
        {

        }

        public ActionResult Index(string sortingOrder, int? page)
        {
            ViewBag.CurrentSortOrder = sortingOrder;
            int pageNumber = page ?? 1;

            IEnumerable<FieldViewModel> fields = this.Data.Fields.All()
               .AsQueryable()
               .Project()
               .To<FieldViewModel>();

            int itemsPerPage = 2;

            switch (sortingOrder)
            {
                case "Name":
                    fields = fields.OrderBy(g => g.Name);
                    break;
                case "City":
                    fields = fields.OrderBy(g => g.Address.City);
                    break;
                case "Neighbourhood":
                    fields = fields.OrderBy(g => g.Address.Neighbourhood);
                    break;
                default:
                    fields = fields.OrderBy(g => g.Name);
                    break;
            }

            return View(fields.ToPagedList(pageNumber, itemsPerPage));
        }

        [Authorize]
        [HttpGet]
        public ActionResult Add()
        {
            var fieldFielModel = new FieldAddModel();

            return View("~/Views/Field/Add.cshtml", fieldFielModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Add(FieldAddModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                //if (ValidateGameInput(model) == false)
                //{
                //    return RedirectToAction("Add", "Game");
                //}

                //var userId = User.Identity.GetUserId();
                //var user = this.Data.Users.Find(userId);
                //model.Creator = user;

                //Field field = this.Data.Fields.Find(model.FieldId);
                //model.Field = field;

                //var dbModel = new Game();
                //Mapper.CreateMap<GameAddViewModel, Game>();
                //Mapper.Map(model, dbModel);

                //this.Data.Games.Add(dbModel);
                //this.Data.SaveChanges();

                //SetTempData("Успешно добавихте мач");
                //return RedirectToAction("Index", "Home");
            }

            SetTempData("Невалиден мач");
            return View(model);
        }

        private void SetTempData(string message)
        {
            TempData["Meesage"] = message;
        }
    }
}