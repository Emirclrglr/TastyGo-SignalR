using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Concrete;

namespace SignalR.BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public async Task<int> TActiveOrderCount()
        {
            return await _orderDal.ActiveOrderCount();
        }

        public void TAdd(Order entity)
        {
            _orderDal.Add(entity);
        }

        public void TDelete(Order entity)
        {
             _orderDal.Delete(entity);
        }

        public async Task<Order> TGetByIdAsync(int id)
        {
            return await _orderDal.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Order>> TGetListAsync()
        {
            return await _orderDal.GetListAsync();
        }

        public async Task<int> TotalOrderCount()
        {
            return await _orderDal.TotalOrderCount();
        }

        public async Task<int> TPassiveOrderCount()
        {
            return await _orderDal.PassiveOrderCount();
        }

        public async Task<decimal> TTodaysEarnings()
        {
            return await _orderDal.TodaysEarnings();
        }

        public async Task<decimal> TTotalPriceOfLatestOrder()
        {
            return await _orderDal.TotalPriceOfLatestOrder();
        }

        public void TUpdate(Order entity)
        {
            _orderDal.Update(entity);
        }
    }
}
