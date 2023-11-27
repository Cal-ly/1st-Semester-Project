using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjectWebsite.Pages.Customer
{
    public class CreateCustomerModel : PageModel
    {
		//to be implemented
		private JsonFileCustomerService CustomerService;

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
