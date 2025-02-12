using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.EntityLayer.Concrete;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IOrderService:IGenericService<Order>
    {
        Task<int> TotalOrderCount(); 
        Task<int> TActiveOrderCount();
        Task<int> TPassiveOrderCount();
        Task<decimal> TTotalPriceOfLatestOrder();
        Task<decimal> TTodaysEarnings();


    }
}
