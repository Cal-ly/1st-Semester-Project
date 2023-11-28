using System.Xml.Linq;

namespace ProjectWebsite.Models
{
    public class Order
    {
        public static List<OrderLine> kurven = new(); //kurven
        private int NextID = 1;
        public int ID { get; set; }
        public int CustomerID { get; set; }
        private double TotalPrice { get; set; }

        List<OrderLine> OrderList = new();

        public Order()
        {
            ID = NextID++;
        }



        //public double CalculateTotalPrice()
        //{
        //    return;
        //}

        //public Customer GetCustomer(int customerID)
        //{
        //    foreach (Customer c in CustomerList)
        //    {
        //        if (c.ID == customerID)
        //            return c;
        //    }
        //    return null;
        //}

        //public Product GetProduct(int productID)
        //{
        //    return;
        //}
    }
}
