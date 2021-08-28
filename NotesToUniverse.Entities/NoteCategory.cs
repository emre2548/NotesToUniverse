using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesToUniverse.Entities
{
    public class NoteCategory
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public int NoteId { get; set; }
        public Note Note { get; set; }

        
    }
}
