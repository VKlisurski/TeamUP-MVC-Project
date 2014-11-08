using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamUp.Data;

namespace TeamUp.Web.Controllers
{
    public class BaseController : Controller
    {
        private TeamUpData data;

        public BaseController()
            :this(new TeamUpData())
        {

        }

        public BaseController(TeamUpData data)
        {
            this.Data = data;
        }

        public TeamUpData Data
        {
            get
            {
                return this.data;
            }

            private set
            {
                this.data = value;
            }
        }
    }
}