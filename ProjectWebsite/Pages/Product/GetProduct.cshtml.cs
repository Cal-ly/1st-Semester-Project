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

        public string besked { get; set; }

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
            int newID;
            if (Order.basket?.Count == null || Order.basket?.Count == 0)
            { newID = 1; }
            else { newID = Order.basket.Max(p => p.ID) + 1; }
            OrderLine temp = new()
            {
                Amount = amountIN,
                Product = product,
                ID = newID
            };

            foreach (OrderLine line in Order.basket)
            {
                if (line.Product == product)
                {
                    line.Amount += temp.Amount;
                    besked = "Antal opdateret";
                    Product = product;
                    return Page();
                }
            }
            Order.basket.Add(temp);
            besked = "Produkt tilføjet til kurven";
            Product = product;
            return Page();
        }
    }
}