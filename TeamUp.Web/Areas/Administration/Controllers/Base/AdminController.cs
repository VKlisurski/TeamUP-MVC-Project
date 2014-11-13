namespace TeamUp.Web.Areas.Administration.Controllers.Base
{
    using System;
    using System.Web.Mvc;
    using TeamUp.Data.Contracts;
    using TeamUp.Web.Controllers;

    //[Authorize(Roles = "Admin")]
    public abstract class AdminController : BaseController
    {
        public AdminController(ITeamUpData data)
            : base(data)
        {

        }
    }
}