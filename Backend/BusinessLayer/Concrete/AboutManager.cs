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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TAdd(About entity)
        {
            _aboutDal.Add(entity);
        }

        public void TDelete(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public async Task<About> TGetByIdAsync(int id)
        {
            return await _aboutDal.GetByIdAsync(id);
        }

        public async Task<IEnumerable<About>> TGetListAsync()
        {
            return await _aboutDal.GetListAsync();
        }

        public void TUpdate(About entity)
        {
            _aboutDal.Update(entity);
        }
    }
}
