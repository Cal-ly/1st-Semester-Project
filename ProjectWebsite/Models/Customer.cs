using System.ComponentModel.DataAnnotations;

namespace ProjectWebsite.Models
{
    public class Customer
    {
        [Display(Name = "Kunde ID", Prompt="Indtast et kunde ID")]
        public int ID { get; set; }

        [Display(Name = "Navn", Prompt = "Indtast et navn")]
        public string Name { get; set; }

        [Display(Name = "Adresse", Prompt = "Indtast en adresse")]
        public string Address { get; set; }

        [Display(Name = "E-mail", Prompt = "Indtast en e-mail adresse")]
        public string Email { get; set; }

        [Display(Name = "Telefonnummer", Prompt = "Indtast et telefonnummer")]
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
