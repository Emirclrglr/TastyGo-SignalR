using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Concrete;

namespace SignalR.BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void TAdd(Notification entity)
        {
            _notificationDal.Add(entity);
        }

        public void TDelete(Notification entity)
        {
            _notificationDal.Delete(entity);
        }

        public async Task<IEnumerable<Notification>> TGetAllNotificationsByStatusFalse()
        {
            return await _notificationDal.GetAllNotificationsByStatusFalse();
        }

        public async Task<Notification> TGetByIdAsync(int id)
        {
            return await _notificationDal.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Notification>> TGetListAsync()
        {
            return await _notificationDal.GetListAsync();
        }

        public int TNotificationCountByStatusFalse()
        {
            return _notificationDal.NotificationCountByStatusFalse();
        }

        public void TSetNotificationStatusRead(int id)
        {
            _notificationDal.SetNotificationStatusRead(id);
        }

        public void TSetNotificationStatusUnread(int id)
        {
            _notificationDal.SetNotificationStatusUnread(id);
        }

        public void TUpdate(Notification entity)
        {
            _notificationDal.Update(entity);
        }
    }
}
