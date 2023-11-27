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
    public class CreateCustomerModel : PageModel
    {
		public JsonFileCustomerService CustomerService;

		[BindProperty]
		public Models.Customer Customer { get; set; }
		public List<Models.Customer> Customers { get; set; } //Used for displaying all customers

		public CreateCustomerModel(JsonFileCustomerService service)
		{
			CustomerService = service;
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
			CustomerService.AddObject(Customer);
			return RedirectToPage("./Index");
		}
	}
}
