using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesToUniverse.Entities
{

    public class Comment : MyEntityBase
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Owner { get; set; } // one user wrote one comment

        public int NoteId { get; set; }
        public Note Note { get; set; } // Every comment for one universnote
    }
}
