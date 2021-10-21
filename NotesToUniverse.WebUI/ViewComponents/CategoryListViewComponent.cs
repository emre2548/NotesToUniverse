using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotesToUniverse.Business.Abstract;
using NotesToUniverse.WebUI.Models;

namespace NotesToUniverse.WebUI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        // TODO Kategoriler eklenecek tablo oluşturulacak

        private ICategoryService _categoryService;

        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            return View(new CategoryListViewModel()
            {
                SelectedCategory = RouteData.Values["category"]?.ToString(),
                Categories = _categoryService.GetAllCategories()
            });
        }

    }
}
