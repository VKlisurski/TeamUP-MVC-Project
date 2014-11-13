namespace TeamUp.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using TeamUp.Models.Base;

    public class User : IdentityUser, IAuditInfo
    {
        private ICollection<Game> games;
        private ICollection<Vote> votes;

        public User()
        {
            this.games = new HashSet<Game>();
            this.votes = new HashSet<Vote>();
            this.ImgPath = "~/Content/Images/Avatars/default.jpg";
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string ImgPath { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string TeamUpUsername { get; set; }

        public System.DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public System.DateTime? ModifiedOn { get; set; }

        [Index]
        public System.DateTime? DeletedOn { get; set; }

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
    }
}
