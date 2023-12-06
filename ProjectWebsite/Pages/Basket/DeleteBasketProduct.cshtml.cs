using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Basket
{
    public class DeleteBasketProductModel : PageModel
    {
        private OrderService OrderService { get; set; }
        public DeleteBasketProductModel(OrderService orderService)
        {
            OrderService = orderService;
        }

        public IActionResult OnGet(int id)
        {
            OrderService.DeleteFromBasket(id);
            return RedirectToPage("Basket");
        }
    }
}