using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Models;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Kurv
{
    public class KurvModel : PageModel
    {
        private OrderService OrderService { get; set; }
        [BindProperty]
        public int Amount { get; set; }
        public double Total { get; set; }
        
        public KurvModel(OrderService orderService)
        {
            OrderService = orderService;
        }

        public IActionResult OnGet()
        {
            Total = OrderService.CalculateTotal(Order.Basket);
            return Page();
        }

        public IActionResult OnPostForward()
        {
            return RedirectToPage("/Basket/CheckCustomer");
        }

        public IActionResult OnPostPlus(int ID)
        {
            foreach (OrderLine orderLine in Order.Basket)
            {
                if (ID == orderLine.ID)
                {
                    orderLine.Amount++;
                }
            }
            Total = OrderService.CalculateTotal(Order.Basket);
            return Page();
        }
        public IActionResult OnPostMinus(int ID)
        {
            OrderLine temp = null;
            foreach (OrderLine orderLine in Order.Basket)
            {
                if (ID == orderLine.ID)
                {
                    orderLine.Amount--;
                    temp = orderLine;
                }
            }
            if (temp.Amount == 0)
            {
                Order.Basket.Remove(temp);

            }
            Total = OrderService.CalculateTotal(Order.Basket);
            return Page();
        }
    }
}
