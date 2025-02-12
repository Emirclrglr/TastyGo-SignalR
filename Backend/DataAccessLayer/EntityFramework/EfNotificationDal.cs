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
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        private readonly Context _context;
        public EfNotificationDal(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Notification>> GetAllNotificationsByStatusFalse()
        {
            return await _context.Notifications.Where(x=>x.Status == false).ToListAsync();
        }

        public int NotificationCountByStatusFalse()
        {
            return _context.Notifications.Where(x => x.Status == false).Count();
        }

        public void SetNotificationStatusRead(int id)
        {
            var value = _context.Notifications.Find(id);
            value.Status = true;
            _context.SaveChanges();
        }

        public void SetNotificationStatusUnread(int id)
        {
            var value = _context.Notifications.Find(id);
            value.Status = false;
            _context.SaveChanges();
        }
    }
}
