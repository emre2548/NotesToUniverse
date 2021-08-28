using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NotesToUniverse.DataAccess.Abstract
{
    public interface IRepository<T> where T : class
    {
        int Create(T obj);
        int Update(T obj);
        int Delete(T obj);

        List<T> List();
        IQueryable<T> ListQueryable();
        List<T> List(Expression<Func<T, bool>> where);
        T Find(Expression<Func<T, bool>> where);
    }
}
