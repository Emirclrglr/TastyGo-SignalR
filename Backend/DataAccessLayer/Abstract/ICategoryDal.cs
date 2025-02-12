using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.EntityLayer.Concrete;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface ICategoryDal:IGenericDal<Category>
    {
        void SetStatusActive(int id);
        void SetStatusPassive(int id);
        Task<int> CategoryCountAsync();
        Task<string> GetLastCreatedCategory();
        Task<int> ActiveCategoryCountAsync();
        Task<int> PassiveCategoryCountAsync();
    }
}
