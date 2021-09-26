using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesToUniverse.Business.Abstract;

namespace NotesToUniverse.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private INoteService _noteService;

        public AdminController(INoteService noteService)
        {
            _noteService = noteService;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
