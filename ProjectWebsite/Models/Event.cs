namespace ProjectWebsite.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventLocation { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime EventTime { get; set; }
        //public double EventCost { get; set; }
        //public List<Customer> EventAttendees { get; set; }
        public int EventDuration { get; set; } // in mintues
        public string EventOrganizer { get; set; }
        public string EventOrganizerEmail { get; set; }
        public string EventOrganizerPhone { get; set; }
        public string EventOrganizerWebsite { get; set; }
        
        public Event() {}

		//public override string ToString()
		//{
		//	return $"{{{nameof(ID)}={ID.ToString()}, {nameof(EventName)}={EventName}, {nameof(EventDescription)}={EventDescription}, {nameof(EventLocation)}={EventLocation}, {nameof(EventDate)}={EventDate.ToString()}, {nameof(EventTime)}={EventTime.ToString()}, {nameof(EventCost)}={EventCost.ToString()}, {nameof(EventAttendees)}={EventAttendees}, {nameof(EventDuration)}={EventDuration.ToString()}, {nameof(EventOrganizer)}={EventOrganizer}, {nameof(EventOrganizerEmail)}={EventOrganizerEmail}, {nameof(EventOrganizerPhone)}={EventOrganizerPhone}, {nameof(EventOrganizerWebsite)}={EventOrganizerWebsite}}}";
		//}
	}
}
