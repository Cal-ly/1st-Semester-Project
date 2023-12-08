using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Models;
using ProjectWebsite.Services;
using System.Linq;

namespace ProjectWebsite.Pages.Events
{
    public class GetAllEventsModel : PageModel
    {
        public EventService EventService;
        public ProductService ProductService;

        [BindProperty]
        public string SearchEvent { get; set; }
        [BindProperty]
        public List<Event> EventList { get; set; }

        public GetAllEventsModel(EventService eventService, ProductService ProductService)
        {
            EventService = eventService;
            this.ProductService = ProductService;
        }
        public void OnGet() 
        { 
            EventList = EventService.EventList; 
        }

        public IActionResult OnPostEventSearch()
        {
            if (!ModelState.IsValid) 
            { 
                return Page(); 
            }
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
            EventList = EventService.EventList;
            return Page();
        }
	}
}
