using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Product
{
    public class CreateProductModel : PageModel
    {
        private ProductService ProductService;

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
            Product.ID = ProductService.GetNextID(); //1.VIDERE TIL PRODUCT SERVICE
            ProductService.CreateProduct(Product); //2.VIDERE TIL PRODUCT SERVICE
            return RedirectToPage("GetAllProducts"); //3. TILBAGE TIL GET ALL PRODUCTS
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("GetAllProducts");
        }
    }
}
