using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;
using ProjectWebsite.Models;

/*
TO BE IMPLEMENTED: 
PROPERTIES: Change name of service to match implemented service
CONSTRUCTOR: Change name of service to match implemented service
METHOD: Change name of service to match implemented service

Check if the customer is null, if so, return NotFound page
Check accces modifiers!
*/

namespace ProjectWebsite.Pages.Customer
{
    public class DeleteCustomerModel : PageModel
    {

		public CustomerRepository CustomerRepository;

		[BindProperty] public Models.Customer Customer { get; set; }
		[BindProperty] public List<Models.Customer> CustomerList { get; set; } //Used for displaying all customers
		public DeleteCustomerModel(CustomerRepository service)
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
			//if DeleteCustomer return false (fail) then redirect to error page
			if (!CustomerRepository.DeleteCustomer(Customer.ID)) 
				return RedirectToPage("/Error"); //Define NotFound page

			return RedirectToPage("GetAllCustomers");
		}

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("GetAllCustomers");
        }
    }
}
