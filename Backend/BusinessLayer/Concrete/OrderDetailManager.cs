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
    public class OrderDetailManager:IOrderDetailService
    {
        private readonly IOrderDetailDal _OrderDetailDal;

        public OrderDetailManager(IOrderDetailDal OrderDetailDal)
        {
            _OrderDetailDal = OrderDetailDal;
        }

        public void TAdd(OrderDetail entity)
        {
            _OrderDetailDal.Add(entity);
        }

        public void TDelete(OrderDetail entity)
        {
            _OrderDetailDal.Delete(entity);
        }

        public async Task<OrderDetail> TGetByIdAsync(int id)
        {
            return await _OrderDetailDal.GetByIdAsync(id);
        }

        public async Task<IEnumerable<OrderDetail>> TGetListAsync()
        {
            return await _OrderDetailDal.GetListAsync();
        }

        public void TUpdate(OrderDetail entity)
        {
            _OrderDetailDal.Update(entity);
        }
    }
}
