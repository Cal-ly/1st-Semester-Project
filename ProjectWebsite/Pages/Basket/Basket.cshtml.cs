using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Models;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Kurv
{
    public class KurvModel : PageModel
    {
        [BindProperty]
        public int Amount { get; set; }

        //[BindProperty]
        public string Email { get; set; }

        public List<OrderLine> kurv { get; set; }
        public double total { get; set; }
        private OrderService OrderService { get; set; }

        public KurvModel(OrderService orderService)
		{
            OrderService = orderService;
        }

		public IActionResult OnGet()
        {
            kurv = Models.Order.basket;
            tempTotal();
            return Page();
        }

        public IActionResult OnPostConfirm()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            OrderService.PlaceOrder(Email);
            return RedirectToPage("/Customer/GetAllCustomers");
        }

        public IActionResult OnPostUpdateOrderAmount(int newAmount, int orderLineID)
        {
            return RedirectToPage("EditAmount");
        }

        public void tempTotal()
        {
            total = 0;
            foreach(var line in kurv)
            {
                total += line.Amount * line.Product.Price;
            }
		}

        //public IActionResult OnPostCancel()
        //{
        //    Console.WriteLine("It works definitely");
        //    return Page();
        //}
    }
}
