namespace TeamUp.Web.Areas.Administration.Controllers
{
    using Kendo.Mvc.UI;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TeamUp.Web.Areas.Administration.Controllers.Base;
    using AutoMapper.QueryableExtensions;
    using TeamUp.Web.Areas.Administration.Models;
    using TeamUp.Data.Contracts;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using TeamUp.Models;
    using AutoMapper;
    using System.Data.Entity.Validation;
    using System.Text;

    public class FieldController : AdminController
    {
        public FieldController(ITeamUpData data)
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
            var fields =
                this.Data.Fields.All()
                .AsQueryable()
                .Project()
                .To<FieldViewModel>()
                .ToDataSourceResult(request);

            return this.Json(fields);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, FieldViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                Address address = new Address()
                {
                    City = model.City,
                    Neighbourhood = model.Neighbourhood,
                    Street = model.Street,
                    Number = model.StreetNumber,
                    MoreInfo = model.MoreInfo
                };

                this.Data.Addresses.Add(address);

                model.Address = address;
                Field dbModel = new Field();
                Mapper.CreateMap<FieldViewModel, Field>();
                Mapper.Map(model, dbModel);

                //if (dbModel.Img == null)
                //{
                //    dbModel.Img = "Content\\Images\\Fields\\default.jpg";
                //}

                this.Data.Fields.Add(dbModel);
                this.Data.SaveChanges();
                model.Id = dbModel.Id;
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, FieldViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                int id = model.Id;
                Field dbModel = this.Data.Fields.Find(id);
                var img = dbModel.Img;
                Mapper.CreateMap<FieldViewModel, Field>();
                Mapper.Map(model, dbModel);
                dbModel.Img = img;

                this.Data.Fields.Update(dbModel);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, FieldViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var field = this.Data.Fields.Find(model.Id);
                this.Data.Fields.Delete(field);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Image(int id)
        {
            var image = this.Data.Images.Find(id);

            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }

            return File(image.Content, "image/" + image.FileExtension);
        }
    }
}