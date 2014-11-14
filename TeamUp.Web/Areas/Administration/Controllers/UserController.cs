namespace TeamUp.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TeamUp.Data.Contracts;
    using TeamUp.Web.Areas.Administration.Controllers.Base;
    using TeamUp.Web.Areas.Administration.Models;
    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using TeamUp.Models;
    using AutoMapper;
    using System.Data.Entity.Validation;
    using System.Text;

    public class UserController : AdminController
    {

        public UserController(ITeamUpData data)
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
            var users =
                this.Data.Users.All()
                .AsQueryable()
                .Project()
                .To<UserAdminViewModel>()
                .ToDataSourceResult(request);

            return this.Json(users);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, UserAdminViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var id = model.Id;
                var user = this.Data.Users.Find(id);
                user.TeamUpUsername = model.TeamUpUsername;
                this.Data.Users.Update(user);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, UserAdminViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                User user = this.Data.Users.Find(model.Id);
                var votes = this.Data.Votes.All().Where(v => v.User.Id == user.Id).ToList();

                foreach (Vote vote in votes)
                {
                    this.Data.Votes.Delete(vote);
                }

                this.Data.Users.Delete(user);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}