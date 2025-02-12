using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.EntityLayer.Concrete;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IDiningTableService:IGenericService<DiningTable>
    {
        Task<int> TDiningTableCountAsync();
        void TChangeDiningTableStatusToTrue(int id);
        void TChangeDiningTableStatusToFalse(int id);
    }
}
