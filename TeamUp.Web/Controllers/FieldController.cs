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
    using TeamUp.Models;
    using System.IO;
    using System.Data.Entity.Validation;

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

                var addres = this.Data.Addresses.All().Where(a => a.Street == model.Street).FirstOrDefault();
                if (addres == null)
                {
                    addres = new Address
                    {
                        City = model.City,
                        Neighbourhood = model.Neighbourhood,
                        Street = model.Street,
                        Number = model.Number
                    };
                    this.Data.Addresses.Add(addres);
                    this.Data.SaveChanges();
                }

                model.Address = addres;

                var dbModel = new Field();
                Mapper.CreateMap<FieldAddModel, Field>();
                Mapper.Map(model, dbModel);

                if (model.UploadedImage != null)
                {
                    using (var memory = new MemoryStream())
                    {
                        model.UploadedImage.InputStream.CopyTo(memory);
                        var content = memory.GetBuffer();

                        var newImg = new Img
                        {
                            Content = content,
                            FileExtension = model.UploadedImage.FileName.Split(new[] { '.' }).Last()
                        };

                        this.Data.Images.Add(newImg);
                        this.Data.SaveChanges();

                        dbModel.Img = newImg;
                    }
                }
                else
                {
                    var img = this.Data.Images.Find(1);
                    if (img != null)
                    {
                        dbModel.Img = img;
                    }
                }

                this.Data.Fields.Add(dbModel);
                this.Data.SaveChanges();

                SetTempData("Успешно добавихте игрище");
                return RedirectToAction("Index", "Home");
            }

            SetTempData("Невалидно игрище");
            return View(model);
        }

        private void SetTempData(string message)
        {
            TempData["Message"] = message;
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