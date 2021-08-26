﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesToUniverse.Entities
{
    [Table("Notes")]
    public class Note : MyEntityBase
    {
        [StringLength(120)]
        public string Title { get; set; }

        [StringLength(4000)]
        public string Text { get; set; }

        public bool IsDraft { get; set; }
        public int LikeCount { get; set; }
        public int CategoryId { get; set; }
        
        
        public virtual Category Category { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public string Owner { get; set; }

        public virtual List<Liked> Likes { get; set; }

        public Note()
        {
            Comments = new List<Comment>();
            Likes = new List<Liked>();
        }

    }
}
