using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesToUniverse.Business.Abstract;
using NotesToUniverse.WebUI.Models;

namespace NotesToUniverse.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private INoteService _noteService;

        public HomeController(INoteService noteService)
        {
            _noteService = noteService;
        }

        public IActionResult Index()
        {
            return View(new NoteListModel()
            {
                Notes = _noteService.GetAllNote().OrderByDescending(x => x.CreateOn).ToList()
            });
        }

        //public IActionResult MostLiked()
        //{

        //}
    }
}
