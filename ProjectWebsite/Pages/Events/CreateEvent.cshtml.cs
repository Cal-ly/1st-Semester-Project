using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Events
{
    public class CreateEventModel : PageModel
    {
        public EventService eventService;
        [BindProperty] public Models.Event Event { get; set; }

        public CreateEventModel(EventService eventService)
        {
            this.eventService = eventService;
        }
        public IActionResult OnGet() { return Page(); }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) { return Page(); }
            Event.ID = eventService.GetNextID();
            eventService.CreateEvent(Event);
            return RedirectToPage("GetAllEvents");
        }

		public IActionResult OnPostCancel() { return RedirectToPage("GetAllEvents"); }
	}
}
