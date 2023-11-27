using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Customer
{
	public class CreateCustomerModel : PageModel
	{
		/*
		TO BE IMPLEMENTED: 
		PROPERTIES: Change name of service to match implemented service
		CONSTRUCTOR: Change name of service to match implemented service
		METHOD: Change name of service to match implemented service
		*/

		public JsonFileCustomerService CustomerService;

		[BindProperty]
		public Models.Customer Customer { get; set; }
		public List<Models.Customer> Customers { get; set; } //Used for displaying all customers

		public CreateCustomerModel(CustomerService service)
		{
			CustomerService = service;
		}

		public CreateCustomerModel()
		{
		}

		public IActionResult OnGet(int id)
		{
			Customer = CustomerService.GetObject(id);
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
			CustomerService.UpdateObject(Customer);
			return RedirectToPage("./Index");
		}
	}
}

