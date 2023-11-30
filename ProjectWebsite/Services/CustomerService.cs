using ProjectWebsite.Models;
using ProjectWebsite.Repositories;

namespace ProjectWebsite.Services
{
    public class CustomerService
    {
        public CustomerRepository CustomerRepository { get; set; }

        public List<Customer> CustomerList { get { return CustomerRepository.CustomerList; } }

        public CustomerService(CustomerRepository customerRepository)
        {
            CustomerRepository = customerRepository;
        }

        #region Repository method calls
        public int GetNextID() { return CustomerRepository.GetNextID(); }
        public void CreateCustomer(Customer customerIn) { CustomerRepository.CreateCustomer(customerIn); }
        public Customer GetCustomerByID(int customerID) { return CustomerRepository.GetCustomerByID(customerID); }
        public Customer GetCustomerByEmail(string customerEmail) { return CustomerRepository.GetCustomerByEmail(customerEmail); }
        public List<Customer> GetCustomersByName(string customerName) { return CustomerRepository.GetCustomersByName(customerName); }
        public Customer UpdateCustomer(Customer customerIn) { return CustomerRepository.UpdateCustomer(customerIn); }
        public bool DeleteCustomer(int customerID) { return CustomerRepository.DeleteCustomer(customerID); }
        #endregion
    }
}
