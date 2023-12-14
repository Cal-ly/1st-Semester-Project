using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Models;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Events
{
    public class GetEventModel : PageModel
    {
        private EventService EventService { get; set; }
        private ProductService ProductService { get; set; }
        private OrderService OrderService { get; set; }
        [BindProperty]
        public Event Event { get; set; }

        public GetEventModel(EventService eventService, ProductService productService, OrderService orderService)
        {
            EventService = eventService;
            ProductService = productService;
            OrderService = orderService;
        }

        public IActionResult OnGet(int id)
        {
            Event = EventService.GetEventByID(id);
            if (Event == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        public IActionResult OnPostAddEventToBasket(int postid)
        {
            int newID = (Order.Basket?.Count == null || Order.Basket?.Count == 0) ? 1 : Order.Basket!.Max(p => p.ID) + 1;

            Order.Basket?.Add(new()
            {
                Product = ProductService.GetProduct(postid),
                Amount = 1,
                ID = newID
            });

            Event = EventService.GetEventByID(postid);

            return Page();
        }
    }
}
