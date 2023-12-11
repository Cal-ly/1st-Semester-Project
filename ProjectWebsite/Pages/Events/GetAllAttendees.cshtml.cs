using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;
using System.ComponentModel.DataAnnotations;

namespace ProjectWebsite.Pages.Events
{
    public class GetAllAttendeesModel : PageModel
    {
        private EventService EventService { get; set; }
        private CustomerService CustomerService { get; set; }
        public Models.Event Event { get; set; }
        public Models.Customer Customer { get; set; }
        [BindProperty]
        [Range(0, int.MaxValue)]
        public int CustomerID { get; set; }
        public Models.Product ProductEvent { get; set; }

        public GetAllAttendeesModel(EventService eventService, CustomerService customerService)
        {
            this.EventService = eventService;
            this.CustomerService = customerService;
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

        public IActionResult OnPostDeleteAttendee(int eventid, int customerid)
        {
            Event = EventService.GetEventByID(eventid);
            Customer = Event.Attendees.FirstOrDefault(c => c.ID == customerid);
            if (Customer != null)
            {
                if (Event.Attendees.Remove(Customer))
                {
                    EventService.UpdateEvent(Event);
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
            if (!ModelState.IsValid)
            {
                Event = EventService.GetEventByID(id);
                return Page();
            }
            Event = EventService.GetEventByID(id);
            Customer = CustomerService.GetCustomerByID(CustomerID);
            if (Customer == null)
            {
                Event = EventService.GetEventByID(id);
                return Page();
            }
            Models.Customer customerToAttend = new()
            {
                ID = Customer.ID,
                Name = Customer.Name,
                Address = Customer.Address,
                Email = Customer.Email,
                PhoneNumber = Customer.PhoneNumber
            };
            Event.Attendees.Add(customerToAttend);
            Event = EventService.UpdateEvent(Event);
            return Page();
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("GetAllEvents");
        }
    }
}
