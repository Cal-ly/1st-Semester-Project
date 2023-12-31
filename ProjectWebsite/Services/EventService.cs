﻿using ProjectWebsite.Models;
using ProjectWebsite.Repositories;

namespace ProjectWebsite.Services
{
    public class EventService
    {
        public List<Event> EventList { get { return EventRepository.EventList; } }
        private EventRepository EventRepository { get; set; }
        public EventService(EventRepository eventRepository)
        {
            EventRepository = eventRepository;
        }
        public int GetNextID() { return EventRepository.GetNextID(); }
        public void CreateEvent(Event eventIn) { EventRepository.CreateEvent(eventIn); }
        public Event UpdateEvent(Event eventIn) { return EventRepository.UpdateEvent(eventIn); }
        public Event UpdateEventAttendees(Event eventIn) { return EventRepository.UpdateEventAttendees(eventIn); }
        public bool DeleteEvent(int eventID) { return EventRepository.DeleteEvent(eventID); }
        public List<Customer> GetEventAttendees(int eventID) { return EventRepository.GetEventAttendees(eventID); }
        public Event GetEventByID(int eventID) { return EventRepository.GetEventByID(eventID); }
        public List<Event> GetEventsByName(string eventsName) { return EventRepository.GetEventsByName(eventsName); }
        public Product ConvertEventToProduct(Event eventIn) { return EventRepository.ConvertEventToProduct(eventIn); }
    }
}