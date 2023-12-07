using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Basket
{
    public class CheckCustomerModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }
        private CustomerService CustomerService { get; set; }
        private OrderService OrderService { get; set; }
        public CheckCustomerModel(CustomerService customerService, OrderService orderService)
        {
            CustomerService = customerService;
            OrderService = orderService;
        }
        public void OnGet(){}
        public IActionResult OnPostConfirm(string email)
        {
            foreach (var customer in CustomerService.CustomerList)
            {
                if (customer.Email == email)
                {
                    if (OrderService.PlaceOrder(email))
                    { 
                        return RedirectToPage("/Basket/Success"); 
                    }
                    else 
                    { 
                        return RedirectToPage("/Error"); 
                    }
                }
            }
            return RedirectToPage("/Customer/NewCustomer");
        }
        public IActionResult OnPostCancel() 
        { 
            return RedirectToPage("/Basket/Basket"); 
        }
    }
}
