using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Customer
{
    public class CreateCustomerModel : PageModel
    {
        private CustomerService CustomerService { get; set; }
        [BindProperty]
        public Models.Customer Customer { get; set; }
        public CreateCustomerModel(CustomerService customerService)
        {
            CustomerService = customerService;
        }
        public IActionResult OnGet() { return Page(); }
        //Denne metode bliver kaldt når der trykkes på "Opret" knappen
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) { return Page(); }
            if (CustomerService.GetCustomerByEmail(Customer.Email) != null)
            {
                ModelState.AddModelError("Customer.Email", "Email already exists.");
                return Page();
            }
            Customer.ID = CustomerService.GetNextID();
            CustomerService.CreateCustomer(Customer);
            return RedirectToPage("GetAllCustomers");
        }
    }
}
