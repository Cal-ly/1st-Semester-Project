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
        [BindProperty] public Models.Customer Customer { get; set; }
        [BindProperty] public int CustomerID { get; set; }

		public GetAllAttendeesModel(EventService eventService, CustomerService customerService)
        {
            this.eventService = eventService;
            this.customerService = customerService;
        }
        public IActionResult OnGet(int id)
        {
            Event = eventService.GetEventByID(id);
            if (Event == null)
            {
			    return RedirectToPage("/Error"); //Define NotFound page
			}
			return Page();
        }
		public IActionResult OnPostDeleteAttendee(int eventid, int customerid)
		{
			//if (!ModelState.IsValid) { return Page(); }
			Event = eventService.GetEventByID(eventid);
			Customer = Event.EventAttendees.FirstOrDefault(c => c.ID == customerid);
			if (Customer != null)
			{
				if (Event.EventAttendees.Remove(Customer))
				{
					eventService.UpdateEvent(Event);
				}
				else
				{
					Console.WriteLine("Customer not removed");
				}
			}
			return Page();
		}

		public IActionResult OnPostAddAttendee(int id)
		{
			//if (!ModelState.IsValid) { return Page(); }
			Event = eventService.GetEventByID(id);
			Customer = customerService.GetCustomerByID(CustomerID);
			Models.Customer customerToAttend = new()
			{
				ID = Customer.ID,
				Name = Customer.Name,
				Address = Customer.Address,
				Email = Customer.Email,
				PhoneNumber = Customer.PhoneNumber
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
