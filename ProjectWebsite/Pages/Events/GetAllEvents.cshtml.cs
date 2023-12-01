using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Models;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Events
{
    public class GetAllEventsModel : PageModel
    {
        public EventService service;
        [BindProperty] public Event Event { get; set; }
        [BindProperty] public string SearchEvent { get; set; }
        [BindProperty] public List<Event> EventList { get; set; }

        public GetAllEventsModel(EventService eventService)
        {
            service = eventService;
        }
        public IActionResult OnGet() { return Page(); }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) { return Page(); }
            EventList = service.GetEventsByName(SearchEvent).ToList();
            return Page();
        }
    }
}
