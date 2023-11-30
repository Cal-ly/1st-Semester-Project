using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Models;

namespace ProjectWebsite.Pages.Product
{
    public class GetProductModel : PageModel
    {
        [BindProperty]
        public Models.Product Product { get; set; }
        private ProductRepository _productRepository;

        [BindProperty]
        public int amountIN { get; set; }


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

        public IActionResult OnPost()
        {
            Models.Product product = _productRepository.GetProduct(Product.ID);
            OrderLine temp = new() { Amount = amountIN, Product = product };
            Order.basket.Add(temp);
            return Page();
        }
    }
}
