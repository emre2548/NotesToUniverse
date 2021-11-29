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
        public IOrderedQueryable<Note> GetMostLikesNotes()
        {
            using (var context = new DatabaseContext())
            {
                return context.Notes
                    .OrderByDescending(i => i.LikeCount);
            }
        }

        public List<Note> GetNotesByCategory(string category)
        {
            using (var context = new DatabaseContext())
            {
                var notes = context.Notes.AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    notes = notes.Include(i => i.NoteCategories)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.NoteCategories.Any(a => a.Category.Title.ToLower() == category.ToLower()));
                }

                return notes.ToList();
            }
        }

        public void Create(Note entity)
        {
            using (var context = new DatabaseContext())
            {
                if (entity != null)
                {
                    Note note = new Note();
                    note.Title = entity.Title;
                    note.Text = entity.Text;
                    note.CreateOn = entity.CreateOn;
                    note.Owner = entity.Owner;
                    note.Image = entity.Image;

                    context.Notes.Add(note);
                    context.SaveChanges();
                }
            }
        }



    }
}
