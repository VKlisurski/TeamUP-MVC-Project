namespace TeamUp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using PagedList;
    using TeamUp.Data.Contracts;
    using TeamUp.Models;
    using TeamUp.Web.Models;
    using TeamUp.Web.Models.Fields;

    public class FieldController : BaseController
    {
        public FieldController(ITeamUpData data) : base(data)
        {
        }

        public ActionResult Index(string sortingOrder, int? page)
        {
            this.ViewBag.CurrentSortOrder = sortingOrder;
            int pageNumber = page ?? 1;
            int itemsPerPage = 4;

            IEnumerable<FieldViewModel> fields = this.Data.Fields.All()
                                                     .AsQueryable()
                                                     .Project()
                                                     .To<FieldViewModel>();

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

            return this.View(fields.ToPagedList(pageNumber, itemsPerPage));
        }

        [Authorize]
        [HttpGet]
        public ActionResult Add()
        {
            var fieldFielModel = new FieldAddModel();

            return this.View("~/Views/Field/Add.cshtml", fieldFielModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Add(FieldAddModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                if (this.ValidateGameInput(model) == false)
                {
                    return this.RedirectToAction("Index", "Home");
                }

                Address addres = this.Data.Addresses.All().Where(a => a.Street == model.Street).FirstOrDefault();
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
                        byte[] content = memory.GetBuffer();

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
                    Img img = this.Data.Images.Find(1);
                    if (img != null)
                    {
                        dbModel.Img = img;
                    }
                }

                this.Data.Fields.Add(dbModel);
                this.Data.SaveChanges();

                this.SetTempData("Успешно добавихте игрище");
                return this.RedirectToAction("Index", "Home");
            }

            this.SetTempData("Невалидно игрище");
            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult Image(int id)
        {
            Img image = this.Data.Images.Find(id);

            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }

            return this.File(image.Content, string.Format("image/{0}", image.FileExtension));
        }

        private bool ValidateGameInput(FieldAddModel model)
        {
            if (model.Phone.Length < 7 || model.Phone.Length > 15)
            {
                return false;
            }

            if (string.IsNullOrEmpty(model.Street) || model.Street.Length < 3 || model.Street.Length > 30)
            {
                this.SetTempData("Невалиднa улица");
                return false;
            }

            if (string.IsNullOrEmpty(model.City) || model.City.Length < 4 || model.Street.Length > 30)
            {
                this.SetTempData("Невалиден град");
                return false;
            }

            if (string.IsNullOrEmpty(model.Name) || model.Name.Length < 4 || model.Name.Length > 30)
            {
                this.SetTempData("Невалидно име на игрище");
                return false;
            }

            return true;
        }

        private void SetTempData(string message)
        {
            this.TempData["Message"] = message;
        }
    }
}