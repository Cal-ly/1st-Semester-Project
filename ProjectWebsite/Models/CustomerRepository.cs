namespace ProjectWebsite.Models
{
    public class CustomerRepository
    {
        List<Customer> CustomerList = new List<Customer>();

        public static int NextID = 1;

        public Customer CreateCustomer(string name, string address, string email, string phoneNumber)
        {
            Customer customer = new Customer(NextID++, name, address, email, phoneNumber);
            CustomerList.Add(customer);
            foreach (Customer c in CustomerList)
            {
                if (c == customer)
                    return customer;
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
                    return true;
                }
            }
            return false;
        }
    }
}
