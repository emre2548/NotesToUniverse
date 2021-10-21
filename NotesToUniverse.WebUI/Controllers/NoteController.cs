using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesToUniverse.Business.Abstract;
using NotesToUniverse.WebUI.Models;

namespace NotesToUniverse.WebUI.Controllers
{
    public class NoteController : Controller
    {
        private INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        public IActionResult List(string category)
        {
            return View(new NoteListModel()
            {
                Notes = _noteService.GetNotesByCategory(category)
            });
        }
    }
}
