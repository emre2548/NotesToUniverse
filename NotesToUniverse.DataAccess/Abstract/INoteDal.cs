using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesToUniverse.Entities;

namespace NotesToUniverse.DataAccess.Abstract
{
    public interface INoteDal : IRepository<Note>
    {
        IOrderedQueryable<Note> GetMostLikesNotes();
    }
}
