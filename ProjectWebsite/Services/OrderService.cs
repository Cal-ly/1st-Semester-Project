using ProjectWebsite.Models;
using ProjectWebsite.Repositories;

namespace ProjectWebsite.Services
{
    public class OrderService
    {
        public List<Order> OrderList { get { return OrderRepository.OrderList; } }
        private OrderRepository OrderRepository { get; set; }
        private CustomerRepository CustomerRepository { get; set; }
        private EventRepository EventRepository { get; set; }
        public OrderService(OrderRepository orderRepository, CustomerRepository customerRepository, EventRepository eventRepository)
        {
            OrderRepository = orderRepository;
            CustomerRepository = customerRepository;
            EventRepository = eventRepository;
        }
        #region Repository methods calls
        public void AddOrder(Order order) { OrderRepository.AddOrder(order); }
        public List<Order> GetCustomerOrders(int customerID) { return OrderRepository.GetCustomerOrders(customerID); }
        public Order GetOrder(int orderID) { return OrderRepository.GetOrder(orderID); }
        public bool FinishOrder(int orderID) { return OrderRepository.FinishOrder(orderID); }
        public bool DeleteOrder(int orderID) { return OrderRepository.DeleteOrder(orderID); }
        public bool UpdateOrderAmount(int newAmount, int orderLineID) { return OrderRepository.UpdateOrderAmount(newAmount, orderLineID); }
        public bool DeleteFromBasket(int id) { return OrderRepository.DeleteFromBasket(id); }
        #endregion
        public bool PlaceOrder(string email)
        {
            //Gets reference to customer (if customer with that email doesn't exist then abort the method
            Customer customerWhoMadeOrder = CustomerRepository.GetCustomerByEmail(email);
            if (customerWhoMadeOrder == null) return false;

            //gets the ID for the new Order object
            int maxID = OrderList.Max(c => c.ID) + 1;

            //creates new Order object with ID, TotalPrice, OrderList and CustomerID
            //and immediately sends its to AddOrder
            AddOrder(new() { ID = maxID, TotalPrice = CalculateTotal(Order.Basket), OrderList = Order.Basket, CustomerID = customerWhoMadeOrder.ID });
            foreach (var orderLine in Order.Basket)
            {
                if (orderLine.Product.Type == "Event")
                {
                    Event eventInOrderline = EventRepository.GetEventByID(orderLine.Product.ID);
                    if (eventInOrderline != null)
                    {
                        eventInOrderline.Attendees.Add(customerWhoMadeOrder);
                        EventRepository.UpdateEventAttendees(eventInOrderline); //updates the event with the new attendee and saves it in the json file
                    }
                }
            }
            Order.Basket = new(); //resets the basket
            return true;
        }
        public double CalculateTotal(List<OrderLine> kurv)
        {
            //laver lokal variable "total" og sætter den til 0
            double total = 0;
            //foreach lække der går igennem hver ordre linje i orderLines parameteren
            foreach (OrderLine line in kurv)
            {
                //gange mængde med prisen for hver linje og lægger det til total
                total += line.Amount * line.Product.Price;
            }
            //returnere total EFTER foreach løkken
            return total;
        }
    }
}
