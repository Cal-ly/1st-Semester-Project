using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Models;
using ProjectWebsite.Services;
using System;

namespace ProjectWebsite.Pages.Events
{
    public class CreateEventModel : PageModel
    {
        public EventService service;
        [BindProperty] public Event Event { get; set; }

        public CreateEventModel(EventService eventService)
        {
            service = eventService;
        }
        public IActionResult OnGet() { return Page(); }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) { return Page(); }
            Event.ID = service.GetNextID();
            service.CreateEvent(Event);
            return RedirectToPage("GetAllEvents");
        }
		public IActionResult OnPostCancel() { return RedirectToPage("GetAllEvents"); }
	}
}
