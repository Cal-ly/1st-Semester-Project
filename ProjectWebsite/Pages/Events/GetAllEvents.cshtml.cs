using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Models;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Events
{
    public class GetAllEventsModel : PageModel
    {
        private EventService EventService { get; set; }
        private ProductService ProductService { get; set; }
        private OrderService OrderService { get; set; }

        [BindProperty]
        public string SearchEvent { get; set; }
        [BindProperty]
        public List<Event> EventList { get; set; }
        [BindProperty]
        public Event Event { get; set; }

        public int AddedIDToBasket { get; set; }

        public GetAllEventsModel(EventService eventService, ProductService productService, OrderService orderService)
        {
            EventService = eventService;
            ProductService = productService;
            OrderService = orderService;
        }
        public void OnGet()
        {
            AddedIDToBasket = 0;
            EventList = EventService.EventList;
        }

        public void OnPostEventSearch()
        {
            EventList = EventService.GetEventsByName(SearchEvent).ToList();
        }

        public IActionResult OnPostAddToBasket(int ID)
        {
            int newID = (Order.Basket?.Count == null || Order.Basket?.Count == 0) ? 1 : Order.Basket!.Max(p => p.ID) + 1;

            Order.Basket?.Add(new()
            {
                Product = ProductService.GetProduct(ID),
                Amount = 1,
                ID = newID
            });

            AddedIDToBasket = ID;
            EventList = EventService.EventList;
            return Page();
        }
    }
}
