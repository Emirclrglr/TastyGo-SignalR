using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Concrete
{
    public class DiningTable
    {
        public int Id { get; set; }
        public string DiningTableName { get; set; }
        public bool Status { get; set; }
        public ICollection<Basket> Baskets { get; set; }
    }
}
