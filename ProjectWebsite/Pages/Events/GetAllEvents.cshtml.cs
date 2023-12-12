using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Models;
using ProjectWebsite.Services;
using System.Linq;

namespace ProjectWebsite.Pages.Events
{
    public class GetAllEventsModel : PageModel
    {
        private EventService EventService { get; set; }
        private ProductService ProductService { get; set; }

        [BindProperty]
        public string SearchEvent { get; set; }
        [BindProperty]
        public List<Event> EventList { get; set; }

        public int AddedIDToBasket { get; set; }

        public GetAllEventsModel(EventService eventService, ProductService productService)
        {
            EventService = eventService;
            ProductService = productService;
        }
        public void OnGet()
        {
            AddedIDToBasket = 0;
            EventList = EventService.EventList;
        }

        public IActionResult OnPostEventSearch()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            AddedIDToBasket = 0;
            EventList = EventService.GetEventsByName(SearchEvent).ToList();
            return Page();
        }

        public IActionResult OnPostAddToBasket(int ID)
        {
            int newID;
            if (Order.Basket?.Count != null || Order.Basket?.Count != 0)
            {
                newID = Order.Basket!.Max(p => p.ID) + 1;
            }
            else
            {
                newID = 1;
            }

            Order.Basket?.Add(new()
            {
                Product = ProductService.GetProduct(ID),
                Amount = 1,
                ID = newID
            }) ;
            AddedIDToBasket = ID;
            return Page();
        }
	}
}
