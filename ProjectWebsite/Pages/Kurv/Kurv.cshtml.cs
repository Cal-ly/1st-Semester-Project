using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Models;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Kurv
{
    public class KurvModel : PageModel
    {

        [BindProperty]
        public string Email { get; set; }
        private CustomerRepository customerRepository { get; set; }
        private OrderService OrderService { get; set; }

		public KurvModel(CustomerRepository customerRepository , OrderService orderService)
		{
			this.customerRepository = customerRepository;
            OrderService = orderService;
        }

		public IActionResult OnGet()
        {
            Console.WriteLine("Testing");
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
