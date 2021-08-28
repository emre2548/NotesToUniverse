using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NotesToUniverse.DataAccess.Abstract;
using NotesToUniverse.Entities;

namespace NotesToUniverse.DataAccess.Concrete.EfCore
{
    public class EfCoreGenericRepository<T, TContext> : RepositoryBase, IRepository<T>
    where T : class
    where TContext : DbContext, new()
    {

        //private DbSet<T> _objectSet;

        //public EfCoreGenericRepository(DbSet<T> objectSet)
        //{
        //    _objectSet = context.Set<T>();
        //}

        public int Delete(T obj)
        {
            using (var context = new TContext())
            {
                context.Set<T>().Remove(obj);
                return context.SaveChanges();
            }
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().FirstOrDefault(where);
            }
        }

        public int Create(T obj)
        {
            using (var context = new TContext())
            {
                context.Set<T>().Add(obj);
                return context.SaveChanges();
            }
        }

        public List<T> List()
        {
            using (var context = new TContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().Where(where).ToList();
            }
        }

        public IQueryable<T> ListQueryable()
        {
            throw new NotImplementedException();
        }

        public int Update(T obj)
        {
            using (var context = new TContext())
            {
                context.Entry(obj).State = EntityState.Modified;
                return context.SaveChanges();
            }
        }
    }
}
