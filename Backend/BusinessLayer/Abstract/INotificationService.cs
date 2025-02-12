using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.EntityLayer.Concrete;

namespace SignalR.BusinessLayer.Abstract
{
    public interface INotificationService:IGenericService<Notification>
    {
        int TNotificationCountByStatusFalse();
        Task<IEnumerable<Notification>> TGetAllNotificationsByStatusFalse();
        void TSetNotificationStatusRead(int id);
        void TSetNotificationStatusUnread(int id);

    }
}
