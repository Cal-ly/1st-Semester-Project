using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Product
{
    public class UpdateProductModel : PageModel
    {
        private ProductService ProductService { get; set; }

        [BindProperty]
        public Models.Product Product { get; set; }

        public UpdateProductModel(ProductService productService)
        {
            ProductService = productService;
        }

        public IActionResult OnGet(int id)
        {
            Product = ProductService.GetProduct(id);
            if (Product == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ProductService.UpdateProduct(Product);
            return RedirectToPage("GetAllProducts");
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("GetAllProducts");
        }
    }
}
