﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesToUniverse.Entities
{
    [Table("Categories")]
    public class Category : MyEntityBase
    {
        [Required,StringLength(60),DisplayName("Kategori")]
        public string Title { get; set; }
        [StringLength(2000),DisplayName("Açıklama")]
        public string Description { get; set; }

        public virtual List<Note> Notes { get; set; } // category can have more than one note

        public Category()
        {
            Notes = new List<Note>();
        }
    }
}
