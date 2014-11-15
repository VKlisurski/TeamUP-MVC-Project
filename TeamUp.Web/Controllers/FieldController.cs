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
    }
}