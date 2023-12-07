namespace ProjectWebsite.Models
{
    public class OrderLine
    {
        public Product Product { get; set; } 
        public int Amount { get; set; }
        public int ID { get; set; }

        public OrderLine() { }

        public override string ToString()
        {
            return $"{{{nameof(Product)}={Product}, {nameof(Amount)}={Amount.ToString()}, {nameof(ID)}={ID.ToString()}}}";
        }
    }
}
