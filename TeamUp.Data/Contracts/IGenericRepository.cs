namespace TeamUp.Data.Contracts
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using TeamUp.Models.Base;

    public interface IGenericRepository<T> where T : class, IAuditInfo
    {
        IQueryable<T> All();

        IQueryable<T> SearchFor(Expression<Func<T, bool>> conditions);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Detach(T entity);
    }
}
