using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.DtoLayer.BasketDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IBasketDal:IGenericDal<Basket>
    {
        Task<IEnumerable<ResultBasketWithRelationsDto>> GetBasketListWithRelations();
        Task<IEnumerable<ResultBasketWithRelationsDto>> GetBasketListWithRelationsByTableNumber(int tableNumber);
        Task<IEnumerable<Basket>> GetBasketByTableNumber(int tableNumber);
        Task<int> GetBasketProductCountByTableNumber(int tableNumber);
        void DeleteBasketItem(int productId, int basketId);
    }
}
