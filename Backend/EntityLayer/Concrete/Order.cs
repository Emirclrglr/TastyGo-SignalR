using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Concrete
{
    public class Order
    {
        public int Id { get; set; }
        public string TableNo { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
