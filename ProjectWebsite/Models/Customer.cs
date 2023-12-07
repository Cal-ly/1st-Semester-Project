namespace ProjectWebsite.Models
{
    public class Customer
    {
		public int ID { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Address: {Address}, Email: {Email}, PhoneNumber: {PhoneNumber}";
        }
    }
}
