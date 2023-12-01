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
        
        public override string ToString()
        {
			return $"ID: {ID}\nName: {EventName}\nDescription: {EventDescription}\nLocation: {EventLocation}\nDate: {EventDate}\nTime: {EventTime}\nDuration: {EventDuration}\nOrganizer: {EventOrganizer}\nEmail: {EventOrganizerEmail}\nPhone: {EventOrganizerPhone}\nWebsite: {EventOrganizerWebsite}";
		}

	}
}
