using ProjectWebsite.Models;
using ProjectWebsite.Repositories;

namespace ProjectWebsite.Services
{
    public class OrderService
    {
		
		public Order Order { get; set; }
        private OrderRepository OrderLog { get; set; }
        private JsonOrderService JsonOrderService { get; set; }
        private CustomerRepository customerRepository { get; set; }

        public OrderService(JsonOrderService jsonOrderService, CustomerRepository customerRepository)
        {
            OrderLog = new();
            JsonOrderService = jsonOrderService;
            OrderLog.orderLog = JsonOrderService.GetJsonItems().ToList();
            this.customerRepository = customerRepository;
        }

        public void AddOrder(Order order)
        {
            OrderLog.AddToOrderLog(order);
            JsonOrderService.SaveJsonItems(OrderLog.orderLog);
        }

        public void PlaceOrder(string email)
        {
            //Gets reference to customer (if customer with that email doesn't exist then abort the method
            Customer customerWhoMadeOrder = customerRepository.EmailSearch(email);
            if (customerWhoMadeOrder == null) return;

            //gets the ID for the new Order objekt
            int maxID = OrderLog.orderLog.Max(c => c.ID) + 1; 

            Order.basket = new(); //resets the basket

            //creates new Order object with ID, TotalPrice, OrderList and CustomerID
            //and immediatly sends its to AddOrder
            AddOrder(new() { ID = maxID, TotalPrice = CalculateTotal(Order.basket), OrderList = Order.basket, CustomerID = customerWhoMadeOrder.ID });
        }

        public double CalculateTotal(List<OrderLine> orderLines)
        {
            double total = 0;
            foreach (OrderLine line in orderLines)
                total += line.Amount * line.Product.Price;
            return total;
        }

        public bool FinishOrder(int orderID)
        {
            Order finishMe = OrderLog.SearchOrder(orderID);
            if(finishMe != null)
            {
                finishMe.Finished = true;
                finishMe.DateFinished = DateTime.Now;
                return true;
            }
            return false;
        }
    }
}
