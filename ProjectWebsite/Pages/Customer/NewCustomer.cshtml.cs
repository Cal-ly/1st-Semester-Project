using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Customer
{
    public class NewCustomerModel : PageModel
    {
        private CustomerService CustomerService { get; set; }
        private OrderService OrderService { get; set; }
        [BindProperty]
        public Models.Customer Customer { get; set; }

        public NewCustomerModel(CustomerService customerService, OrderService orderService)
        {
            CustomerService = customerService;
            OrderService = orderService;
        }
        public IActionResult OnGet() { return Page(); }
        //Denne metode bliver kaldt, når der /Bakset/CheckCustomer metoden OnPostConfirm bliver kaldt.
        public IActionResult OnPost()
        {
            //Hvis modellen ikke er valid, bliver siden vist igen.
            if (!ModelState.IsValid) { return Page(); }
            //Henter det næste ID fra CustomerService
            Customer.ID = CustomerService.GetNextID();
            //Opretter kunden i CustomerService
            CustomerService.CreateCustomer(Customer);
            //Hvis ordren bliver placeret, bliver der redirected til Success siden.
            if (OrderService.PlaceOrder(Customer.Email))
            {
                return RedirectToPage("/Basket/Success");
            }
            //Ellers bliver der redirected til Error siden.
            else { return RedirectToPage("/Error"); }
        }
        //Redirecter tilbage til Basket siden.
        public IActionResult OnPostCancel() { return RedirectToPage("/Basket/Basket"); }
    }
}
