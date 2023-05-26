using Medical_Athena_Calendly.Interface;
using Medical_Athena_Calendly.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Medical_Athena_Calendly.Repository
{
    public abstract class GenericRepository<T> : IGeneric<T> where T : class
    {
        private  ApplicationDBContext _dbContext { get; set; }

        internal DbSet<T> dbSet;
        public GenericRepository(ApplicationDBContext dbContext)
        {
            this._dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public IQueryable<T> FindAll() => dbSet.AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            dbSet.Where(expression).AsNoTracking();
        public  void Create(T entity) => dbSet.Add(entity);
        public void Update(T entity) => dbSet.Update(entity);
        public void Delete(T entity) => dbSet.Remove(entity);



    }
}
