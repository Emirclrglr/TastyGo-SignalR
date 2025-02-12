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
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        private readonly Context _context;
        public EfDiscountDal(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<int> AvgDiscountRate()
        {
            List<Discount> discounts = await _context.Discounts.ToListAsync();
            int discountRate = 0;
            foreach (var item in discounts)
            {
                discountRate += int.Parse(item.DiscountRate);
            }
            return discountRate / discounts.Count();
        }
    }
}
