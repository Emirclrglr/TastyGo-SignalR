using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repository;
using SignalR.EntityLayer.Concrete;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfTestimonialDal : GenericRepository<Testimonial>, ITestimonialDal
    {
        private readonly Context _context;
        public EfTestimonialDal(Context context) : base(context)
        {
            _context = context;
        }

        public void SetTestimonialActive(int id)
        {
            var value = _context.Testimonials.Find(id);
            value.Status = true;
            _context.SaveChanges();
        }

        public void SetTestimonialPassive(int id)
        {
            var value = _context.Testimonials.Find(id);
            value.Status = false;
            _context.SaveChanges();
        }

        public async Task<int> TestimonialCountAsync()
        {
            return await _context.Testimonials.CountAsync();
        }
    }
}
