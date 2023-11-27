using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Product
{
    public class GetAllProductsModel : PageModel
    {
        public List<Models.Product> Products { get; private set; } = new List<Models.Product>();

        private JsonProductService _jsonService;
        private ProductService _productService;

        [BindProperty] public int MinPrice { get; set; }
        [BindProperty] public int MaxPrice { get; set; }

        public GetAllProductsModel(JsonProductService jsonService, ProductService productService)
        {
            _jsonService = jsonService;
            _productService = productService;
        }

        public void OnGet()
        {
            Products = _jsonService.GetJsonItems().ToList();
        }

        public IActionResult OnPostPriceFilter()
        {
            Products = _productService.PriceFilter(MaxPrice, MinPrice).ToList();
            return Page();
        }
    }
}
