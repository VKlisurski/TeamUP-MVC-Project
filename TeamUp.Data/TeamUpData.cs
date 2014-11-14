namespace TeamUp.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using TeamUp.Data.Contracts;
    using TeamUp.Data.Repositories;
    using TeamUp.Models;

    /// <summary>
    /// Unit of work
    /// </summary>
    public class TeamUpData : ITeamUpData
    {
        private readonly DbContext context;
        private readonly IDictionary<Type, object> repositories;

        public TeamUpData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IGenericRepository<Address> Addresses
        {
            get
            {
                return this.GetRepository<Address>();
            }
        }

        public IGenericRepository<Field> Fields
        {
            get
            {
                return this.GetRepository<Field>();
            }
        }

        public IGenericRepository<Game> Games
        {
            get
            {
                return this.GetRepository<Game>();
            }
        }

        public IGenericRepository<Vote> Votes
        {
            get
            {
                return this.GetRepository<Vote>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
