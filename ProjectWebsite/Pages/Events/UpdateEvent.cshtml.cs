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
        [BindProperty] public Models.Event Event { get; set; }

        public UpdateEventModel(EventService eventService)
        {
            this.eventService = eventService;
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
            //if (!ModelState.IsValid) { return Page(); }
			eventService.UpdateEvent(Event);
            return RedirectToPage("GetAllEvents");
        }
		public IActionResult OnPostCancel() { return RedirectToPage("GetAllEvents"); }
    }
}
