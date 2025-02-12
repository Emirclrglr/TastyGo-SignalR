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
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public void TAdd(Testimonial entity)
        {
            _testimonialDal.Add(entity);
        }

        public void TDelete(Testimonial entity)
        {
            _testimonialDal.Delete(entity);
        }

        public async Task<Testimonial> TGetByIdAsync(int id)
        {
            return await _testimonialDal.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Testimonial>> TGetListAsync()
        {
            return await _testimonialDal.GetListAsync();
        }

        public void TSetTestimonialActive(int id)
        {
            _testimonialDal.SetTestimonialActive(id);
        }

        public void TSetTestimonialPassive(int id)
        {
            _testimonialDal.SetTestimonialPassive(id);
        }

        public async Task<int> TTestimonialCountAsync()
        {
            return await _testimonialDal.TestimonialCountAsync();
        }

        public void TUpdate(Testimonial entity)
        {
            _testimonialDal.Update(entity);
        }
    }
}
