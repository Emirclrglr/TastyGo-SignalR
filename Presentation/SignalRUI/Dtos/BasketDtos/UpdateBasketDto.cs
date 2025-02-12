namespace SignalR.UI.Dtos.BasketDtos
{
    public class UpdateBasketDto
    {
        public int Id { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductCount { get; set; }
        public decimal TotalPrice { get; set; }
        public int DiningTableId { get; set; }
        public int ProductId { get; set; }
    }
}
