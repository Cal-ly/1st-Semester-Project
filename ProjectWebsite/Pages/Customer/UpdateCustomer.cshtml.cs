using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;
using ProjectWebsite.Models;


/*
TO BE IMPLEMENTED: 
PROPERTIES: Change name of service to match implemented service
CONSTRUCTOR: Change name of service to match implemented service
METHOD: Change name of service to match implemented service
*/

namespace ProjectWebsite.Pages.Customer
{
	public class UpdateCustomerModel : PageModel
	{
		public CustomerRepository CustomerRepository;

		[BindProperty]
		public Models.Customer Customer { get; set; }
		[BindProperty]
		public List<Models.Customer> CustomerList { get; set; } //Used for displaying all customers

		public UpdateCustomerModel(CustomerRepository service)
		{
			CustomerRepository = service;
		}

		public IActionResult OnGet(int id)
		{
			Customer = CustomerRepository.GetCustomer(id);
			if (Customer == null)
				return RedirectToPage("/Error"); //Define NotFound page
			return Page();
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			//doesn't actually update yet since the method isn't implemented
            CustomerRepository.UpdateCustomer(Customer, Customer.ID); 
			return RedirectToPage("GetAllCustomers");
		}

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("GetAllCustomers");
        }
	}
}

