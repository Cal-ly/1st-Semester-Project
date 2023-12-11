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

        public int addedIDToBasket { get; set; }

        public GetAllEventsModel(EventService eventService, ProductService ProductService)
        {
            EventService = eventService;
            this.ProductService = ProductService;
        }
        public void OnGet() 
        {
            addedIDToBasket = 0;
            EventList = EventService.EventList; 
        }

        public IActionResult OnPostEventSearch()
        {
            if (!ModelState.IsValid) 
            { 
                return Page(); 
            }
            addedIDToBasket = 0;
            EventList = EventService.GetEventsByName(SearchEvent).ToList();
            return Page();
        }

        public IActionResult OnPostAddToBasket(int ID)
        {
            int newID;
            if (Order.Basket?.Count == null || Order.Basket?.Count == 0)
            { 
                newID = 1; 
            }
            else 
            { 
                newID = Order.Basket.Max(p => p.ID) + 1; 
            }

            Order.Basket.Add(new()
            {
                Product = ProductService.GetProduct(ID + 9000),
                Amount = 1,
                ID = newID
                
            }) ;
            addedIDToBasket = ID;
            EventList = EventService.EventList;
            return Page();
        }
	}
}
