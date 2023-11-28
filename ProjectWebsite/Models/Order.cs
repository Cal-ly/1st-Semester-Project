using System.Xml.Linq;

namespace ProjectWebsite.Models
{
    public class Order
    {
        public static List<OrderLine> basket = new(); //kurven

        public int ID { get; set; }
        public int CustomerID { get; set; }
        public double TotalPrice { get; set; }
        public List<OrderLine> OrderList { get; set; }

        public Order() { }

        public override string ToString()
        {
            return $"{{{nameof(ID)}={ID.ToString()}, {nameof(CustomerID)}={CustomerID.ToString()}, {nameof(TotalPrice)}={TotalPrice.ToString()}, {nameof(OrderList)}={OrderList}}}";
        }
    }
}
