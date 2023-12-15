using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Models;
using ProjectWebsite.Services;
using System.ComponentModel.DataAnnotations;

namespace ProjectWebsite.Pages.Product
{
    public class GetAllProductsModel : PageModel
    {
        private ProductService ProductService { get; set; }
        public Models.Product Product { get; set; }
        public List<Models.Product> Products { get; private set; }
        public string Message { get; set; }

        [BindProperty]
        [Range(typeof(int), minimum: "0", maximum: "1000", ErrorMessage = "Prisen skal være mellem {1} og {2}")]
        public int MinPrice { get; set; }

        [BindProperty]
        [Range(typeof(int), minimum: "0", maximum: "1000", ErrorMessage = "Prisen skal være mellem {1} og {2}")]
        public int MaxPrice { get; set; }

        [BindProperty]
        [MaxLength(25)]
        public string? SearchString { get; set; }


        public GetAllProductsModel(ProductService productService)
        {
            ProductService = productService;
        }

        public void OnGet()
        {
            Products = ProductService.ProductList;
        }

        public IActionResult OnPostAddToBasket(int ID)
        {
            Models.Product product = ProductService.GetProduct(ID);
            if (!ModelState.IsValid)
            {
                Product = product;
                return Page();
            }
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
                Amount = 1,
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
                    Products = ProductService.ProductList;
                    return Page();
                }
            }
            Order.Basket.Add(temp);
            Message = "Produkt tilføjet til kurven";
            Product = product;
            Products = ProductService.ProductList;
            return Page();
        }
    


        public IActionResult OnPostPriceFilter()
        {
            Products = ProductService.PriceFilter(MaxPrice, MinPrice).ToList();
            return Page();
        }

        public IActionResult OnPostNameSearch()
        {
            if (!String.IsNullOrEmpty(SearchString))
            {
                Products = ProductService.NameSearch(SearchString).ToList();
                return Page();
            }
            Products = ProductService.ProductList;
            return Page();
        }
    }
}
