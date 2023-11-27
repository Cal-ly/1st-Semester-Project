using System.Xml.Linq;

namespace ProjectWebsite.Models
{
    public class Order
    {
        private int NextID = 1;
        private int ID { get; set; }
        private double TotalPrice { get; set; }

        List<Product> OrderList = new List<Product>();

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
