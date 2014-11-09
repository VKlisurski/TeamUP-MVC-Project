namespace TeamUp.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using TeamUp.Models.Base;

    public class User : IdentityUser, IAuditInfo
    {
        private ICollection<Game> games;

        public User()
        {
            this.games = new HashSet<Game>();
            this.CreatedOn = DateTime.Now;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string Phone { get; set; }

        public string ImgPath { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public System.DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public System.DateTime? ModifiedOn { get; set; }

        public System.DateTime? DeletedOn { get; set; }
    }
}
