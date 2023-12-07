using ProjectWebsite.Models;
using ProjectWebsite.Services;

namespace ProjectWebsite.Repositories
{
    public class CustomerRepository
    {
        private static int nextID = 1;
        public List<Customer> CustomerList { get; set; }
        private JsonCustomerService JsonCustomerService { get; set; }
        public CustomerRepository(JsonCustomerService jsonFileCustomerService)
        {
            JsonCustomerService = jsonFileCustomerService;
            CustomerList = JsonCustomerService.GetJsonItems().ToList();
        }
        //Denne metode finder det næste ID, der skal bruges til at oprette en ny kunde.
		public int GetNextID()
        {
            //Finder det højeste ID i listen og lægger 1 til.
            int nextid = CustomerList.Max(c => c.ID) + 1;
            //Hvis det næste ID er mindre end det nuværende næste ID, sættes det næste ID til at være det nuværende næste ID + 1.
            if (nextid <= nextID) { nextid = nextID + 1; }
            //Det nuværende næste ID sættes til at være det næste ID.
            nextid = nextID;
            //Det næste ID returneres.
            return nextID;
        }
        //Denne metode opretter en ny kunde.
        public void CreateCustomer(Customer customerIn)
        {
            //Hvis den indkommende kunde er null, kastes en ArgumentNullException.
            if (customerIn == null) { throw new ArgumentNullException(nameof(customerIn)); }
            //customerIn tilføjes til listen af kunder.
            CustomerList.Add(customerIn);
            //Listen af kunder gemmes i JSON-filen.
            JsonCustomerService.SaveJsonItems(CustomerList);
        }
        //Denne metode henter en kunde ud fra et ID.
        public Customer GetCustomerByID(int customerID)
        {
            //Leder gennem listen af kunder.
            foreach (Customer customer in CustomerList)
            {
                //Hvis kundens ID er det samme som det indkommende ID, returneres kunden.
                if (customer.ID == customerID) { return customer; }
            }
            //Ellers returneres null.
            return null;
        }
        //Denne metode opdaterer en kunde.
        public Customer UpdateCustomer(Customer incomingC)
        {
            //Leder gennem listen af kunder.
            foreach (Customer outgoingC in CustomerList)
            {
                //Hvis den udgående kundes ID er det samme som den indkommende kundes ID, opdateres den udgående kunde.
                if (outgoingC.ID == incomingC.ID)
                {
                    outgoingC.Name = incomingC.Name;
                    outgoingC.Address = incomingC.Address;
                    outgoingC.Email = incomingC.Email;
                    outgoingC.PhoneNumber = incomingC.PhoneNumber;
                    //Listen af kunder gemmes i JSON-filen.
                    JsonCustomerService.SaveJsonItems(CustomerList);
                }
            }
            //Den indkommende/opdaterede kunde returneres.
            return incomingC;
        }
        //Denne metode sletter en kunde.
        public bool DeleteCustomer(int customerID)
        {
            //Den kunde, der skal slettes, findes.
            Customer customerToBeDeleted = GetCustomerByID(customerID);
            //Hvis kunden findes, slettes den.
            if (customerToBeDeleted != null)
            {
                //Kunden fjernes fra listen af kunder.
                CustomerList.Remove(customerToBeDeleted);
                //Listen af kunder gemmes i JSON-filen.
                JsonCustomerService.SaveJsonItems(CustomerList);
                //Der returneres true.
                return true;
            }
            //Ellers returneres false.
            return false;
        }
        //Denne metode søger efter kunder ud fra et navn.
        public List<Customer> GetCustomersByName(string searchString)
        {
            //En liste af kunder oprettes.
            List<Customer> searchResult = new();
            //Leder gennem listen af kunder.
            foreach (Customer c in CustomerList)
            {
                //Hvis kundens navn indeholder søgestrengen, tilføjes kunden til listen af kunder.
                if (c.Name.ToLower().Contains(searchString.ToLower())) { searchResult.Add(c); }
            }
            //Listen af kunder returneres.
            return searchResult;
        }
        //Denne metode søger efter en kunde ud fra en email.
        public Customer GetCustomerByEmail(string Email)
        {
            //Leder gennem listen af kunder.
            foreach (Customer c in CustomerList)
            {
                //Hvis kundens email indeholder søgestrengen, returneres kunden.
                if (c.Email.ToLower().Contains(Email.ToLower())) { return c; }
            }
            //Ellers returneres null.
            return null;
        }
    }
}
