using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Events
{
    public class UpdateEventModel : PageModel
    {
        public EventService EventService;
        public ProductService ProductService;
        [BindProperty] public Models.Event Event { get; set; }
        [BindProperty] public Models.Product ProductEvent { get; set; }
        public UpdateEventModel(EventService eventService, ProductService productService)
        {
            EventService = eventService;
            ProductService = productService;
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
        public IActionResult OnPost()
        {
			EventService.UpdateEvent(Event);
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
