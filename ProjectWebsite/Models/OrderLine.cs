namespace ProjectWebsite.Models
{
    public class OrderLine
    {
        public Product Product { get; set; }
       // public PackageSize SelectedPackage { get; set; }
        public int Amount { get; set; }

        public OrderLine()
        {
            
        }

        public override string ToString()
        {
            return $"{{{nameof(Product)}={Product}, {nameof(Amount)}={Amount.ToString()}}}";
        }
    }
}
