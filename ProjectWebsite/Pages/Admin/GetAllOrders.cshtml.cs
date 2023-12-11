using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Admin
{
    public class GetAllOrdersModel : PageModel
    {
		public OrderService OrderService;

		public GetAllOrdersModel(OrderService orderService)
		{
			OrderService = orderService;
		}
		public IActionResult OnGet()
		{
            if (OrderService.OrderList == null) 
			{ 
				return RedirectToPage("/NotFound"); 
			}
			return Page();
        }
	}
}
