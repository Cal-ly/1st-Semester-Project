using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

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

		public JsonFileCustomerService CustomerService;


		public DeleteCustomerModel(JsonFileCustomerService service)
		{
			CustomerService = service;
		}

		[BindProperty]
		public Models.Customer Customer { get; set; }
		public List<Models.Customer> Customers { get; set; } //Used for displaying all customers

		public IActionResult OnGet(int id)
		{
			Customer = CustomerService.GetObject(id);
			if (Customer == null)
				return RedirectToPage("/Error"); //Define NotFound page
			return Page();
		}

		public IActionResult OnPost()
		{
			Models.Customer deletedCustomer = CustomerService.DeleteObject(Customer.Id);
			if (deletedCustomer == null)
				return RedirectToPage("/Error"); //Define NotFound page

			return RedirectToPage("GetAllCustomers");
		}
	}
}
