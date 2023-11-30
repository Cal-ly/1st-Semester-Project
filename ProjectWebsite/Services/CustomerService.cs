using ProjectWebsite.Models;
using ProjectWebsite.Repositories;
using ProjectWebsite.Services;

namespace ProjectWebsite.Services
{
    public class CustomerService
    {
        public CustomerRepository CustomerRepository { get; set; }

        public CustomerService(CustomerRepository customerRepository)
        {
            CustomerRepository = customerRepository;
        }

        #region Repository method calls
        public void CreateCustomer(Customer customerIn) { CustomerRepository.CreateCustomer(customerIn); }
        public Customer GetCustomerID(int customerID) { return CustomerRepository.GetCustomer(customerID); }
        public Customer GetCustomerEmail(string customerEmail) { return CustomerRepository.EmailSearch(customerEmail); }
        public List<Customer> GetCustomerName(string customerName) { return CustomerRepository.NameSearch(customerName); }
        public Customer UpdateCustomer(Customer customerIn) { return CustomerRepository.UpdateCustomer(customerIn); }
        public bool DeleteCustomer(int customerID) { return CustomerRepository.DeleteCustomer(customerID); }
        public List<Customer> CustomerList { get { return CustomerRepository.CustomerList; } }
        #endregion
    }
}
