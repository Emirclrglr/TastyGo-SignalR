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
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void TAdd(Booking entity)
        {
            _bookingDal.Add(entity);
        }

        public async Task<int> TBookingCount()
        {
            return await _bookingDal.BookingCount();
        }

        public void TDelete(Booking entity)
        {
            _bookingDal.Delete(entity);
        }

        public async Task<Booking> TGetByIdAsync(int id)
        {
            return await _bookingDal.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Booking>> TGetListAsync()
        {
            return await _bookingDal.GetListAsync();
        }

        public void TSetReservationStatusAccepted(int id)
        {
            _bookingDal.SetReservationStatusAccepted(id);
        }

        public void TSetReservationStatusDenied(int id)
        {
            _bookingDal.SetReservationStatusDenied(id);
        }

        public void TUpdate(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}
