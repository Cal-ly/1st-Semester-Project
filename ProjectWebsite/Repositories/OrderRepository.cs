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

        public Order GetOrder(int orderID)
        {
            Console.WriteLine(orderID);
            foreach (Order order in OrderList)
                if (order.ID == orderID)
                    return order;
            return null;
        }

        public OrderLine GetOrderLine(int orderLineID)
        {
            foreach (OrderLine orderLine in Order.basket)
            {
                if (orderLine.ID == orderLineID)
                {
                    return orderLine;
                }
            }
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

        public void AddOrder(Order order)
        {
            OrderList.Add(order);
            JsonOrderService.SaveJsonItems(OrderList);
        }

        public bool FinishOrder(int orderID)
        {
            Order finishMe = GetOrder(orderID);
            if (finishMe != null)
            {
                finishMe.Finished = true;
                finishMe.DateFinished = DateTime.Now;
                JsonOrderService.SaveJsonItems(OrderList);
                return true;
            }
            return false;
        }

        public bool UpdateOrderAmount(int newAmount, int orderLineID)
        {
            OrderLine orderLine = GetOrderLine(orderLineID);
            if (orderLine != null)
            {
                orderLine.Amount = newAmount;
                return true;
            }
            return false;
        }

        public bool DeleteFromBasket(int orderLineID)
        {
            OrderLine orderLineToBeDeleted = GetOrderLine(orderLineID);
            if (orderLineToBeDeleted != null)
            {
                Order.basket.Remove(orderLineToBeDeleted);
                return true;
            }
            return false;

        }

        public bool DeleteOrder(int orderID)
        {
            Order orderToBeDeleted = GetOrder(orderID);
            if (orderToBeDeleted != null)
            {
                OrderList.Remove(orderToBeDeleted);
                JsonOrderService.SaveJsonItems(OrderList);
                return true;
            }
            return false;
        }
    }
}
