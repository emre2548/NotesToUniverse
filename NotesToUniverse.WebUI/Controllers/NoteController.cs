using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesToUniverse.Business.Abstract;
using NotesToUniverse.WebUI.Models;
using NotesToUniverse.Entities;
using Microsoft.AspNetCore.Http;
using System.IO;

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

        [HttpGet]
        public IActionResult Create()
        {
            return View(new NoteModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(NoteModel model, IFormFile file)
        {
            /*
            TODO Change file name with username+date
            TODO check image file format and size
            */
            if (ModelState.IsValid)
            {

                var entity = new Note()
                {
                    Title = model.Title,
                    Text = model.Text,
                    IsDraft = model.IsDraft,
                    CreateOn = DateTime.Now
                };

                if (file != null)
                {
                    entity.Image = file.FileName;

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                _noteService.Create(entity);
                return Redirect("Index");
            }
            return View(model);
        }

    }
}
