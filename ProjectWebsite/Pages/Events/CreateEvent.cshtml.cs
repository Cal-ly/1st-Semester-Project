using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;
using ProjectWebsite.Models;

namespace ProjectWebsite.Pages.Events
{
    public class CreateEventModel : PageModel
    {
        private EventService EventService { get; set; }
		private ProductService ProductService { get; set; }
        [BindProperty] public Models.Event Event { get; set; }
        [BindProperty] public Models.Product ProductEvent { get; set; }

		public CreateEventModel(EventService eventService, ProductService productService)
        {
            this.EventService = eventService;
			this.ProductService = productService;
		}
        public IActionResult OnGet() 
        { 
            return Page(); 
        }

        public IActionResult OnPost()
        {
            Event.ID = EventService.GetNextID();
            EventService.CreateEvent(Event);
			ProductEvent = EventService.ConvertEventToProduct(Event);
            ProductService.CreateProduct(ProductEvent);
			return RedirectToPage("GetAllEvents");
        }
		public IActionResult OnPostCancel() 
        { 
            return RedirectToPage("GetAllEvents"); 
        }
	}
}
