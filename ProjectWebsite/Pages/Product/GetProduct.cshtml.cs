using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;
using ProjectWebsite.Models;
using ProjectWebsite.Repositories;

namespace ProjectWebsite.Pages.Product
{
    public class GetProductModel : PageModel
    {
        [BindProperty]
        public Models.Product Product { get; set; }
        private ProductService ProductService { get; set; }

        [BindProperty]
        public int amountIN { get; set; }


        public GetProductModel(ProductService productService)
        {
            ProductService = productService;
        }

        public IActionResult OnGet(int id)
        {
            Product = ProductService.GetProduct(id);
            if (Product == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return Page();
        }

        public IActionResult OnPost()
        {
            Models.Product product = ProductService.GetProduct(Product.ID);
            OrderLine temp = new() { Amount = amountIN, Product = product };
            Order.basket.Add(temp);
            return Page();
        }
    }
}
