using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Admin
{
    public class DeleteOrderModel : PageModel
    {
        private OrderService OrderService;

        [BindProperty]
        public Models.Order Order { get; set; }

        public DeleteOrderModel(OrderService orderService)
        {
            OrderService = orderService;
        }

        public IActionResult OnGet(int id)
        {
            Order = OrderService.GetOrder(id);
            if (Order == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            //metoden bliver k�rt indeni if-statement
            if (!OrderService.DeleteOrder(Order.ID))
            {
                return RedirectToPage("/NotFound");
            }

            return RedirectToPage("GetAllOrders");
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("GetAllOrders");
        }
    }
}
