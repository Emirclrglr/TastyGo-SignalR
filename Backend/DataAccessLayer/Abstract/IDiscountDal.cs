using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.EntityLayer.Concrete;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IDiscountDal:IGenericDal<Discount>
    {
        Task<int> AvgDiscountRate();
    }
}
