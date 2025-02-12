using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.ProductDtos
{
    public class ResultProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal ProductPrice { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
        public string CategoryName { get; set; }
    }
}
