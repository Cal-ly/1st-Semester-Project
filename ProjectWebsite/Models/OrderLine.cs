namespace ProjectWebsite.Models
{
    public class OrderLine
    {
        public enum PackageSize
        {
            _100 = 100, //assign a value to each enum
            _150 = 150,
            _200 = 200,
            _300 = 300
        }

        public Product Product { get; set; }
        public PackageSize SelectedPackage { get; set; }
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
