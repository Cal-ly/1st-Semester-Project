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
        public List<OrderLine> Kurv { get; set; }
        public double Total { get; set; }

        public KurvModel(OrderService orderService)
        {
            OrderService = orderService;
        }

        public IActionResult OnGet()
        {
            Kurv = Order.Basket;
            Total = OrderService.CalculateTotal(Kurv);
            return Page();
        }

        public IActionResult OnPostForward()
        {
            Kurv = Order.Basket;
            Console.WriteLine(Kurv);
            return RedirectToPage("/Basket/CheckCustomer");
        }

        public IActionResult OnPostPlus(int ID)
        {
            Kurv = Order.Basket;
            foreach (OrderLine orderLine in Kurv)
            {
                if (ID == orderLine.ID)
                {
                    orderLine.Amount++;
                }
            }
            Kurv = Order.Basket;
            Total = OrderService.CalculateTotal(Kurv);
            return Page();
        }
        public IActionResult OnPostMinus(int ID)
        {
            OrderLine temp = null;
            Kurv = Order.Basket;
            foreach (OrderLine orderLine in Kurv)
            {
                if (ID == orderLine.ID)
                {
                    orderLine.Amount--;
                    temp = orderLine;
                }
            }
            if (temp.Amount == 0)
            {
                Kurv.Remove(temp);

            }
            Kurv = Order.Basket;
            Total = OrderService.CalculateTotal(Kurv);
            return Page();
        }
    }
}
