using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesToUniverse.Entities;

namespace NotesToUniverse.WebUI.Models
{
    public class NoteModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsDraft { get; set; }
        public int LikeCount { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }



        public List<Category> SelectedCategoies = new List<Category>();

        public List<Comment> SelectedNoteComments = new List<Comment>();

        public List<Liked> SelectedNoteLikes = new List<Liked>();

        public List<Note> NoteList = new List<Note>();


        public NoteModel()
        {
            SelectedNoteComments = new List<Comment>();
            SelectedNoteLikes = new List<Liked>();
        }
    }
}
