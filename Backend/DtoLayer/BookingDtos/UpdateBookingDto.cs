using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.BookingDtos
{
    public class UpdateBookingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime Date { get; set; }
        public string ReservationStatus { get; set; }

    }
}
