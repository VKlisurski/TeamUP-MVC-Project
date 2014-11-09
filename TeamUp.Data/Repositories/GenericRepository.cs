namespace TeamUp.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using TeamUp.Data.Contracts;
    using TeamUp.Models.Base;

    public class GenericRepository<T> : IGenericRepository<T> where T : class, IAuditInfo
    {
        private readonly DbContext context;
        private readonly IDbSet<T> set;

        public GenericRepository(DbContext givvenContext)
        {
            this.context = givvenContext;
            this.set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.set.Where(x => x.DeletedOn == null);
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> conditions)
        {
            return this.All().Where(conditions);
        }

        public void Add(T entity)
        {
            entity.CreatedOn = DateTime.Now;
            this.ChangeEntityState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            entity.ModifiedOn = DateTime.Now;
            this.ChangeEntityState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            entity.DeletedOn = DateTime.Now;
            this.ChangeEntityState(entity, EntityState.Deleted);
        }

        public void Detach(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Detached);
        }

        private void ChangeEntityState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}
