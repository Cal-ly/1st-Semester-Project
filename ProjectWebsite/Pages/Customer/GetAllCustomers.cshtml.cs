using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Customer
{
    public class GetAllCustomersModel : PageModel
    {
		public CustomerService CustomerService;

		[BindProperty]
		public string SearchCustomer { get; set; }
		[BindProperty]
		public List<Models.Customer> CustomerList { get; set; } //Indeholder alle kunde-objekterne

		public GetAllCustomersModel(CustomerService customerService)
		{
			CustomerService = customerService;
		}

		public void OnGet()	{ CustomerList = CustomerService.CustomerList; }
		//Denne metode bliver kaldt, når der trykkes på NameSearch knappen. Den søger efter kunder med det indtastede navn.
		public IActionResult OnPostNameSearch()
		{
			if (!ModelState.IsValid) { return Page(); }
			CustomerList = CustomerService.GetCustomersByName(SearchCustomer).ToList();
			return Page();
		}
	}
}
