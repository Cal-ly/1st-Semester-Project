using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;
using System.ComponentModel.DataAnnotations;

namespace ProjectWebsite.Pages.Product
{
    public class GetAllProductsModel : PageModel
    {
        public List<Models.Product> Products { get; private set; }

        private ProductService ProductService { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Du skal skrive noget i søgefeltet")]
        [Range(typeof(int), minimum: "0", maximum: "100", ErrorMessage = "Prisen skal være mellem {1} og {2}")]
        public int MinPrice { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Du skal skrive noget i søgefeltet")]
        [Range(typeof(int), minimum: "0", maximum: "100", ErrorMessage = "Prisen skal være mellem {1} og {2}")]
        public int MaxPrice { get; set; }
        
        [BindProperty]
        [Required(ErrorMessage = "Du skal skrive noget i søgefeltet"), MaxLength(10, ErrorMessage ="Din søgning må max indeholde 10 karakterer")]
        public string SearchString { get; set; }


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
