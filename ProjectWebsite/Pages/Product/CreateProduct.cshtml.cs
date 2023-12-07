using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Product
{
    public class CreateProductModel : PageModel
    {
        public ProductService ProductService;

        [BindProperty]
        public Models.Product Product { get; set; }

        public CreateProductModel(ProductService productService)
        {
            ProductService = productService;
        }

        public IActionResult OnGet() 
        { 
            return Page(); 
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Product.ID = ProductService.GetNextID();
            ProductService.CreateProduct(Product);
            return RedirectToPage("GetAllProducts");
        }

        public IActionResult OnPostCancel() 
        { 
            return RedirectToPage("GetAllProducts"); 
        }
    }
}
