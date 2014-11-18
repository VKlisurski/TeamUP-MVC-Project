namespace TeamUp.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TeamUp.Data.Contracts;
    using TeamUp.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class TeamUpDbContext : IdentityDbContext<User>
    {
        public TeamUpDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static TeamUpDbContext Create()
        {
            return new TeamUpDbContext();
        }

        public IDbSet<Address> Addresses { get; set; }

        public IDbSet<Field> Fields { get; set; }

        public IDbSet<Game> Games { get; set; }

        public IDbSet<Vote> Votes { get; set; }

        public IDbSet<Img> Imgs { get; set; }

    }
}
