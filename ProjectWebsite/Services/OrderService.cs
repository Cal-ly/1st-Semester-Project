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
            Console.WriteLine(order.OrderList.ElementAt(1));
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
            Console.WriteLine(Order.basket);
            foreach(OrderLine linje in Order.basket)
                Console.WriteLine(linje);
            Order temp = new() { ID = maxID, TotalPrice = CalculateTotal(Order.basket), CustomerID = temp2.ID };
            Order.basket = new();
            Console.WriteLine(temp.OrderList);
            foreach (OrderLine linje in temp.OrderList)
                Console.WriteLine(linje);
            temp.OrderList = Order.basket;
            AddOrder(temp);
        }

        public double CalculateTotal(List<OrderLine> orderLines)
        {
            double total = 0;
            foreach (OrderLine line in Order.basket)
            {
                total += line.Amount * line.Product.Price;
            }
            return total;
        }
    }
}
