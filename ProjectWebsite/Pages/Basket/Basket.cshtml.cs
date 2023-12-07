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
        public List<OrderLine> Kurv { get; set; }
        public double Total { get; set; }

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
            OrderLine temp = null;
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
            //hiver fat i instans feltet Total, der er en double, og nulstiller
            Total = 0;
            //foreach løkke der går igennem hver OrderLine i Kurv instans feltet
            //Kurv er en reference til Basket Listen i Order klassen
            foreach(OrderLine line in Kurv)
            {
                //Ordre linjes mængde bliver ganget med product prisen og lægges til Total
                Total += line.Amount * line.Product.Price;
            }
		}
    }
}
