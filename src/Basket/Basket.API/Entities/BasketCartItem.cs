namespace Basket.API.Entities
{
    public class BasketCartItem
    {
        public int Quantity { get; set; }
        public string Color { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ProductId { get; set; } = null!;
        public string ProductName { get; set; } = null!;

    }
}