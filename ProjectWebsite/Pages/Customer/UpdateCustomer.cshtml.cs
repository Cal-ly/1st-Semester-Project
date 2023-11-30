using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Customer
{
    public class UpdateCustomerModel : PageModel
	{
		public CustomerService CustomerService;
		[BindProperty] public Models.Customer Customer { get; set; }
		public UpdateCustomerModel(CustomerService customerService)
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
            CustomerService.UpdateCustomer(Customer);
			return RedirectToPage("GetAllCustomers");
		}
        public IActionResult OnPostCancel() { return RedirectToPage("GetAllCustomers"); }
	}
}