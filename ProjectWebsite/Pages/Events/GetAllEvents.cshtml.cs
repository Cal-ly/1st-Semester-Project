using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Events
{
    public class GetAllEventsModel : PageModel
    {
        public EventService eventService;

        [BindProperty]
        public string SearchEvent { get; set; }
        [BindProperty]
        public List<Models.Event> EventList { get; set; }

        public GetAllEventsModel(EventService eventService)
        {
            this.eventService = eventService;
        }
        public void OnGet() { EventList = eventService.EventList; }

        public IActionResult OnPostEventSearch()
        {
            if (!ModelState.IsValid) { return Page(); }
            EventList = eventService.GetEventsByName(SearchEvent).ToList();
            return Page();
        }
		//public IActionResult OnPostCancel() { return RedirectToPage("GetAllEvents"); }
	}
}
