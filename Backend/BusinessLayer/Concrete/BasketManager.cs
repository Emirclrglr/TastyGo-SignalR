using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DtoLayer.BasketDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.BusinessLayer.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public void TAdd(Basket entity)
        {
            _basketDal.Add(entity);
        }

        public void TDelete(Basket entity)
        {
            _basketDal.Delete(entity);
        }

        public void TDeleteBasketItem(int productId, int basketId)
        {
            _basketDal.DeleteBasketItem(productId, basketId);
        }

        public async Task<IEnumerable<Basket>> TGetBasketByTableNumber(int tableNumber)
        {
            return await _basketDal.GetBasketByTableNumber(tableNumber);
        }

        public async Task<IEnumerable<ResultBasketWithRelationsDto>> TGetBasketListWithRelations()
        {
            return await _basketDal.GetBasketListWithRelations();
        }

        public async Task<IEnumerable<ResultBasketWithRelationsDto>> TGetBasketListWithRelationsByTableNumber(int tableNumber)
        {
            return await _basketDal.GetBasketListWithRelationsByTableNumber(tableNumber);
        }

        public async Task<int> TGetBasketProductCountByTableNumber(int tableNumber)
        {
            return await _basketDal.GetBasketProductCountByTableNumber(tableNumber);
        }

        public async Task<Basket> TGetByIdAsync(int id)
        {
            return await _basketDal.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Basket>> TGetListAsync()
        {
            return await _basketDal.GetListAsync();
        }

        public void TUpdate(Basket entity)
        {
            _basketDal.Update(entity);
        }
    }
}
