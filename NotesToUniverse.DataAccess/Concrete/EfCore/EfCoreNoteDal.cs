using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NotesToUniverse.DataAccess.Abstract;
using NotesToUniverse.Entities;

namespace NotesToUniverse.DataAccess.Concrete.EfCore
{
    public class EfCoreNoteDal : EfCoreGenericRepository<Note, DatabaseContext>, INoteDal
    {
        //public List<Note> GetAllNote()
        //{
        //    using (var context = new DatabaseContext())
        //    {
        //        return context.Notes.ToList();
        //    }
        //}
    }
}
