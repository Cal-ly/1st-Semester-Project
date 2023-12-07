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
            //får dependency injected JSonOrderService
            JsonOrderService = jsonOrderService;
            //sætter OrderList til at pege på listen som JsonOrderService returnere
            OrderList = JsonOrderService.GetJsonItems().ToList();
        }

        public Order GetOrder(int orderID)
        {
            //foreach løkke der går igennem OrderList 
            foreach (Order order in OrderList)
            {
                //hvis Order objektets ID matcher orderID parameteren...
                if (order.ID == orderID)
                {
                    //... returnere den en reference til Order objektet
                    return order;
                }  
            }
            //hvis intet match er fundet returneres null
            return null;
        }

        public OrderLine GetOrderLine(int orderLineID)
        {
            //foreach løkke der går igennem hver OrderLine objekt i basket hos Order klassen
            foreach (OrderLine orderLine in Order.Basket)
            {
                //hvis objektets ID matcher orderLineID parameter...
                if (orderLine.ID == orderLineID)
                {
                    //...returnere den en reference til OrderLine objektet
                    return orderLine;
                } 
            }
            //hvis intet match er fundet returnere den null
            return null;
        }

        public List<Order> GetCustomerOrders(int customerID)
        {
            List<Order> customersOrders = new();
            foreach (Order order in OrderList)
            {
                if (order.CustomerID == customerID)
                {
                    customersOrders.Add(order);
                }
            }     
            return customersOrders;
        }

        // Vi laver en metode med returtypen void for at metoden ikke behøver at retunere noget. Vi tilføjer parameteren Order order
        // fordi det er en order vi skal have tilføjet til OrderList
        public void AddOrder(Order order)
        {
            // Vi tager fat i OrderList og tilføjer vores order (som indeholder OrderLines) til OrderList
            OrderList.Add(order);
            // Vi tager fat i JsonOrderService og bruger metoden SaveJsonItems for at tilføje OrderList til vores Json fil.
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

        // Vi laver en metode med returtypen bool for at metoden retunere true eller false.
        // Vi tilføjer parameteren int orderLineID fordi det er måden vi identificere en OrderLine i listen Basket
        public bool DeleteFromBasket(int orderLineID)
        {
            // Vi opretter en lokal reference (orderLineToBeDeleted) til den OrderLine vi skal slette så vi kan få fat i den i metoden
            // Herefter bruger vi den eksisterende metode GetOrderLine som finder en OrderLine vha. OrderLine's ID 
            OrderLine orderLineToBeDeleted = GetOrderLine(orderLineID);
            // Vi laver en if statement hvor vi tjekker at orderLineToBeDeleted ikke er null.
            // Det er en måde at være sikker på at der faktisk er noget at slette 
            if (orderLineToBeDeleted != null)
            {
                // Vi tager fat i Basket (som indeholder OrderLines) og sletter orderLineToBeDeleted
                Order.Basket.Remove(orderLineToBeDeleted);
                // Når orderLineToBeDeleted er slettet returnere metoden true
                return true;
            }
            // Hvis orderLineToBeDeleted er null (altså den ikke indeholder noget) så retunere metoden false
            // for at vise metoden ikke kunne slette den specifikke OrderLine 
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
