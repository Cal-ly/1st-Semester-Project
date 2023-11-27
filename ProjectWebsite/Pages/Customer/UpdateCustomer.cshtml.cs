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

		public JsonFileCustomerService CustomerService;
		public UpdateCustomerModel(JsonFileCustomerService service)
		{
			CustomerService = service;
		}

		[BindProperty]
		public Models.Customer Customer { get; set; }
		[BindProperty]
		public List<Models.Customer> Customers { get; set; } //Used for displaying all customers

		//public IActionResult OnGet(int id)
		//{
		//	Customer = CustomerService.GetObject(id);
		//	if (Customer == null)
		//		return RedirectToPage("/Error"); //Define NotFound page
		//	return Page();
		//}

		//public IActionResult OnPost()
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return Page();
		//	}
		//	CustomerService.UpdateObject(Customer);
		//	return RedirectToPage("GetAllCustomers");
		//}
	}
}

