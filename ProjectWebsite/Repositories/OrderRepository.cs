using ProjectWebsite.Models;
using ProjectWebsite.Services;

namespace ProjectWebsite.Repositories
{
    public class OrderRepository
    {
        public List<Order> OrderList { get; set; }
        private JsonOrderService JsonOrderService { get; set; }

        public OrderRepository(JsonOrderService jsonOrderService)
        {
            JsonOrderService = jsonOrderService;
            OrderList = JsonOrderService.GetJsonItems().ToList();
        }

        public Order SearchOrder(int orderID)
        {
            foreach (Order order in OrderList)
                if (order.ID == orderID)
                    return order;
            return null;
        }

        public List<Order> GetCustomerOrders(int customerID)
        {
            List<Order> customersOrders = new();
            foreach (Order order in OrderList)
                if (order.CustomerID == customerID)
                    customersOrders.Add(order);
            return customersOrders;
        }

        public void AddToOrderLog(Order order)
        {
            OrderList.Add(order);
            JsonOrderService.SaveJsonItems(OrderList);
        }
    }
}
