using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Customer
{
    public class UpdateCustomerModel : PageModel
	{
		private CustomerService CustomerService { get; set; }
		[BindProperty]
		public Models.Customer Customer { get; set; }
		public UpdateCustomerModel(CustomerService customerService)
		{
			CustomerService = customerService;
		}
		//Denne metode bliver kaldt når der trykkes på "Update" knappen på "GetAllCustomers" siden.
		public IActionResult OnGet(int id)
		{
            //Henter kunden fra CustomerService
            Customer = CustomerService.GetCustomerByID(id);
            //Der bliver tjekket om kunden er null, hvis den er null bliver der redirected til NotFound siden.
			if (Customer == null) { return RedirectToPage("/NotFound"); }
            return Page();
		}
		//Denne metode bliver kaldt når der trykkes på "Update" knappen på "UpdateCustomer" siden.
		public IActionResult OnPost()
		{
			//Hvis modellen ikke er valid, bliver siden vist igen.
			if (!ModelState.IsValid) { return Page(); }
			//Opdaterer kunden i CustomerService
            CustomerService.UpdateCustomer(Customer);
			//Redirecter tilbage til "GetAllCustomers" siden.
			return RedirectToPage("GetAllCustomers");
		}
		//Redirecter tilbage til "GetAllCustomers" siden, hvis der trykkes på "Cancel".
        public IActionResult OnPostCancel() { return RedirectToPage("GetAllCustomers"); }
	}
}