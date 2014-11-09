namespace TeamUp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TeamUp.Data;
    using TeamUp.Data.Contracts;


    public class BaseController : Controller
    {
        public BaseController(ITeamUpData data)
        {
            this.Data = data;
        }

        public ITeamUpData Data { get; set; }
    }
}