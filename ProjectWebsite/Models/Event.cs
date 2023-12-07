namespace ProjectWebsite.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string EventName { get; set; }
        public string EventLocation { get; set; }
        public DateTime EventDateTime { get; set; }
        public int EventDuration { get; set; } // in mintues
        public string EventDescription { get; set; }
        public double EventCost { get; set; }
		public List<Customer> EventAttendees { get; set; } = new();
        public int EventCapacity { get; set; }
        public bool EventIsFull => EventAttendees == null || EventAttendees.Count >= EventCapacity; // Checks if the event is full based on the number of attendees and the event capacity
        public string EventOrganizer { get; set; }
		
        public Event() {}

        public override string ToString()
        {
            return $"{{{nameof(ID)}={ID.ToString()}, {nameof(EventName)}={EventName}, {nameof(EventLocation)}={EventLocation}, {nameof(EventDateTime)}={EventDateTime.ToString()}, {nameof(EventDuration)}={EventDuration.ToString()}, {nameof(EventDescription)}={EventDescription}, {nameof(EventCost)}={EventCost.ToString()}, {nameof(EventAttendees)}={EventAttendees}, {nameof(EventCapacity)}={EventCapacity.ToString()}, {nameof(EventIsFull)}={EventIsFull.ToString()}, {nameof(EventOrganizer)}={EventOrganizer}}}";
        }
    }
}
