using System.ComponentModel.DataAnnotations;

namespace ProjectWebsite.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime DateTime { get; set; }
        public int Duration { get; set; } // in mintues
        public string Description { get; set; }

        //[Display(Name = "Event pris")]
        //[Required(ErrorMessage = "Der skal angives en pris")]
        //[Range(typeof(double), "1", "10000", ErrorMessage = "Pris skal være over 0")]
        public double Cost { get; set; }

		public List<Customer> Attendees { get; set; } = new();
        public int Capacity { get; set; }
        public bool IsFull => Attendees == null || Attendees.Count >= Capacity; // Checks if the event is full based on the number of attendees and the event capacity
        public string Organizer { get; set; }
		public Event() {}
	}
}
