using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesToUniverse.Entities
{
    [Table("Comments")]
    public class Comment : MyEntityBase
    {
        [Required,StringLength(600)]
        public string Text { get; set; }
        public Note Note { get; set; } // Every comment for one universnote
        public string Owner { get; set; } // one user wrote one comment
    }
}
