using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Product
{
    public class DeleteProductModel : PageModel
    {
		public ProductService ProductService;

		[BindProperty]
		public Models.Product Product { get; set; }

		public DeleteProductModel(ProductService productService)
		{
			ProductService = productService;
		}

		public IActionResult OnGet(int productID)
		{
			Product = ProductService.GetProductByID(productID);
			if (Product == null)
				return RedirectToPage("/Error"); //Define NotFound page
			return Page();
		}

		public IActionResult OnPost()
		{
			//Metoden bliver kørt indeni if-statement 
			if (!ProductService.DeleteProduct(Product.ID))
				return RedirectToPage("/Error"); //Define NotFound page

			return RedirectToPage("GetAllProducts");
		}
		public IActionResult OnPostCancel() { return RedirectToPage("GetAllProducts"); }
	}
}

