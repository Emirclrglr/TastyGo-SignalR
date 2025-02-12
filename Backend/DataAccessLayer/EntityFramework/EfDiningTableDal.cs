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
    public class EfDiningTableDal : GenericRepository<DiningTable>, IDiningTableDal
    {
        private readonly Context _context;
        public EfDiningTableDal(Context context) : base(context)
        {
            _context = context;
        }

        public void ChangeDiningTableStatusToFalse(int id)
        {
            var value = _context.DiningTables.Find(id);
            value.Status = false;
            _context.SaveChanges();
        }

        public void ChangeDiningTableStatusToTrue(int id)
        {
            var value = _context.DiningTables.Find(id);
            value.Status = true;
            _context.SaveChanges();
        }

        public async Task<int> DiningTableCountAsync()
        {
            return await _context.DiningTables.CountAsync();
        }
    }
}
