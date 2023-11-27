using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;
using System;

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
		public Models.Customer Customer { get; set; }
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
            CustomerRepository.CreateCustomer(Customer);
			return RedirectToPage("GetAllCustomers");
		}

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("GetAllCustomers");
        }
    }
}
