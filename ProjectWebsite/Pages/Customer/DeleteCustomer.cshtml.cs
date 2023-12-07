using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Customer
{
    public class DeleteCustomerModel : PageModel
    {

		public CustomerService CustomerService;

		[BindProperty]
		public Models.Customer Customer { get; set; }
		public DeleteCustomerModel(CustomerService customerService)
		{
			CustomerService = customerService;
		}
		//Denne metode bliver kaldt når der trykkes på "Delete" knappen på "GetAllCustomers" siden.
		public IActionResult OnGet(int id)
		{
			Customer = CustomerService.GetCustomerByID(id);
            //Der bliver tjekket om kunden er null, hvis den er null bliver der redirected til NotFound siden.
            if (Customer == null) { return RedirectToPage("/NotFound"); }
			return Page();
		}
		//Denne metode bliver kaldt når der trykkes på "Delete" knappen
		public IActionResult OnPost()
		{
			//Inde i if-statement returnerer DeleteCustomer en bool, hvis den er false (kunde ikke fundet/slettet) bliver der redirected til NotFound siden.
			if (!CustomerService.DeleteCustomer(Customer.ID)) { return RedirectToPage("/NotFound"); }
            return RedirectToPage("GetAllCustomers");
		}
		public IActionResult OnPostCancel() { return RedirectToPage("GetAllCustomers"); }
	}
}
