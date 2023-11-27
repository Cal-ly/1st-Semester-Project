using ProjectWebsite.Services;

namespace ProjectWebsite.Models
{
    public class CustomerRepository
    {
        List<Customer> CustomerList = new List<Customer>();

        public static int NextID = 1;
        private JsonFileCustomerService JsonFileCustomerService { get;set;}

        public CustomerRepository(JsonFileCustomerService jsonFileCustomerService)
        {
            JsonFileCustomerService = jsonFileCustomerService;
            CustomerList = JsonFileCustomerService.GetJsonItems().ToList();
        }

        public Customer CreateCustomer(string name, string address, string email, string phoneNumber)
        {
            Customer newCustomer = new Customer(NextID++, name, address, email, phoneNumber);
            CustomerList.Add(newCustomer);
            Customer customer = new Customer(NextID++, name, address, email, phoneNumber);
            CustomerList.Add(customer);
            JsonFileCustomerService.SaveJsonItems(CustomerList);
            foreach (Customer c in CustomerList)
            {
                if (c == newCustomer)
                    return newCustomer;
            }
            return null;
        }

        public Customer GetCustomer(int customerID)
        {
            foreach (Customer c in CustomerList)
            {
                if (c.ID == customerID)
                    return c;
            }
            return null;
        }

        public Customer UpdateCustomer(int customerID, string name, string address, string email, string phoneNumber)
        {
            foreach (Customer c in CustomerList)
            {
                if (c.ID == customerID)
                {
                    c.Name = name;
                    c.Address = address;
                    c.Email = email;
                    c.PhoneNumber = phoneNumber;
                    JsonFileCustomerService.SaveJsonItems(CustomerList);
                    return c;
                }
            }
            return null;
        }

        public bool DeleteCustomer(int customerID)
        {
            foreach (Customer c in CustomerList)
            {
                if (c.ID == customerID)
                {
                    CustomerList.Remove(c);
                    JsonFileCustomerService.SaveJsonItems(CustomerList);
                    return true;
                }
            }
            return false;
        }
    }
}
