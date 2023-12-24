using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
	public class OrderService : IOrderService
	{
		private readonly HttpClient _client;
		public OrderService(HttpClient client)
		{
			_client = client;
		}

		public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName)
		{
			var response = await _client.GetAsync($"/api/Order/{userName}");
			var orders = await response.ReadContentAs<List<OrderResponseModel>>();
			return orders!;
		}
	
	}
}
