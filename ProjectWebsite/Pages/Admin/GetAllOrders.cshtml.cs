using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Admin
{
    public class GetAllOrdersModel : PageModel
    {
		public OrderService OrderService;
		[BindProperty]
		public List<Models.Order> OrderList { get; set; }

		public GetAllOrdersModel(OrderService orderService)
		{
			OrderService = orderService;
		}
		public void OnGet() { OrderList = OrderService.OrderList; }
	}
}
