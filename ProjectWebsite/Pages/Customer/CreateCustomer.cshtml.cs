using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

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
		public CustomerRepository CustomerRepository;
		[BindProperty] public Models.Customer Customer { get; set; }
		public CreateCustomerModel(CustomerRepository service)
		{
			CustomerRepository = service;
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
            //CustomerRepository.AddObject(Customer);
			return RedirectToPage("./Index");
		}

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("./Index");
        }
    }
}
