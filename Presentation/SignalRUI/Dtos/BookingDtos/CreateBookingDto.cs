namespace SignalR.UI.Dtos.BookingDtos
{
    public class CreateBookingDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime Date { get; set; }
    }
}
