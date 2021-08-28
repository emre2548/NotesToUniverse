using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesToUniverse.DataAccess.Abstract;
using NotesToUniverse.Entities;

namespace NotesToUniverse.DataAccess.Concrete.EfCore
{
    public class EfCoreCategoryDal : EfCoreGenericRepository<Category, DatabaseContext>, ICategoryDal
    {
        //public List<Category> GetCategories()
        //{
        //    using (var context = new DatabaseContext())
        //    {
        //        return context.Categories.ToList();
        //    }
        //}
    }
}
