using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Admin
{
	public class DeleteOrderModel : PageModel
	{
		public OrderService OrderService;

		[BindProperty]
		public Models.Order Order{ get; set; }

		public DeleteOrderModel(OrderService orderService)
		{
			OrderService = orderService;
		}

		public IActionResult OnGet(int id)
		{
			Order = OrderService.GetOrder(id);
			if (Order == null)
				return RedirectToPage("/Error"); //Define NotFound page
			return Page();
		}

		public IActionResult OnPost()
		{
			//metoden bliver kørt indeni if-statement
			if (!OrderService.DeleteOrder(Order.ID))
				return RedirectToPage("/Error"); //Define NotFound page

			return RedirectToPage("GetAllOrders");
		}
		public IActionResult OnPostCancel() { return RedirectToPage("GetAllOrders"); }
	}
}
