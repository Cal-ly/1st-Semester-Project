using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

		public IActionResult OnGet(int id)
		{
			//Console.WriteLine(id);
			Product = ProductService.GetProduct(id);
			//Console.WriteLine(Product);
            if (Product == null)
			{
                return RedirectToPage("/NotFound");
            }
			return Page();
		}

		public IActionResult OnPost()
		{
			//Metoden bliver kørt indeni if-statement 
			if (!ProductService.DeleteProduct(Product.ID))
				return RedirectToPage("/Error");

			return RedirectToPage("GetAllProducts");
		}
		public IActionResult OnPostCancel() { return RedirectToPage("GetAllProducts"); }
	}
}