using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesToUniverse.Entities
{

    public class Note : MyEntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsDraft { get; set; }
        public int LikeCount { get; set; }
        public string Owner { get; set; }
        // TODO image will add
        //public string Image { get; set; }

        public List<NoteCategory> NoteCategories { get; set; }
        public List<Liked> Likes { get; set; }
        public List<Comment> Comments { get; set; }


    }
}
