using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesToUniverse.Entities;

namespace NotesToUniverse.WebUI.Models
{
    //public class NoteInfo
    //{
    //    public int Id { get; set; }
    //    public int I { get; set; }
    //}

    public class NoteListModel
    {
        public List<Note> Notes { get; set; }

        //public NoteInfo NoteInfo { get; set; }
    }
}
