namespace ProjectWebsite.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventLocation { get; set; }
        public string EventDate { get; set; }
        public string EventTime { get; set; }
        public string EventDuration { get; set; }
        public string EventOrganizer { get; set; }
        public string EventOrganizerEmail { get; set; }
        public string EventOrganizerPhone { get; set; }
        public string EventOrganizerWebsite { get; set; }
        
        public Event() {}

        public override string ToString()
        {
            return $"{{{nameof(ID)}={ID.ToString()}, {nameof(EventName)}={EventName}, {nameof(EventDescription)}={EventDescription}, {nameof(EventLocation)}={EventLocation}, {nameof(EventDate)}={EventDate}, {nameof(EventTime)}={EventTime}, {nameof(EventDuration)}={EventDuration}, {nameof(EventOrganizer)}={EventOrganizer}, {nameof(EventOrganizerEmail)}={EventOrganizerEmail}, {nameof(EventOrganizerPhone)}={EventOrganizerPhone}, {nameof(EventOrganizerWebsite)}={EventOrganizerWebsite}}}";
        }

        //public Event(
        //    int id,
        //    string eventName, 
        //    string eventDescription, 
        //    string eventLocation, 
        //    string eventDate, 
        //    string eventTime, 
        //    string eventDuration, 
        //    string eventOrganizer, 
        //    string eventOrganizerEmail, 
        //    string eventOrganizerPhone, 
        //    string eventOrganizerWebsite)
        //{
        //    ID = id;
        //    EventName = eventName;
        //    EventDescription = eventDescription;
        //    EventLocation = eventLocation;
        //    EventDate = eventDate;
        //    EventTime = eventTime;
        //    EventDuration = eventDuration;
        //    EventOrganizer = eventOrganizer;
        //    EventOrganizerEmail = eventOrganizerEmail;
        //    EventOrganizerPhone = eventOrganizerPhone;
        //    EventOrganizerWebsite = eventOrganizerWebsite;
        //}
    }
}
