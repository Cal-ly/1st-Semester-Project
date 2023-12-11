using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Admin
{
    public class GetAllOrdersModel : PageModel
    {
        private OrderService OrderService;

        [BindProperty]
        public List<Models.Order> OrderList { get; set; }

        public GetAllOrdersModel(OrderService orderService)
        {
            OrderService = orderService;
        }
        public IActionResult OnGet()
        {
            OrderList = OrderService.OrderList;
            if (OrderList == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
    }
}
