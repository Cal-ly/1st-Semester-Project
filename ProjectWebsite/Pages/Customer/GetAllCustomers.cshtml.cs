using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;
using ProjectWebsite.Models;

namespace ProjectWebsite.Pages.Customer
{
    public class GetAllCustomersModel : PageModel
    {
        public JsonFileCustomerService CustomerService;
        public GetAllCustomersModel(JsonFileCustomerService service)
        {
			CustomerService = service;
		}

        [BindProperty]
        public Models.Customer Customer { get; set; }
		[BindProperty]
		public List<Models.Customer> Customers { get; set; } //Used for displaying all customers
  //      public void OnGet()
  //      {
  //          Customers = CustomerService.GetAllObjects();
  //      }
  //      public IActionResult OnPostNameSearch()
  //      {
  //          Customers = CustomerService.NameSearch(SearchString).ToList();
		//	return Page();
		//}
    }
}
