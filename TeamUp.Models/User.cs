namespace TeamUp.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class User : IdentityUser
    {
        private ICollection<Game> games;

        public User()
        {
            this.games = new HashSet<Game>();
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

        public virtual ICollection<Game> Games
        {
            get
            {
                return this.games;
            }
            set
            {
                this.games = value;
            }
        }
    }
}
