using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Models;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Product
{
    public class DeleteProductModel : PageModel
    {
		[BindProperty]
		public Models.Product Product { get; set; }
        public ProductService ProductService { get; set; }

        public DeleteProductModel(ProductService productService)
		{
			ProductService = productService;
		}

		public IActionResult OnGet(int productID)
		{
			Console.WriteLine(productID);
			Product = ProductService.GetProduct(productID);
			Console.WriteLine(Product);
            if (Product == null)
			{
                return RedirectToPage("/Error"); //Define NotFound page
            }
			
			return Page();
		}

		public IActionResult OnPost()
		{
			//Metoden bliver k�rt indeni if-statement 
			if (!ProductService.DeleteProduct(Product.ID))
				return RedirectToPage("/Error"); //Define NotFound page

			return RedirectToPage("GetAllProducts");
		}
		public IActionResult OnPostCancel() { return RedirectToPage("GetAllProducts"); }
	}
}

