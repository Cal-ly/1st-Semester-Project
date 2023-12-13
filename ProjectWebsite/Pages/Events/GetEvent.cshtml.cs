using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Models;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Events
{
    public class GetEventModel : PageModel
    {
        private EventService EventService { get; set; }
        public Event Event { get; set; }

        public GetEventModel(EventService eventService)
        {
            EventService = eventService;
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
    }
}
