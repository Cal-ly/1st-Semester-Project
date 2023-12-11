using ProjectWebsite.Models;
using ProjectWebsite.Services;

namespace ProjectWebsite.Repositories
{
    public class EventRepository
    {
        private static int nextID = 1;

        public List<Event> EventList { get; set; }

        private JsonEventService JsonEventService { get; set; }

        public EventRepository(JsonEventService jsonFileEventService)
        {
            JsonEventService = jsonFileEventService;
            EventList = JsonEventService.GetJsonItems().ToList();
        }

        public int GetNextID()
        {
            if (EventList.Count == 0)
            {
                return 1;
            }
            int nextID = EventList.Max(c => c.ID) + 1;
            if (nextID <= EventRepository.nextID)
            {
                nextID = EventRepository.nextID + 1;
            }
            EventRepository.nextID = nextID;
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
                    outgoingE.Name = incomingE.Name;
                    outgoingE.Location = incomingE.Location;
                    outgoingE.DateTime = incomingE.DateTime;
                    outgoingE.Duration = incomingE.Duration;
                    outgoingE.Description = incomingE.Description;
                    outgoingE.Cost = incomingE.Cost;
                    outgoingE.Attendees = incomingE.Attendees;
                    outgoingE.Capacity = incomingE.Capacity;
                    outgoingE.Organizer = incomingE.Organizer;

                    JsonEventService.SaveJsonItems(EventList);
                }
            }
            return incomingE;
        }

        public Event UpdateEventAttendees(Event incomingE)
        {
            foreach (Event outgoingE in EventList)
            {
                if (outgoingE.ID == incomingE.ID)
                {
                    outgoingE.Attendees = incomingE.Attendees;
                    JsonEventService.SaveJsonItems(EventList);
                }
            }
            return incomingE;
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
            {
                if (e.ID == eventID)
                {
                    return e.Attendees;
                }
            }
            return null;
        }

        public Event GetEventByID(int eventID)
        {
            foreach (Event e in EventList)
            {
                if (e.ID == eventID)
                {
                    return e;
                }
            }
            return null;
        }

        public List<Event> GetEventsByName(string searchString)
        {
            List<Event> searchResult = new();
            foreach (Event e in EventList)
            {
                if (e.Name.ToLower().Contains(searchString.ToLower()))
                {
                    searchResult.Add(e);
                }
            }
            return searchResult;
        }
        public List<Event> GetEventsByDate(DateTime date)
        {
            List<Event> searchResult = new();
            foreach (Event e in EventList)
            {
                if (e.DateTime.Date == date.Date)
                {
                    searchResult.Add(e);
                }
            }
            return searchResult;
        }

        public Product ConvertEventToProduct(Event eventToConvert)
        {
            string startDateTimeString = eventToConvert.DateTime.ToString("dd-MM-yy") + " " + eventToConvert.DateTime.ToString("HH:mm");
            DateTime endDateTime = eventToConvert.DateTime.AddMinutes(eventToConvert.Duration);
            string endDateTimeString = endDateTime.ToString("dd-MM-yy") + " " + endDateTime.ToString("HH:mm");

            Product productOut = new()
            {
                ID = eventToConvert.ID + 9000,
                Name = eventToConvert.Name,
                Description = eventToConvert.Description,
                Content = $"Sted: {eventToConvert.Location} Start: {startDateTimeString} - End: {endDateTimeString}",
                Type = "Event",
                Price = eventToConvert.Cost,
                Size = eventToConvert.Capacity
            };

            if (eventToConvert.IsFull)
            {
                string tempContent = productOut.Content;
                productOut.Content = "ALLE BILLETTER UDSOLGT\n";
                productOut.Content += tempContent;
            }
            return productOut;
        }
    }
}