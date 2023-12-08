using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;
using System.ComponentModel.DataAnnotations;

namespace ProjectWebsite.Pages.Events
{
    public class GetAllAttendeesModel : PageModel
    {
        public EventService eventService;
        public CustomerService customerService;
         public Models.Event Event { get; set; }
         public Models.Customer Customer { get; set; }
        [BindProperty]
        [Range(0, int.MaxValue)]
        public int CustomerID { get; set; }
		 public Models.Product ProductEvent { get; set; }

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
                return RedirectToPage("/NotFound");
            }
			return Page();
        }

		public IActionResult OnPostDeleteAttendee(int eventid, int customerid)
		{ 
			Event = eventService.GetEventByID(eventid);
			Customer = Event.Attendees.FirstOrDefault(c => c.ID == customerid);
			if (Customer != null)
			{
				if (Event.Attendees.Remove(Customer))
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
            if (!ModelState.IsValid) {
                Event = eventService.GetEventByID(id);
                return Page(); 
			}
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
			Event.Attendees.Add(customerToAttend);
			Event = eventService.UpdateEvent(Event);
			return Page();
		}

		public IActionResult OnPostCancel() 
		{ 
			return RedirectToPage("GetAllEvents"); 
		}
    }
}
