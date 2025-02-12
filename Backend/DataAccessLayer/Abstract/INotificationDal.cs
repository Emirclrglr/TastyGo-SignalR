using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.EntityLayer.Concrete;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface INotificationDal:IGenericDal<Notification>
    {
        int NotificationCountByStatusFalse();
        Task<IEnumerable<Notification>> GetAllNotificationsByStatusFalse();
        void SetNotificationStatusRead(int id);
        void SetNotificationStatusUnread(int id);
    }
}
