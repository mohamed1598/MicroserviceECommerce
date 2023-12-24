using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
	public class CatalogService : ICatalogService
	{
		private readonly HttpClient _client;

		public CatalogService(HttpClient client)
		{
			_client = client;
		}

		public async Task<IEnumerable<CatalogModel>> GetCatalog()
		{
			var response = await _client.GetAsync("/api/Catalog");
			var catalogs = await response.ReadContentAs<List<CatalogModel>>();
			return catalogs!;
		}

		public async Task<CatalogModel?> GetCatalog(string id)
		{
			var response = await _client.GetAsync($"/api/Catalog/{id}");
			return await response.ReadContentAs<CatalogModel>();
		}

		public async Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category)
		{
			var response = await _client.GetAsync($"/api/Catalog/GetProductByCategory/{category}");
			var catalogs = await response.ReadContentAs<List<CatalogModel>>();
			return catalogs!;
		}
	}
}
