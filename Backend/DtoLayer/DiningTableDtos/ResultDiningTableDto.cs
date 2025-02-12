using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.DiningTableDtos
{
    public class ResultDiningTableDto
    {
        public int Id { get; set; }
        public string DiningTableName { get; set; }
        public bool Status { get; set; }
    }
}
