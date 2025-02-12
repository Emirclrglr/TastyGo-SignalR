using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DtoLayer.ProductDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public async Task<int> TAverageProductPrice()
        {
            return await _productDal.AverageProductPrice();
        }

        public async Task<int> TAverageProductPriceByCategoryName(string categoryName)
        {
            return await _productDal.AverageProductPriceByCategoryName(categoryName);
        }

        public async Task<string> TCheapestProduct()
        {
            return await _productDal.CheapestProduct();
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public async Task<Product> TGetByIdAsync(int id)
        {
            return await _productDal.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> TGetListAsync()
        {
            return await _productDal.GetListAsync();
        }

        public async Task<IEnumerable<ResultProductDto>> TGetProductsWithCategoryAsync()
        {
            return await _productDal.GetProductsWithCategoryAsync();
        }

        public async Task<string> TMostExpensiveProduct()
        {
            return await _productDal.MostExpensiveProduct();
        }

        public async Task<int> TProductCountAsync()
        {
            return await _productDal.ProductCountAsync();
        }

        public async Task<int> TProductCountByCategoryName(string categoryName)
        {
            return await _productDal.ProductCountByCategoryName(categoryName);
        }

        public void TSetProductStatusActive(int id)
        {
            _productDal.SetProductStatusActive(id);
        }

        public void TSetProductStatusPassive(int id)
        {
            _productDal.SetProductStatusPassive(id);
        }

        public async Task<decimal> TTotalProductPrice()
        {
            return await _productDal.TotalProductPrice();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity); 
        }
    }
}
