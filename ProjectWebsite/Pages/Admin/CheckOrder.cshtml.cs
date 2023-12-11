using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Admin
{
    public class CheckOrderModel : PageModel
    {
		private OrderService OrderService { get; set; }
		public CheckOrderModel(OrderService orderService)
		{
			OrderService = orderService;
		}

		public IActionResult OnGet(int id)
		{
			OrderService.FinishOrder(id);
            if (OrderService == null) { return RedirectToPage("/NotFound"); }
            return RedirectToPage("GetAllOrders");
		}
	}
}
