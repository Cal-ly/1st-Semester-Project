namespace ProjectWebsite.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
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
