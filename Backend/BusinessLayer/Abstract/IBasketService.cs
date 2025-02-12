using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.DtoLayer.BasketDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IBasketService:IGenericService<Basket>
    {
        Task<IEnumerable<ResultBasketWithRelationsDto>> TGetBasketListWithRelations(); 
        Task<IEnumerable<ResultBasketWithRelationsDto>> TGetBasketListWithRelationsByTableNumber(int tableNumber);
        Task<IEnumerable<Basket>> TGetBasketByTableNumber(int tableNumber);
        Task<int> TGetBasketProductCountByTableNumber(int tableNumber);
        void TDeleteBasketItem(int productId, int basketId);

    }
}
