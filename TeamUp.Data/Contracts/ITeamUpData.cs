namespace TeamUp.Data.Contracts
{
    using TeamUp.Models;

    public interface ITeamUpData
    {
        IGenericRepository<Address> Addresses { get;}

        IGenericRepository<Field> Fields { get;}

        IGenericRepository<Game> Games { get;}

        IGenericRepository<User> Users { get; }

        IGenericRepository<Vote> Votes { get; }
        
        IGenericRepository<Img> Images { get; }

        void SaveChanges();
    }
}
