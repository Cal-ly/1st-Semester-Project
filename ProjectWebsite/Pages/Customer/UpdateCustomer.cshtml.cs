using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Models;
using ProjectWebsite.Repositories;

namespace ProjectWebsite.Pages.Customer
{
    public class UpdateCustomerModel : PageModel
	{
		public CustomerRepository CustomerRepository;
		[BindProperty] public Models.Customer Customer { get; set; }
		public UpdateCustomerModel(CustomerRepository service)
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
            CustomerRepository.UpdateCustomer(Customer);
			return RedirectToPage("GetAllCustomers");
		}
        public IActionResult OnPostCancel() { return RedirectToPage("GetAllCustomers"); }
	}
}