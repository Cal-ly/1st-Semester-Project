namespace ProjectWebsite.Models
{
    public class OrderLine
    {
        public Product Product { get; set; } //change this to an int?
        public int Amount { get; set; }

        public OrderLine() { }

        public override string ToString()
        {
            return $"{{{nameof(Product)}={Product}, {nameof(Amount)}={Amount.ToString()}}}";
        }
    }
}
