using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;
using System.Reflection;

namespace ProjectWebsite.Pages.Events
{
    public class GetAllAttendeesModel : PageModel
    {
        public EventService eventService;
        public CustomerService customerService;
        [BindProperty] public Models.Event Event { get; set; }
        //[BindProperty] public Models.Customer Customer { get; set; }
        [BindProperty] public int CustomerID { get; set; }

		public GetAllAttendeesModel(EventService eventService, CustomerService customerService)
        {
            this.eventService = eventService;
            this.customerService = customerService;
        }
        public IActionResult OnGet(int id)
        {
            Event = eventService.GetEventByID(id);
			Event.EventAttendees = eventService.GetEventAttendees(id);
            if (Event == null)
            {
			    return RedirectToPage("/Error"); //Define NotFound page
			}
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
            return Page();
		}

		public IActionResult OnPostAddAttendee(int id)
		{
			//if (!ModelState.IsValid) { return Page(); }
			Event = eventService.GetEventByID(id);
			var retrievedCustomer = customerService.GetCustomerByID(CustomerID);
			Models.Customer customerToAttend = new()
			{
				ID = retrievedCustomer.ID,
				Name = retrievedCustomer.Name,
				Address = retrievedCustomer.Address,
				Email = retrievedCustomer.Email,
				PhoneNumber = retrievedCustomer.PhoneNumber
			};
			if (customerToAttend != null)
			{
				Event.EventAttendees.Add(customerToAttend);
			}
			Event = eventService.UpdateEvent(Event);
			return Page();
		}

		public IActionResult OnPostCancel() { return RedirectToPage("GetAllEvents"); }
    }
}
