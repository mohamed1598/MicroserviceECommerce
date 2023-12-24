﻿namespace Shopping.Aggregator.Models
{
	public class CatalogModel
	{
		public string Id { get; set; } = null!;
		public string Name { get; set; } = string.Empty;
		public string Category { get; set; } = string.Empty;
		public string Summary { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string? ImageFile { get; set; }
		public decimal Price { get; set; }
	}
}