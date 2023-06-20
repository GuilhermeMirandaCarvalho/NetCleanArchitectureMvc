using Microsoft.AspNetCore.Mvc;
using NetCleanArchitectureMvc.Application.Interfaces;
using NetCleanArchitectureMvc.Domain.Interfaces;

namespace NetCleanArchitectureMvc.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService= categoryService;  
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategories();
            return View(categories);
        }
    }
}
