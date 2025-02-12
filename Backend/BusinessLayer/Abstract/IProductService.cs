using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.DtoLayer.ProductDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        Task<IEnumerable<ResultProductDto>> TGetProductsWithCategoryAsync();
        void TSetProductStatusActive(int id);
        void TSetProductStatusPassive(int id);
        Task<int> TProductCountAsync();
        Task<int> TProductCountByCategoryName(string categoryName);
        Task<string> TMostExpensiveProduct();
        Task<string> TCheapestProduct();
        Task<int> TAverageProductPrice();
        Task<int> TAverageProductPriceByCategoryName(string categoryName);
        Task<decimal> TTotalProductPrice();

    }
}
