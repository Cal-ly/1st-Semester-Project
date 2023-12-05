using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Customer
{
    public class NewCustomerModel : PageModel
    {
		public CustomerService CustomerService;

		[BindProperty]
		public Models.Customer Customer { get; set; }
		private OrderService OrderService { get; set; }

		public NewCustomerModel(CustomerService customerService, OrderService orderService)
		{
			CustomerService = customerService;
			OrderService = orderService;
		}

		public IActionResult OnGet() { return Page(); }

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid) 
			{ 
				return Page(); 
			}
			Customer.ID = CustomerService.GetNextID();
			CustomerService.CreateCustomer(Customer);
            Console.WriteLine(Customer.Email);
			string temp = Customer.Email;
            if (OrderService.PlaceOrder(Customer.Email))
			{ 
				return RedirectToPage("/Basket/Success"); 
			}
			else 
			{ return RedirectToPage("/Error"); }
			
		}

		public IActionResult OnPostCancel() { return RedirectToPage("/Basket/Basket"); }
	}
}
