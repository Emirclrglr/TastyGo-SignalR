using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repository;
using SignalR.DtoLayer.ProductDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        private readonly Context _context;
        public EfProductDal(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<int> AverageProductPrice()
        {
            var avg = await _context.Products.AverageAsync(x => x.ProductPrice);
            return (int)avg;
        }

        public async Task<int> AverageProductPriceByCategoryName(string categoryName)
        {
            var avg = await _context.Products.Where(x=>x.Category.CategoryName.Contains(categoryName)).AverageAsync(x=>x.ProductPrice);
            return (int)avg;
        }

        public async Task<string> CheapestProduct()
        {
            return await _context.Products.OrderBy(x => x.ProductPrice).Select(x => x.ProductName).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ResultProductDto>> GetProductsWithCategoryAsync()
        {
            var values = await _context.Products.Select(y => new ResultProductDto
            {
                Id = y.Id,
                CategoryName = y.Category.CategoryName,
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                ProductName = y.ProductName,
                ProductPrice = y.ProductPrice,
                Status = y.Status
            }).ToListAsync();
            return values;
        }

        public async Task<string> MostExpensiveProduct()
        {
            return await _context.Products.OrderByDescending(x => x.ProductPrice).Select(x => x.ProductName).FirstOrDefaultAsync();

        }

        public async Task<int> ProductCountAsync()
        {
            return await _context.Products.CountAsync();
        }

        public async Task<int> ProductCountByCategoryName(string categoryName)
        {
            return await _context.Products.Where(x => x.Category.CategoryName.Contains(categoryName)).CountAsync();
        }

        public void SetProductStatusActive(int id)
        {
            var value = _context.Products.Find(id);
            value.Status = true;
            _context.SaveChanges();
        }

        public void SetProductStatusPassive(int id)
        {
            var value = _context.Products.Find(id);
            value.Status = false;
            _context.SaveChanges();
        }

        public async Task<decimal> TotalProductPrice()
        {
            return await _context.Products.SumAsync(x=>x.ProductPrice);
        }
    }
}
