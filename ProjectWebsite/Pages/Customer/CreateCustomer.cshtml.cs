using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Models;

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

		public IActionResult OnGet() { return Page(); }

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid) { return Page(); }
			Customer.ID = CustomerRepository.GetNextID();
            CustomerRepository.CreateCustomer(Customer);
			return RedirectToPage("GetAllCustomers");
		}
		public IActionResult OnPostCancel() { return RedirectToPage("GetAllCustomers"); }
	}
}
