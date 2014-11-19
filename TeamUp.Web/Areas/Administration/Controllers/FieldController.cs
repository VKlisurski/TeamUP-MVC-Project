namespace TeamUp.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using TeamUp.Data.Contracts;
    using TeamUp.Models;
    using TeamUp.Web.Areas.Administration.Controllers.Base;
    using TeamUp.Web.Areas.Administration.Models;

    public class FieldController : AdminController
    {
        public FieldController(ITeamUpData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
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