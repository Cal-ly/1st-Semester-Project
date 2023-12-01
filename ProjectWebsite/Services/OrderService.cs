using ProjectWebsite.Models;
using ProjectWebsite.Repositories;

namespace ProjectWebsite.Services
{
    public class OrderService
    {
        private OrderRepository OrderRepository { get; set; }
        private CustomerRepository CustomerRepository { get; set; }

        public List<Order> OrderList { get { return OrderRepository.OrderList; } }

        public OrderService(OrderRepository orderRepository, CustomerRepository customerRepository)
        {
            OrderRepository = orderRepository;
            CustomerRepository = customerRepository;
        }

        #region Repository methods calls
        public void AddOrder(Order order) { OrderRepository.AddOrder(order); }
        public List<Order> GetCustomerOrders(int customerID) { return OrderRepository.GetCustomerOrders(customerID); }
        public Order GetOrder(int orderID) { return OrderRepository.GetOrder(orderID); }
        public bool FinishOrder(int orderID) { return OrderRepository.FinishOrder(orderID); }
		public bool DeleteOrder(int orderID) { return OrderRepository.DeleteOrder(orderID); }
		#endregion

		public void PlaceOrder(string email)
        {
            //Gets reference to customer (if customer with that email doesn't exist then abort the method
            Customer customerWhoMadeOrder = CustomerRepository.GetCustomerByEmail(email);
            if (customerWhoMadeOrder == null) return;

            //gets the ID for the new Order object
            int maxID = OrderList.Max(c => c.ID) + 1; 

            Order.basket = new(); //resets the basket

            //creates new Order object with ID, TotalPrice, OrderList and CustomerID
            //and immediately sends its to AddOrder
            AddOrder(new() { ID = maxID, TotalPrice = CalculateTotal(Order.basket), OrderList = Order.basket, CustomerID = customerWhoMadeOrder.ID });
        }

        public double CalculateTotal(List<OrderLine> orderLines)
        {
            double total = 0;
            foreach (OrderLine line in orderLines)
                total += line.Amount * line.Product.Price;
            return total;
        }
    }
}
