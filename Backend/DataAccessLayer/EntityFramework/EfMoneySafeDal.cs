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
    public class EfMoneySafeDal : GenericRepository<MoneySafe>, IMoneySafeDal
    {
        private readonly Context _context;
        public EfMoneySafeDal(Context context) : base(context)
        {
            _context = context;
        }

        public decimal TotalAmount()
        {
            return _context.MoneySafes.Select(x => x.TotalAmount).FirstOrDefault();
        }
    }
}
