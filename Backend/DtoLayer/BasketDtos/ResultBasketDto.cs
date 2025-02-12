using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.BasketDtos
{
    public class ResultBasketDto
    {
        public int Id { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductCount { get; set; }
        public decimal TotalPrice { get; set; }
        public int DiningTableId { get; set; }
        public int ProductId { get; set; }
    }
}
