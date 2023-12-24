namespace Shopping.Aggregator.Models
{
	public class OrderResponseModel
	{
		public string UserName { get; set; } = null!;
		public decimal TotalPrice { get; set; }

		// BillingAddress
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; }   = null!;
		public string EmailAddress { get; set; } = string.Empty;
		public string AddressLine { get; set; }  = null!;
		public string Country { get; set; } = string.Empty;
		public string State { get; set; } = string.Empty;
		public string ZipCode { get; set; } = string.Empty;

		// Payment
		public string CardName { get; set; } = null!;
		public string CardNumber { get; set; } = null!;
		public string Expiration { get; set; } = null!;
		public string CVV { get; set; } = null!;
		public int PaymentMethod { get; set; }
	}
}
