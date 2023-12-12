using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;
using ProjectWebsite.Models;
using ProjectWebsite.Repositories;

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
