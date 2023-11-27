using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;
using ProjectWebsite.Models;

namespace ProjectWebsite.Pages.Customer
{
    public class GetAllCustomersModel : PageModel
    {
		public CustomerRepository CustomerRepository;

		[BindProperty]
		public Models.Customer Customer { get; set; }
		[BindProperty]
		public List<Models.Customer> CustomerList { get; set; } //Used for displaying all customers

		public GetAllCustomersModel(CustomerRepository service)
		{
			CustomerRepository = service;
		}

		public void OnGet()
		{
			CustomerList = CustomerRepository.GetList;
		}

		//      public IActionResult OnPostNameSearch()
		//      {
		//          Customers = CustomerService.NameSearch(SearchString).ToList();
		//	return Page();
		//}
	}
}
