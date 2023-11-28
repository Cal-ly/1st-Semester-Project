using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Product
{
    public class GetProductModel : PageModel
    {
        [BindProperty]
        public Models.Product Product { get; set; }
        private ProductRepository _productRepository;

        [BindProperty]
        public string bool0 { get; set; }
        [BindProperty]
        public string bool1 { get; set; }
        [BindProperty]
        public string bool2 { get; set; }
        [BindProperty]
        public string bool3 { get; set; }
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
            Console.WriteLine("Testing23");
            Console.WriteLine(bool0);
            Console.WriteLine(bool1);
            Console.WriteLine(bool2);
            Console.WriteLine(bool3);
            Console.WriteLine(amountIN);
            
            return Page();
        }
    }
}
