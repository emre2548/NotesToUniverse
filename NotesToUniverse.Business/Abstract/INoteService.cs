using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesToUniverse.Entities;

namespace NotesToUniverse.Business.Abstract
{
    public interface INoteService
    {
        List<Note> GetAllNote();
        List<Note> GetNotesByCategory(string category);
        void Create(Note entity);

        IOrderedQueryable<Note> GetMostLikesNotes();

    }
}
