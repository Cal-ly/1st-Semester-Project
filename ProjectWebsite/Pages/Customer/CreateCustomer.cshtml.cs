using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Customer
{
    public class CreateCustomerModel : PageModel
    {
		public CustomerService CustomerService;
		[BindProperty]
		public Models.Customer Customer { get; set; }
		public CreateCustomerModel(CustomerService customerService)
		{
			CustomerService = customerService;
		}
		public IActionResult OnGet() { return Page(); }
        //Denne metode bliver kaldt n�r der trykkes p� "Create" knappen
        public IActionResult OnPost()
		{
			if (!ModelState.IsValid) { return Page(); }
			Customer.ID = CustomerService.GetNextID();
            CustomerService.CreateCustomer(Customer);
			return RedirectToPage("GetAllCustomers");
		}
        //Denne metode bliver kaldt n�r der trykkes p� "Cancel" knappen
        public IActionResult OnPostCancel() { return RedirectToPage("GetAllCustomers"); }
	}
}
