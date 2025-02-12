using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repository;
using SignalR.EntityLayer.Concrete;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        private readonly Context _context;
        public EfOrderDal(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<int> ActiveOrderCount()
        {
            return await _context.Orders.Where(x => x.Description == "Müşteri Masada").CountAsync();

        }

        public async Task<int> PassiveOrderCount()
        {
            return await _context.Orders.Where(x => x.Description == "Hesap Kapatıldı").CountAsync();
        }

        public async Task<decimal> TodaysEarnings()
        {
            return await _context.Orders.Where(x => x.OrderDate == DateTime.Today).SumAsync(x => x.TotalPrice);
        }

        public async Task<int> TotalOrderCount()
        {
            return await _context.Orders.CountAsync();
        }

        public async Task<decimal> TotalPriceOfLatestOrder()
        {
            return await _context.Orders.OrderByDescending(x => x.Id).Select(x => x.TotalPrice).FirstOrDefaultAsync();
        }
    }
}
