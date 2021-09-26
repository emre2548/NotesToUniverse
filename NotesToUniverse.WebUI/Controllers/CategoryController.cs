using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesToUniverse.Business.Abstract;
using NotesToUniverse.WebUI.Models;

namespace NotesToUniverse.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private INoteService _noteService;

        public CategoryController(INoteService noteService)
        {
            _noteService = noteService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(new NoteListModel()
            {
                Notes = _noteService.GetAllNote()
            });
        }
    }
}
