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
            //Console.WriteLine(order.OrderList.ElementAt(1));
            OrderLog.AddToOrderLog(order);

            JsonOrderService.SaveJsonItems(OrderLog.orderLog);

        }

        public void PlaceOrder(string email)
        {
            Customer temp2 = customerRepository.EmailSearch(email);
            if (temp2 == null) return;
            int maxID = OrderLog.orderLog.Max(c => c.ID) + 1;
            Order temp = new() { ID = maxID, TotalPrice = CalculateTotal(Order.basket), CustomerID = temp2.ID };
            temp.OrderList = new();
            foreach (OrderLine linje in Order.basket)
                temp.OrderList.Add(linje);
            Console.WriteLine(temp.OrderList.Count);
            //Order.basket = new();
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
