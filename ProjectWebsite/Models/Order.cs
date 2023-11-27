using System.Xml.Linq;

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

        //public double CalcTotalPrice()
        //{
        //    return;
        //}

        //public Customer GetCustomer(int customerID)
        //{
        //    foreach (Customer c in CusList)
        //    {
        //        if (c.Name == name)
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
