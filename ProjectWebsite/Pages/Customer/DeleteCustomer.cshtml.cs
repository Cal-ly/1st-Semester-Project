using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Repositories;

namespace ProjectWebsite.Pages.Customer
{
    public class DeleteCustomerModel : PageModel
    {

		public CustomerRepository CustomerRepository;
		[BindProperty] public Models.Customer Customer { get; set; }
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
			if (!ModelState.IsValid) { return Page(); }
			//if DeleteCustomer return false (fail) then redirect to error page
			if (!CustomerRepository.DeleteCustomer(Customer.ID))
				return RedirectToPage("/Error"); //Define NotFound page

			return RedirectToPage("GetAllCustomers");
		}
		public IActionResult OnPostCancel() { return RedirectToPage("GetAllCustomers"); }
	}
}
