using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Product
{
    public class DeleteProductModel : PageModel
    {
        private ProductService ProductService { get; set; }
        [BindProperty]
        public Models.Product Product { get; set; }

        public DeleteProductModel(ProductService productService)
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
            if (!ProductService.DeleteProduct(Product.ID))
            {
                return RedirectToPage("/Error");
            }
            return RedirectToPage("GetAllProducts");
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("GetAllProducts");
        }
    }
}