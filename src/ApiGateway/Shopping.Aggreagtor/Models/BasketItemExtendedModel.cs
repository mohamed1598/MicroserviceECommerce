namespace Shopping.Aggregator.Models
{
	public class BasketItemExtendedModel
	{
		public int Quantity { get; set; }
		public string Color { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public string ProductId { get; set; } = null!;
		public string ProductName { get; set; } = null!;

		//Product Related Additional Fields
		public string Category { get; set; } = string.Empty;
		public string Summary { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string? ImageFile { get; set; }
	}
}