namespace Basket.API.Entities
{
    public class BasketCart
    {
        public string UserName { get; set; } = null!;
        public List<BasketCartItem> Items { get; set; } = [];
        public BasketCart()
        {
            
        }
        public BasketCart(string username)
        {
            UserName = username;    
        }
        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var item in Items)
                {
                    totalPrice += item.Price * item.Quantity;
                }
                return totalPrice;
            }
        }
    }
}
