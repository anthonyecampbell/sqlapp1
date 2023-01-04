using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sqlapp1.Models;
using sqlapp1.Services;

namespace sqlapp1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Product> products;
        private readonly IProductService _productService;

        public IndexModel(ILogger<IndexModel> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public void OnGet()
        {
            products = _productService.GetProducts();
        }
    }
}