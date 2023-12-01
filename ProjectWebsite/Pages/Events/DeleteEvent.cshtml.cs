using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Events
{
    public class DeleteEventModel : PageModel
    {
        public EventService service;
        [BindProperty] public Models.Event Event { get; set; }

        public DeleteEventModel(EventService eventService)
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
			if (!service.DeleteEvent(Event.ID))
				return RedirectToPage("/Error"); //Define NotFound page

			return RedirectToPage("GetAllEvents");
		}
		public IActionResult OnPostCancel() { return RedirectToPage("GetAllEvents"); }
	}
}
