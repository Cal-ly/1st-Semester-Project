namespace ProjectWebsite.Models
{
    public class Customer
    {
		public int ID { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }

		public Customer()
		{
		}

		public Customer(int id, string name, string address, string email, string phoneNumber)
		{
			ID = id;
			Name = name;
			Address = address;
			Email = email;
			PhoneNumber = phoneNumber;
		}

        public override string ToString()
        {
            return $"{{{nameof(ID)}={ID.ToString()}, {nameof(Name)}={Name}, {nameof(Address)}={Address}, {nameof(Email)}={Email}, {nameof(PhoneNumber)}={PhoneNumber}}}";
        }
    }
}
