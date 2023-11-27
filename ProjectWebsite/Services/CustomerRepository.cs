using ProjectWebsite.Models;

namespace ProjectWebsite.Services
{
    public class CustomerRepository
    {
        public List<Customer> CustomerList = new List<Customer>();
        public static int NextID = 1;
        private JsonFileCustomerService JsonFileCustomerService { get; set; }
        public List<Customer> GetList { get { return CustomerList; } }

        public CustomerRepository(JsonFileCustomerService jsonFileCustomerService)
        {
            JsonFileCustomerService = jsonFileCustomerService;
            CustomerList = JsonFileCustomerService.GetJsonItems().ToList();
        }

        public void CreateCustomer(Customer customer)
        {
            CustomerList.Add(customer);
            JsonFileCustomerService.SaveJsonItems(CustomerList);
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

        public bool UpdateCustomer(Customer customer, int customerID)
        {
            return false;
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
            Customer customerToBeDeleted = GetCustomer(customerID);
            if (customerToBeDeleted != null)
            {
                CustomerList.Remove(customerToBeDeleted);
                JsonFileCustomerService.SaveJsonItems(CustomerList);
                return true;
            }
            return false;
        }
        public List<Customer> NameSearch(string searchString)
        {
            List<Customer> searchResult = new List<Customer>();
            foreach (Customer c in CustomerList)
            {
                if (c.Name.ToLower().Contains(searchString.ToLower()))
                    searchResult.Add(c);
            }
            return searchResult;
        }
    }
}
