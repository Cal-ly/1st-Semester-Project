using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Events
{
    public class GetAllEventsModel : PageModel
    {
        public EventService service;
        [BindProperty] public string SearchEvent { get; set; }
        [BindProperty] public List<Models.Event> EventList { get; set; }

        public GetAllEventsModel(EventService eventService)
        {
            service = eventService;
        }
        public void OnGet() { EventList = service.EventList; }

        public IActionResult OnPostEventSearch()
        {
            if (!ModelState.IsValid) { return Page(); }
            EventList = service.GetEventsByName(SearchEvent).ToList();
            return Page();
        }
    }
}
