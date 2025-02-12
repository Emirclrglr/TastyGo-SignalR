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
    public class MoneySafeManager : IMoneySafeService
    {
        private readonly IMoneySafeDal _moneySafeDal;

        public MoneySafeManager(IMoneySafeDal moneySafeDal)
        {
            _moneySafeDal = moneySafeDal;
        }

        public void TAdd(MoneySafe entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(MoneySafe entity)
        {
            throw new NotImplementedException();
        }

        public Task<MoneySafe> TGetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MoneySafe>> TGetListAsync()
        {
            throw new NotImplementedException();
        }

        public decimal TTotalAmount()
        {
            return _moneySafeDal.TotalAmount();
        }

        public void TUpdate(MoneySafe entity)
        {
            throw new NotImplementedException();
        }
    }
}
