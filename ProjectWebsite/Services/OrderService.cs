using ProjectWebsite.Models;

namespace ProjectWebsite.Services
{
    public class OrderService
    {
		
		public Order Order { get; set; }
        private OrderLog OrderLog { get; set; }
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
            Console.WriteLine("It works 1");
            Customer temp2 = customerRepository.EmailSearch(email);
            Console.WriteLine(temp2);
            if (temp2 == null) return;
            int maxID = OrderLog.orderLog.Max(c => c.ID) + 1;
            Console.WriteLine(maxID);
            Order temp = new() { ID = maxID, TotalPrice = CalculateTotal(Order.kurven), OrderList = Order.kurven, CustomerID = 2 };
            Order.kurven = new();
            AddOrder(temp);
        }

        public double CalculateTotal(List<OrderLine> orderLines)
        {
            double total = 0;
            foreach (OrderLine line in Order.kurven)
            {
                total += line.Amount * line.Product.Price;
            }
            return total;
        }
    }
}
