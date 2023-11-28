using ProjectWebsite.Models;

namespace ProjectWebsite.Services
{
    public class OrderLog
    {
        public List<Order> orderLog { get; set; }

        public Order SearchOrder(int orderID)
        {
            foreach (Order order in orderLog)
                if (order.ID == orderID)
                    return order;
            return null;
        }

        public List<Order> GetCustomerOrders(int customerID)
        {
            List<Order> customersOrders = new();
            foreach (Order order in orderLog)
                if (order.CustomerID == customerID)
                    customersOrders.Add(order);
            return customersOrders;
        }

        public void AddToOrderLog(Order order)
        {
            orderLog.Add(order);
        }
    }
}
