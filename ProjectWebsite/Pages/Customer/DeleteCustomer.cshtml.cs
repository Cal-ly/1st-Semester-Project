using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Customer
{
    public class DeleteCustomerModel : PageModel
    {

		public CustomerService CustomerService;
		[BindProperty] public Models.Customer Customer { get; set; }
		public DeleteCustomerModel(CustomerService customerService)
		{
			CustomerService = customerService;
		}

		public IActionResult OnGet(int id)
		{
			Customer = CustomerService.GetCustomerID(id);
			if (Customer == null)
				return RedirectToPage("/Error"); //Define NotFound page
			return Page();
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid) { return Page(); }
			//if DeleteCustomer return false (fail) then redirect to error page
			if (!CustomerService.DeleteCustomer(Customer.ID))
				return RedirectToPage("/Error"); //Define NotFound page

			return RedirectToPage("GetAllCustomers");
		}
		public IActionResult OnPostCancel() { return RedirectToPage("GetAllCustomers"); }
	}
}
