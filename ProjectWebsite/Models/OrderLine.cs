using System.ComponentModel.DataAnnotations;

namespace ProjectWebsite.Models
{
    public class OrderLine
    {
        public int ID { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public OrderLine()
        {
        }
        public override string ToString()
        {
            return $"{{{nameof(Product)}={Product}, {nameof(Amount)}={Amount.ToString()}, {nameof(ID)}={ID.ToString()}}}";
        }
    }
}
