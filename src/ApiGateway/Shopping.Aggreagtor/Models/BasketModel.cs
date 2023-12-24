namespace Shopping.Aggregator.Models
{
	public class BasketModel
	{
		public string UserName { get; set; } = null!;
		public List<BasketItemExtendedModel> Items { get; set; } = [];
		public decimal TotalPrice { get; set; }
	}
}
