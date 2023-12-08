using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectWebsite.Models
{
    public class Event
    {
        [ReadOnly(true)]
        [Display(Name = "Event ID", Prompt = "Indtast et event ID")]
        public int ID { get; set; }

        [Display(Name = "Navn", Prompt = "Indtast et navn for eventet")]
        public string Name { get; set; }

        [Display(Name = "Sted", Prompt = "Indtast et sted")]
        public string Location { get; set; }

        [Display(Name = "Dato", Prompt = "Indtast en dato")]
        public DateTime DateTime { get; set; }

        [Display(Name = "Varighed (minutter)", Prompt = "Indtast eventets længde i minutter")]
        [Range(1, int.MaxValue)]
        public int Duration { get; set; } // in mintues

        [Display(Name = "Beskrivelse", Prompt = "Indtast en beskrivelse")]
        public string Description { get; set; }

        [Display(Name = "Pris", Prompt = "Indtast en pris (mindst 0 kr.)")]
        [Range(0, double.MaxValue)]
        public double Cost { get; set; }

        [Display(Name = "Deltagere")]
        public List<Customer> Attendees { get; set; } = new();

        [Display(Name = "Maks. antal deltagere", Prompt = "Indtast eventets kapacitet")]
        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }

        public bool IsFull => Attendees == null || Attendees.Count >= Capacity; // Checks if the event is full based on the number of attendees and the event capacity

        [Display(Name = "Arrangør", Prompt = "Indtast navnet på arrangøren")]
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
