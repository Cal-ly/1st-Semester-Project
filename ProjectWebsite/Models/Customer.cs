using System.ComponentModel.DataAnnotations;

namespace ProjectWebsite.Models
{
    public class Customer
    {
        [Display(Name = "Kunde ID")]
        public int ID { get; set; }

        [Display(Name = "Navn")]
        public string Name { get; set; }

        [Display(Name = "Adresse")]
        public string Address { get; set; }

		public string Email { get; set; }

        [Display(Name = "Telefonnummer")]
        public string PhoneNumber { get; set; }

        public Customer()
        {
        }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Address: {Address}, Email: {Email}, PhoneNumber: {PhoneNumber}";
        }
    }
}
