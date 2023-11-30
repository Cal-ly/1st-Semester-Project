using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Kurv
{
    public class KurvModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }
        private OrderService OrderService { get; set; }

		public KurvModel(OrderService orderService)
		{
            OrderService = orderService;
        }

		public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            OrderService.PlaceOrder(Email);
            return RedirectToPage("/Customer/GetAllCustomers");
        }

        //public IActionResult OnPostCancel()
        //{
        //    Console.WriteLine("It works definitely");
        //    return Page();
        //}
    }
}
