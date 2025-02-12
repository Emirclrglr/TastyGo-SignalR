using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.EntityLayer.Concrete;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IOrderDal:IGenericDal<Order>
    {
        Task<int> TotalOrderCount();
        Task<int> ActiveOrderCount();
        Task<int> PassiveOrderCount();
        Task<decimal> TotalPriceOfLatestOrder();
        Task<decimal> TodaysEarnings();
    }
}
