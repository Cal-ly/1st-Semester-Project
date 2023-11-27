namespace ProjectWebsite.Models
{
    public class Customer
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }

		public Customer() { }
		public Customer(int identifier, string name, string address, string email, string phoneNumber)
		{
			Id = identifier;
			Name = name;
			Address = address;
			Email = email;
			PhoneNumber = phoneNumber;
		}
		public override string ToString()
		{
			return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Address)}: {Address}, {nameof(PostalCode)}: {PostalCode}, {nameof(City)}: {City}, {nameof(PhoneNumber)}: {PhoneNumber}, Member: {MemberDisplay}";
		}
	}
}
