using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;
using System.ComponentModel.DataAnnotations;

namespace ProjectWebsite.Pages.Product
{
    public class GetAllProductsModel : PageModel
    {
        private ProductService ProductService { get; set; }
        public List<Models.Product> Products { get; private set; }

        [BindProperty]
        [Range(typeof(int), minimum: "0", maximum: "1000", ErrorMessage = "Prisen skal være mellem {1} og {2}")]
        public int MinPrice { get; set; }

        [BindProperty]
        [Range(typeof(int), minimum: "0", maximum: "1000", ErrorMessage = "Prisen skal være mellem {1} og {2}")]
        public int MaxPrice { get; set; }

        [BindProperty]
        [MaxLength(25)]
        public string? SearchString { get; set; }


        public GetAllProductsModel(ProductService productService)
        {
            ProductService = productService;
        }

        public void OnGet()
        {
            Products = ProductService.ProductList;
        }

        public IActionResult OnPostPriceFilter()
        {
            Products = ProductService.PriceFilter(MaxPrice, MinPrice).ToList();
            return Page();
        }

        public IActionResult OnPostNameSearch()
        {
            if (!String.IsNullOrEmpty(SearchString))
            {
                Products = ProductService.NameSearch(SearchString).ToList();
                return Page();
            }
            Products = ProductService.ProductList;
            return Page();
        }
    }
}
