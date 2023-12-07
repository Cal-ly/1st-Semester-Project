using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;

namespace ProjectWebsite.Pages.Events
{
    public class UpdateEventModel : PageModel
    {
        public EventService eventService;
        public ProductService productService;
        [BindProperty] public Models.Event Event { get; set; }
        [BindProperty] public Models.Product ProductEvent { get; set; }
        public UpdateEventModel(EventService eventService, ProductService productService)
        {
            this.eventService = eventService;
            this.productService = productService;
        }
        public IActionResult OnGet(int id)
        {
            Event = eventService.GetEventByID(id);
            if (Event == null)
                return RedirectToPage("/NotFound");
            return Page();
        }
        public IActionResult OnPost()
        {
			eventService.UpdateEvent(Event);
            ProductEvent = eventService.ConvertEventToProduct(Event);
            productService.CreateProduct(ProductEvent);
            return RedirectToPage("GetAllEvents");
        }
		public IActionResult OnPostCancel() { return RedirectToPage("GetAllEvents"); }
    }
}
