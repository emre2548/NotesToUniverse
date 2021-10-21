﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesToUniverse.Entities;

namespace NotesToUniverse.WebUI.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Note> Notes { get; set; }
    }
}
