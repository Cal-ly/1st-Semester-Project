using ProjectWebsite.Models;
using ProjectWebsite.Services;

namespace ProjectWebsite.Repositories
{
    /// <summary>
    /// Represents a repository for managing customer data.
    /// </summary>
    public class CustomerRepository
    {
        public static int NextID = 1;
        public List<Customer> CustomerList { get; set; }
        private JsonCustomerService JsonCustomerService { get; set; }

        public CustomerRepository(JsonCustomerService jsonFileCustomerService)
        {
            JsonCustomerService = jsonFileCustomerService;
            CustomerList = JsonCustomerService.GetJsonItems().ToList();
        }

        /// <summary>
		/// Calculates the next available ID for a new customer object.
		/// It retrieves the Max (largest) ID from the CustomerList and adds 1 to it.
		/// </summary>
		/// <returns>The next available ID for a new customer.</returns>
		public int GetNextID()
        {
            int nextID = CustomerList.Max(c => c.ID) + 1;
            if (nextID <= NextID) { nextID = NextID + 1; }
            NextID = nextID;
            return nextID;
        }

        /// <summary>
        /// Creates a new customer.
        /// </summary>
        /// <param name="customerIn">The customer to create.</param>
        public void CreateCustomer(Customer customerIn)
        {
            if (customerIn == null)
            {
                throw new ArgumentNullException(nameof(customerIn));
            }
            CustomerList.Add(customerIn);
            JsonCustomerService.SaveJsonItems(CustomerList);
        }

        /// <summary>
        /// Retrieves a customer by using ID.
        /// </summary>
        /// <param name="customerID">The ID of the customer to retrieve.</param>
        /// <returns>The customer with the specified ID, or null if not found.</returns>
        public Customer GetCustomer(int customerID)
        {
            foreach (Customer customer in CustomerList)
                if (customer.ID == customerID)
                    return customer;
            return null;
        }

        /// <summary>
        /// Updates a customer by using ID.
        /// </summary>
        /// <param name="incomingC">The updated customer information.</param>
        /// <returns>The updated customer object.</returns>
        public Customer UpdateCustomer(Customer incomingC)
        {
            foreach (Customer outgoingC in CustomerList)
            {
                if (outgoingC.ID == incomingC.ID)
                {
                    outgoingC.Name = incomingC.Name;
                    outgoingC.Address = incomingC.Address;
                    outgoingC.Email = incomingC.Email;
                    outgoingC.PhoneNumber = incomingC.PhoneNumber;
                    JsonCustomerService.SaveJsonItems(CustomerList);
                }
            }
            return incomingC; //TODO: Display updated customer
        }

        /// <summary>
        /// Deletes a customer by their ID.
        /// </summary>
        /// <param name="customerID">The ID of the customer to delete.</param>
        /// <returns>True if the customer was successfully deleted, false otherwise.</returns>
        public bool DeleteCustomer(int customerID)
        {
            Customer customerToBeDeleted = GetCustomer(customerID);
            if (customerToBeDeleted != null)
            {
                CustomerList.Remove(customerToBeDeleted);
                JsonCustomerService.SaveJsonItems(CustomerList);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Searches for customers by name.
        /// </summary>
        /// <param name="searchString">The name to search for.</param>
        /// <returns>A list of customers matching the search criteria.</returns>
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

        public Customer EmailSearch(string Email)
        {
            foreach (Customer c in CustomerList)
                if (c.Email.ToLower().Contains(Email.ToLower()))
                    return c;
            return null;
        }
    }
}
