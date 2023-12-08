using System.ComponentModel.DataAnnotations;

namespace ProjectWebsite.Models
{
    public class Product
    {
        [Display(Name = "Produkt ID", Prompt = "Indtast et produkt ID")]
        public int ID { get; set; }

        [Display(Name = "Produkt navn", Prompt = "Indtast et produkt navn")]
        public string Name { get; set; }

        [Display(Name = "Beskrivelse", Prompt = "Indtast en beskrivelse")]
        public string Description { get; set; }

        [Display(Name = "Indhold", Prompt = "Indtast hvad produktet indeholder")]
        public string Content { get; set; }

        [Display(Name = "Te-typen", Prompt = "Indtast te-type")]
        public string Type { get; set; }

        [Display(Name = "Produkt pris", Prompt = "Indtast en pris")]
        [Required(ErrorMessage = "Der skal angives en pris")]
        [Range(1, 10000, ErrorMessage = "Pris skal være mellem og inklusiv 1 og 10000 kr.")]
        public double Price { get; set; }
        
        [Display(Name = "Produkt størrelse", Prompt = "Indtast størrelse (gram)")]
        public int Size { get; set; } = 100; //gram

        public Product()
        {
        }

        public override string ToString()
        {
            return $"{{{nameof(ID)}={ID.ToString()}, {nameof(Name)}={Name}, {nameof(Description)}={Description}, {nameof(Content)}={Content}, {nameof(Type)}={Type}, {nameof(Price)}={Price.ToString()}, {nameof(Size)}={Size.ToString()}}}";
        }
    }
}
