using Microsoft.AspNetCore.Mvc;
using NetCleanArchitectureMvc.Application.Interfaces;

namespace NetCleanArchitectureMvc.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService= productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            return View(products);
        }
    }
}
