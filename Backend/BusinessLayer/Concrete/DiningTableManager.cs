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
    public class DiningTableManager : IDiningTableService
    {
        private readonly IDiningTableDal _diningTableDal;

        public DiningTableManager(IDiningTableDal diningTableDal)
        {
            _diningTableDal = diningTableDal;
        }

        public void TAdd(DiningTable entity)
        {
            _diningTableDal.Add(entity);
        }

        public void TChangeDiningTableStatusToFalse(int id)
        {
            _diningTableDal.ChangeDiningTableStatusToFalse(id);
        }

        public void TChangeDiningTableStatusToTrue(int id)
        {
            _diningTableDal.ChangeDiningTableStatusToTrue(id);
        }

        public void TDelete(DiningTable entity)
        {
            _diningTableDal.Delete(entity);
        }

        public async Task<int> TDiningTableCountAsync()
        {
            return await _diningTableDal.DiningTableCountAsync();
        }

        public async Task<DiningTable> TGetByIdAsync(int id)
        {
            return await _diningTableDal.GetByIdAsync(id);
        }

        public async Task<IEnumerable<DiningTable>> TGetListAsync()
        {
            return await _diningTableDal.GetListAsync();
        }

        public void TUpdate(DiningTable entity)
        {
            _diningTableDal.Update(entity);
        }
    }
}
