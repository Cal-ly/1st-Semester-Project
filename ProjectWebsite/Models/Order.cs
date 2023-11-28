using System.Xml.Linq;

namespace ProjectWebsite.Models
{
    public class Order
    {
        public static List<OrderLine> basket = new(); //kurven

        public int ID { get; set; }
        public int CustomerID { get; set; }
        public double TotalPrice { get; set; }

        public List<OrderLine> OrderList = new();

        public Order()
        {
            
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
