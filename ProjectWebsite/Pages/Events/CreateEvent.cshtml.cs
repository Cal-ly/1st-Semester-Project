using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;
using ProjectWebsite.Models;

namespace ProjectWebsite.Pages.Events
{
    public class CreateEventModel : PageModel
    {
        public EventService eventService;
		public ProductService productService;
        [BindProperty] public Models.Event Event { get; set; }
        [BindProperty] public Models.Product ProductEvent { get; set; }

		public CreateEventModel(EventService eventService, ProductService productService)
        {
            this.eventService = eventService;
			this.productService = productService;
		}
        public IActionResult OnGet() 
        { 
            return Page(); 
        }

        public IActionResult OnPost()
        {
            Event.ID = eventService.GetNextID();
            eventService.CreateEvent(Event);
			ProductEvent = eventService.ConvertEventToProduct(Event);
            productService.CreateProduct(ProductEvent);
			return RedirectToPage("GetAllEvents");
        }
		public IActionResult OnPostCancel() 
        { 
            return RedirectToPage("GetAllEvents"); 
        }
	}
}
