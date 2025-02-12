using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.DtoLayer.ProductDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IProductDal:IGenericDal<Product>
    {
        Task<IEnumerable<ResultProductDto>> GetProductsWithCategoryAsync();
        void SetProductStatusActive(int id);
        void SetProductStatusPassive(int id);
        Task<int> ProductCountAsync();
        Task<int> ProductCountByCategoryName(string categoryName);
        Task<string> MostExpensiveProduct();
        Task<string> CheapestProduct();
        Task<int> AverageProductPrice();
        Task<int> AverageProductPriceByCategoryName(string categoryName);
        Task<decimal> TotalProductPrice();
    }
}
