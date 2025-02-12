namespace SignalR.EntityLayer.Concrete
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal ProductPrice { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Basket> Baskets { get; set; }
    }
}
