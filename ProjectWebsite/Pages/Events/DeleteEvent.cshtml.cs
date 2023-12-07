using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Events
{
    public class DeleteEventModel : PageModel
    {
        public EventService eventService;
        [BindProperty] public Models.Event Event { get; set; }

        public DeleteEventModel(EventService eventService)
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
            if (!eventService.DeleteEvent(Event.ID)) { return RedirectToPage("/Error"); }

            return RedirectToPage("GetAllEvents");
		}
		public IActionResult OnPostCancel() { return RedirectToPage("GetAllEvents"); }
	}
}
