namespace SignalR.EntityLayer.Concrete
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
