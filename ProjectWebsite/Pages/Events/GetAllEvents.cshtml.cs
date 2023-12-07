using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Models;
using ProjectWebsite.Services;
using System.Linq;

namespace ProjectWebsite.Pages.Events
{
    public class GetAllEventsModel : PageModel
    {
        public EventService eventService;
        public ProductService ProductService;

        [BindProperty]
        public string SearchEvent { get; set; }
        [BindProperty]
        public List<Models.Event> EventList { get; set; }

        public GetAllEventsModel(EventService eventService, ProductService ProductService)
        {
            this.eventService = eventService;
            this.ProductService = ProductService;
        }
        public void OnGet() { EventList = eventService.EventList; }

        public IActionResult OnPostEventSearch()
        {
            if (!ModelState.IsValid) { return Page(); }
            EventList = eventService.GetEventsByName(SearchEvent).ToList();
            return Page();
        }

        public IActionResult OnPostAddToBasket(int ID)
        {
            Console.WriteLine(ID);
            int newID;
            if (Order.basket?.Count == null || Order.basket?.Count == 0)
            { newID = 1; }
            else { newID = Order.basket.Max(p => p.ID) + 1; }

            Order.basket.Add(new() { Product = ProductService.GetProduct(ID+9000), Amount=1, ID = newID });
            Console.WriteLine(Order.basket.ElementAt(Order.basket.Count-1));
            return Page();
        }
		//public IActionResult OnPostCancel() { return RedirectToPage("GetAllEvents"); }
	}
}
