namespace Shopping.Aggregator.Models
{
	public class ShoppingModel
	{
		public string UserName { get; set; } = null!;
		public BasketModel BasketWithProducts { get; set; } = new();
		public IEnumerable<OrderResponseModel> Orders { get; set; } = [];
	}
}
