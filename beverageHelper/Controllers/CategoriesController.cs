using _6262App.Business.Services;
using _6282App.core.Models;
using Microsoft.AspNetCore.Mvc;

namespace beverageHelper.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public Task<IActionResult> Index()
        {
            List<Category> list = categoryService.FindAll();
            return Task.FromResult<IActionResult>(View(list));
        }

        public IActionResult Create(string catName)
        {
            Category category = new Category
            {
                Name = catName
            };
            categoryService.Save(category);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(long id)
        {
            if (categoryService.Delete(id).IsCompleted)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}