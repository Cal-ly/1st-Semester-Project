using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Models;
using ProjectWebsite.Repositories;

namespace ProjectWebsite.Pages.Customer
{
    public class GetAllCustomersModel : PageModel
    {
		public CustomerRepository CustomerRepository;
		[BindProperty] public string SearchCustomer { get; set; }
		[BindProperty] public List<Models.Customer> CustomerList { get; set; } //Used for displaying all customers

		public GetAllCustomersModel(CustomerRepository service)
		{
			CustomerRepository = service;
		}

		public void OnGet()	{ CustomerList = CustomerRepository.CustomerList; }

		public IActionResult OnPostNameSearch()
		{
			if (!ModelState.IsValid) { return Page(); }
			CustomerList = CustomerRepository.NameSearch(SearchCustomer).ToList();
			return Page();
		}
	}
}
