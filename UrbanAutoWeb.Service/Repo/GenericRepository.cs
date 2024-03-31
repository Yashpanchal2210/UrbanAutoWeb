using System;
using System.Data;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanAutoWeb.Service.Repo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly UrbanAutoMasterContext _dbContext;

        public GenericRepository(UrbanAutoMasterContext context)
        {
            _dbContext = context;
        }
        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }
        public void Update(T entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
