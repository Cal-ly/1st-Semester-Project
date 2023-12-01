using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;

namespace ProjectWebsite.Pages.Events
{
    public class UpdateEventModel : PageModel
    {
        public EventService service;
        [BindProperty] public Models.Event Event { get; set; }

        public UpdateEventModel(EventService eventService)
        {
            service = eventService;
        }
        public IActionResult OnGet(int id)
        {
            Event = service.GetEventByID(id);
            if (Event == null)
                return RedirectToPage("/Error"); //Define NotFound page
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) { return Page(); }
			service.UpdateEvent(Event);
            return RedirectToPage("GetAllEvents");
        }

		public string DisplayEventProperties()
		{
            string EventString = Event.ToString();
            return EventString;
		}


		public IActionResult OnPostCancel() { return RedirectToPage("GetAllEvents"); }
    }
}
