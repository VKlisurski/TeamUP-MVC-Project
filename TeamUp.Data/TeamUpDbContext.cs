namespace TeamUp.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TeamUp.Models;

    public class TeamUpDbContext : IdentityDbContext<User>
    {
        public TeamUpDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Address> Addresses { get; set; }

        public IDbSet<Field> Fields { get; set; }

        public IDbSet<Game> Games { get; set; }

        public IDbSet<Vote> Votes { get; set; }

        public IDbSet<Img> Imgs { get; set; }

        public static TeamUpDbContext Create()
        {
            return new TeamUpDbContext();
        }
    }
}
