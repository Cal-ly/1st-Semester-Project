using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Customer
{
    public class GetAllCustomersModel : PageModel
    {
		public CustomerService CustomerService;
		[BindProperty] public string SearchCustomer { get; set; }
		[BindProperty] public List<Models.Customer> CustomerList { get; set; } //Used for displaying all customers

		public GetAllCustomersModel(CustomerService customerService)
		{
			CustomerService = customerService;
		}

		public void OnGet()	{ CustomerList = CustomerService.CustomerList; }

		public IActionResult OnPostNameSearch()
		{
			if (!ModelState.IsValid) { return Page(); }
			CustomerList = CustomerService.GetCustomerName(SearchCustomer).ToList();
			return Page();
		}
	}
}
