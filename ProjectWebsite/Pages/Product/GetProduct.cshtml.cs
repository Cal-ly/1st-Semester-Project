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

        public string Message { get; set; }

        [BindProperty]
        public int AmountIN { get; set; }


        public GetProductModel(ProductService productService)
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
            Models.Product product = ProductService.GetProduct(Product.ID);
            int newID;
            if (Order.Basket?.Count == null || Order.Basket?.Count == 0)
            { 
                newID = 1; 
            }
            else 
            { 
                newID = Order.Basket.Max(p => p.ID) + 1; 
            }

            OrderLine temp = new()
            {
                Amount = AmountIN,
                Product = product,
                ID = newID
            };

            foreach (OrderLine line in Order.Basket)
            {
                if (line.Product == product)
                {
                    line.Amount += temp.Amount;
                    Message = "Antal opdateret";
                    Product = product;
                    return Page();
                }
            }
            Order.Basket.Add(temp);
            Message = "Produkt tilf�jet til kurven";
            Product = product;
            return Page();
        }
    }
}