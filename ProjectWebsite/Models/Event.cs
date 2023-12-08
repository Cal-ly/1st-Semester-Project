using System.ComponentModel.DataAnnotations;

namespace ProjectWebsite.Models
{
    public class Event
    {
        [Display(Name = "Event ID")]
        public int ID { get; set; }

        [Display(Name = "Navn")]
        public string Name { get; set; }

        [Display(Name = "Sted")]
        public string Location { get; set; }

        [Display(Name = "Dato")]
        public DateTime DateTime { get; set; }

        [Display(Name = "Varighed (minutter)")]
        public int Duration { get; set; } // in mintues

        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }

        [Display(Name = "Pris")]
        public double Cost { get; set; }

        [Display(Name = "Deltagere")]
        public List<Customer> Attendees { get; set; } = new();

        [Display(Name = "Kapacitet")]
        public int Capacity { get; set; }

        public bool IsFull => Attendees == null || Attendees.Count >= Capacity; // Checks if the event is full based on the number of attendees and the event capacity

        [Display(Name = "Arrangør")]
        public string Organizer { get; set; }

        public Event()
        {
        }

        public override string ToString()
        {
            return $"{{{nameof(ID)}={ID.ToString()}, {nameof(Name)}={Name}, {nameof(Location)}={Location}, {nameof(DateTime)}={DateTime.ToString()}, {nameof(Duration)}={Duration.ToString()}, {nameof(Description)}={Description}, {nameof(Cost)}={Cost.ToString()}, {nameof(Attendees)}={Attendees}, {nameof(Capacity)}={Capacity.ToString()}, {nameof(IsFull)}={IsFull.ToString()}, {nameof(Organizer)}={Organizer}}}";
        }
    }
}
