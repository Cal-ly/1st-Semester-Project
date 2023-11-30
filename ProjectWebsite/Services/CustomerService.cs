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
        public Customer GetCustomer(int customerID) { return CustomerRepository.GetCustomer(customerID); }
        public Customer UpdateCustomer(Customer customerIn) { return CustomerRepository.UpdateCustomer(customerIn); }
        #endregion
    }
}
