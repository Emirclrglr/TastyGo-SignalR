using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.EntityLayer.Concrete;

namespace SignalR.BusinessLayer.Abstract
{
    public interface ICategoryService:IGenericService<Category>
    {
        void TSetStatusActive(int id);
        void TSetStatusPassive(int id);
        Task<int> TCategoryCountAsync();
        Task<string> TGetLastCreatedCategory();
        Task<int> TActiveCategoryCountAsync();
        Task<int> TPassiveCategoryCountAsync();       


    }
}
