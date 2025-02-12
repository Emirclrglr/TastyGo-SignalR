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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        private readonly Context _context;
        public EfBookingDal(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<int> BookingCount()
        {
            return await _context.Bookings.CountAsync();
        }

        public void SetReservationStatusAccepted(int id)
        {
            var value = _context.Bookings.Find(id);
            value.ReservationStatus = "Rezervasyon Onaylandı";
            _context.SaveChanges();
        }

        public void SetReservationStatusDenied(int id)
        {
            var value = _context.Bookings.Find(id);
            value.ReservationStatus = "Rezervasyon Reddedildi";
            _context.SaveChanges();
        }
    }
}
