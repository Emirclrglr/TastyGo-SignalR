using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repository;
using SignalR.DtoLayer.BasketDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        private readonly Context _context;
        public EfBasketDal(Context context) : base(context)
        {
            _context = context;
        }

        public void DeleteBasketItem(int productId, int basketId)
        {
            var value = _context.Baskets.Where(x => x.ProductId == productId && basketId == x.DiningTableId).FirstOrDefault();
            _context.Baskets.Remove(value);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Basket>> GetBasketByTableNumber(int tableNumber)
        {
            return await _context.Baskets.Where(x => x.DiningTableId == tableNumber).ToListAsync();
        }

        public async Task<IEnumerable<ResultBasketWithRelationsDto>> GetBasketListWithRelations()
        {
            return await _context.Baskets.Select(x => new ResultBasketWithRelationsDto
            {
                Id = x.Id,
                ProductCount = x.ProductCount,
                ProductPrice = x.ProductPrice,
                TotalPrice = x.TotalPrice,
                DiningTableName = x.DiningTable.DiningTableName,
                ProductName = x.Product.ProductName
            }).ToListAsync();
        }

        public async Task<IEnumerable<ResultBasketWithRelationsDto>> GetBasketListWithRelationsByTableNumber(int tableNumber)
        {
            return await _context.Baskets.Where(x => x.DiningTableId == tableNumber).Select(x => new ResultBasketWithRelationsDto
            {
                Id = x.Id,
                ProductCount = x.ProductCount,
                ProductPrice = x.ProductPrice,
                TotalPrice = x.TotalPrice,
                DiningTableName = x.DiningTable.DiningTableName,
                ProductName = x.Product.ProductName
            }).ToListAsync();
        }

        public async Task<int> GetBasketProductCountByTableNumber(int tableNumber)
        {
            return await _context.Baskets.Where(x=>x.DiningTableId == tableNumber).CountAsync();
        }
    }
}
