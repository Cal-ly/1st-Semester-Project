using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Product
{
    public class GetProductModel : PageModel
    {
        [BindProperty]
        public Models.Product Product { get; set; }
        private ProductRepository _productRepository;

        public GetProductModel(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult OnGet(int id)
        {
            Product = _productRepository.GetProduct(id);
            if (Product == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return Page();
        }
    }
}
