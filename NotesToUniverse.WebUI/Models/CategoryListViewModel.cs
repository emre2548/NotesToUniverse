﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesToUniverse.Entities;

namespace NotesToUniverse.WebUI.Models
{
    public class CategoryListViewModel
    {
        public string SelectedCategory { get; set; }
        public List<Category> Categories { get; set; }
    }
}
