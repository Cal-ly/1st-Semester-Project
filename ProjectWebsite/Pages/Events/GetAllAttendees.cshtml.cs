using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Events
{
    public class GetAllAttendeesModel : PageModel
    {
        public EventService eventService;
        [BindProperty] public Models.Event Event { get; set; }
        [BindProperty] public Models.Customer Customer { get; set; }


        public GetAllAttendeesModel(EventService eventService)
        {
            this.eventService = eventService;
        }
        public IActionResult OnGet(int id)
        {
            Event = eventService.GetEventByID(id);
            if (Event == null)
                return RedirectToPage("/Error"); //Define NotFound page
            return Page();
        }
        public IActionResult OnPost()
        {
            //if (!ModelState.IsValid) { return Page(); }

            eventService.UpdateEvent(Event);
            return RedirectToPage("GetAllEvents");
        }

        public IActionResult OnPostCancel() { return RedirectToPage("GetAllEvents"); }
    }
}
