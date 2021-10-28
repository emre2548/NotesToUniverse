using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesToUniverse.Business.Abstract;
using NotesToUniverse.Entities;
using NotesToUniverse.WebUI.Models;

namespace NotesToUniverse.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private INoteService _noteService;

        public AdminController(INoteService noteService)
        {
            _noteService = noteService;
        }


        public IActionResult ProductList()
        {
            return View(new NoteListModel()
            {
                Notes = _noteService.GetAllNote()
            });
        }

        [HttpGet]
        public IActionResult CreateNote()
        {
            return View(new NoteModel());
        }

        [HttpPost]
        public IActionResult CreateNote(NoteModel Note){
            var entity = new Note()
            {
                Title = Note.Title,
                Text = Note.Text,
                CreateOn = DateTime.Now,
                Owner = "Kullanıcı"
            };

            _noteService.Create(entity);

            return View(Note);
        }
    }
}
