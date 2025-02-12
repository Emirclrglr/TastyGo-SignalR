using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.BasketDtos
{
    public class ResultBasketWithRelationsDto
    {
        public int Id { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductCount { get; set; }
        public decimal TotalPrice { get; set; }
        public string DiningTableName { get; set; }
        public string ProductName { get; set; }
    }
}
