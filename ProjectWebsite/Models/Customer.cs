namespace ProjectWebsite.Models
{
    public class Customer
    {
		public int ID { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }

		public Customer() { }

        public override string ToString()
        {
            return $"{{{nameof(ID)}={ID.ToString()}, {nameof(Name)}={Name}, {nameof(Address)}={Address}, {nameof(Email)}={Email}, {nameof(PhoneNumber)}={PhoneNumber}}}";
        }
    }
}
