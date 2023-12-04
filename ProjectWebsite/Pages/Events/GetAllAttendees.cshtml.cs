using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;
using System.Reflection;

namespace ProjectWebsite.Pages.Events
{
    public class GetAllAttendeesModel : PageModel
    {
        public EventService eventService;
        [BindProperty] public Models.Event Event { get; set; }
        [BindProperty] public Models.Customer Customer { get; set; }
        [BindProperty] public int CustomerID { get; set; }

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
		public IActionResult OnPostDeleteAttendee(int id)
		{
			//if (!ModelState.IsValid) { return Page(); }
			var customerToRemove = Event.EventAttendees.Find(c => c.ID == id);
			if (customerToRemove != null)
			{
				Event.EventAttendees.Remove(customerToRemove);
			}
			eventService.UpdateEvent(Event);
			return RedirectToPage("GetAllAttendees");
		}

        public IActionResult OnPostAddAttendee()
        {
			//if (!ModelState.IsValid) { return Page(); }
			//var customerToAdd = eventService.GetCustomerByID(Customer.ID);
			//if (customerToAdd != null)
   //         {
			//	Event.EventAttendees.Add(customerToAdd);
			//}
			//eventService.UpdateEvent(Event);
			return RedirectToPage("GetAllAttendees");
		}

        public IActionResult OnPostCancel() { return RedirectToPage("GetAllAttendees"); }
    }
}
