namespace TeamUp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Game> games;
        private ICollection<Vote> votes;

        public User()
        {
            this.games = new HashSet<Game>();
            this.votes = new HashSet<Vote>();
            this.ImgPath = "~/Content/Images/Avatars/default.jpg";
        }

        public string StartDate { get; set; }

        public string ImgPath { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string TeamUpUsername { get; set; }

        public virtual ICollection<Vote> Votes
        {
            get
            {
                return this.votes;
            }

            set
            {
                this.votes = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
