using Microsoft.AspNetCore.Mvc.Diagnostics;
using ProjectWebsite.Models;
using ProjectWebsite.Services;
using System.ComponentModel;

namespace ProjectWebsite.Repositories
{
    public class EventRepository
    {
        public static int NextID = 1;
        public List<Event> EventList { get; set; }
        private JsonEventService JsonEventService { get; set; }
        public EventRepository(JsonEventService jsonFileEventService)
        {
            JsonEventService = jsonFileEventService;
            EventList = JsonEventService.GetJsonItems().ToList();
        }

		public int GetNextID()
        {
            if(EventList.Count == 0) { return 1; }
            int nextID = EventList.Max(c => c.ID) + 1;
            if (nextID <= NextID) { nextID = NextID + 1; }
            NextID = nextID;
            return nextID;
        }
        public void CreateEvent(Event eventIn)
        {
            if (eventIn == null)
            {
                throw new ArgumentNullException(nameof(eventIn));
            }
            EventList.Add(eventIn);
            JsonEventService.SaveJsonItems(EventList);
        }
        public Event UpdateEvent(Event incomingE)
        {
            foreach (Event outgoingE in EventList)
            {
                if (outgoingE.ID == incomingE.ID)
                {
					outgoingE.EventName = incomingE.EventName;
					outgoingE.EventLocation = incomingE.EventLocation;
                    outgoingE.EventDateTime = incomingE.EventDateTime;
                    outgoingE.EventDuration = incomingE.EventDuration;
					outgoingE.EventDescription = incomingE.EventDescription;
                    outgoingE.EventCost = incomingE.EventCost;
					outgoingE.EventAttendees = incomingE.EventAttendees;
                    outgoingE.EventCapacity = incomingE.EventCapacity;
					outgoingE.EventOrganizer = incomingE.EventOrganizer;
                    //outgoingE.EventOrganizerEmail = incomingE.EventOrganizerEmail ?? outgoingE.EventOrganizerEmail;
                    //outgoingE.EventOrganizerPhone = incomingE.EventOrganizerPhone ?? outgoingE.EventOrganizerPhone;
                    //outgoingE.EventOrganizerWebsite = incomingE.EventOrganizerWebsite ?? outgoingE.EventOrganizerWebsite;

		            JsonEventService.SaveJsonItems(EventList);
                }
            }
            return incomingE; //TODO: Display updated event -splash screen?
        }
        public Event UpdateEventAttendees(Event incomingE)
        {
			foreach (Event outgoingE in EventList)
            {
				if (outgoingE.ID == incomingE.ID)
                {
					outgoingE.EventAttendees = incomingE.EventAttendees;
					JsonEventService.SaveJsonItems(EventList);
				}
			}
			return incomingE; //TODO: Display updated eventAttendee -splash screen?
		}
        public bool DeleteEvent(int eventID)
        {
            Event eventToBeDeleted = GetEventByID(eventID);
            if (eventToBeDeleted != null)
            {
                EventList.Remove(eventToBeDeleted);
                JsonEventService.SaveJsonItems(EventList);
                return true;
            }
            return false;
        }
        public List<Customer> GetEventAttendees(int eventID)
        {
			foreach (Event e in EventList)
				if (e.ID == eventID)
					return e.EventAttendees;
			return null;
		}
        public Event GetEventByID(int eventID)
        {
            foreach (Event e in EventList)
                if (e.ID == eventID)
                    return e;
            return null;
        }
        public List<Event> GetEventsByName(string searchString)
        {
            List<Event> searchResult = new();
            foreach (Event e in EventList)
            {
                if (e.EventName.ToLower().Contains(searchString.ToLower()))
                    searchResult.Add(e);
            }
            return searchResult;
        }
        public Event GetEventByLocation(string location)
        {
            foreach (Event e in EventList)
                if (e.EventLocation.ToLower().Contains(location.ToLower()))
                    return e;
            return null;
        }
        public List<Event> GetEventsByDate(DateTime date)
        {
			List<Event> searchResult = new();
			foreach (Event e in EventList)
            {
				if (e.EventDateTime.Date == date.Date)
					searchResult.Add(e);
			}
			return searchResult;
		}
    }
}
