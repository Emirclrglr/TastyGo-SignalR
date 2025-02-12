namespace SignalR.UI.Dtos.BasketDtos
{
    public class ResultBasketDto
    {
        public int Id { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductCount { get; set; }
        public decimal TotalPrice { get; set; }
        public string DiningTableName { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int DiningTableId { get; set; }
    }
}
