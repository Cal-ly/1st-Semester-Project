using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Events
{
    public class DeleteEventModel : PageModel
    {
        private EventService EventService;
        [BindProperty] public Models.Event Event { get; set; }

        public DeleteEventModel(EventService eventService)
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
        public IActionResult OnPost()
        {
            if (!EventService.DeleteEvent(Event.ID))
            {
                return RedirectToPage("/Error");
            }

            return RedirectToPage("GetAllEvents");
        }
        public IActionResult OnPostCancel()
        {
            return RedirectToPage("GetAllEvents");
        }
    }
}
