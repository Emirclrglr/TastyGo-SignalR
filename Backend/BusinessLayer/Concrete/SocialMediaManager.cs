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
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public void TAdd(SocialMedia entity)
        {
            _socialMediaDal.Add(entity);
        }

        public void TDelete(SocialMedia entity)
        {
            _socialMediaDal.Delete(entity);
        }

        public async Task<SocialMedia> TGetByIdAsync(int id)
        {
            return await _socialMediaDal.GetByIdAsync(id);
        }

        public async Task<IEnumerable<SocialMedia>> TGetListAsync()
        {
            return await _socialMediaDal.GetListAsync();
        }

        public void TUpdate(SocialMedia entity)
        {
            _socialMediaDal.Update(entity); 
        }
    }
}
