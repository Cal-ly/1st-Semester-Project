using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Models;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Basket
{
    public class EditAmountModel : PageModel
    {
        public OrderLine OrderLine { get; set; }
        private OrderService OrderService { get; set; }

        public EditAmountModel(OrderService orderService)
        {
            Console.WriteLine("we loaded");
            OrderService = orderService;
        }

        public IActionResult OnGet()
        {
            Console.WriteLine("hello");
            
            return RedirectToPage("Basket");
        }

        public IActionResult OnGet(int newAmount, int orderLineID)
        {
            Console.WriteLine(newAmount);
            OrderService.UpdateOrderAmount(newAmount, orderLineID);
            return RedirectToPage("Basket");
        }
    }
}
