using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Models;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Kurv
{
    public class KurvModel : PageModel
    {
        [BindProperty]
        public int Amount { get; set; }

        [BindProperty]
        public string Email { get; set; }

        public List<OrderLine> Kurv { get; set; }
        public double Total { get; set; }
        private OrderService OrderService { get; set; }

        public KurvModel(OrderService orderService)
		{
            OrderService = orderService;
        }

		public IActionResult OnGet()
        {
            Kurv = Order.basket;
            TempTotal();
            return Page();
        }

        public IActionResult OnPostVidere()
        {
            
            
            return RedirectToPage("/Basket/CheckCustomer");
        }

        public IActionResult OnPost()
        {
            Console.WriteLine("testing 45");
            
            return Page();
        }

        public IActionResult OnPostPlus(int ID)
        {
            Kurv = Order.basket;
            foreach (OrderLine orderLine in Kurv)
            {
                
                if (ID == orderLine.ID)
                {
                    
                    orderLine.Amount++;
                    
                }
            }
            Kurv = Order.basket;
            TempTotal();
            return Page();
        }
        public IActionResult OnPostMinus(int ID)
        {
            OrderLine temp =null;
            Kurv = Order.basket;
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
            Kurv = Order.basket;
            TempTotal();
            return Page();
        }

        public void TempTotal()
        {
            Total = 0;
            foreach(var line in Kurv)
            {
                Total += line.Amount * line.Product.Price;
            }
		}

        //public IActionResult OnPostCancel()
        //{
        //    Console.WriteLine("It works definitely");
        //    return Page();
        //}
    }
}
