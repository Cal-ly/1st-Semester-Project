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
        public OrderLine.PackageSize packageSize { get; set; }

        public Product()
        {
        }

        public Product(int id, string name, string description, string content, string type, double price)
        {
            ID = id;
            Name = name;
            Description = description;
            Content = content;
            Type = type;
            Price = price;
        }

        public override string ToString()
        {
            return $"{{{nameof(ID)}={ID.ToString()}, {nameof(Name)}={Name}, {nameof(Description)}={Description}, {nameof(Content)}={Content}, {nameof(Type)}={Type}, {nameof(Price)}={Price.ToString()}}}";
        }
    }
}
