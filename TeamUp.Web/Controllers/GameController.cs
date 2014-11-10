namespace TeamUp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using TeamUp.Data.Contracts;

    public class GameController : BaseController
    {
        public GameController(ITeamUpData data)
            : base(data)
        {
            
        }
    }
}