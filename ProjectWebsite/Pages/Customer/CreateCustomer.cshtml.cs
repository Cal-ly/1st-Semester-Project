using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

		public CreateCustomerModel(CustomerService service)
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
