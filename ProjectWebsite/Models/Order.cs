namespace ProjectWebsite.Models
{
    public class Order
    {
        private int NextID = 1;
        private int ID { get; set; }
        private double TotalPrice { get; set; }
        //Customer

        List<Product> OrderList = new List<Product>();

        public Order()
        {
            ID = NextID++;
        }
    }
}
