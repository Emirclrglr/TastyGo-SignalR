namespace SignalR.UI.Dtos.BookingDtos
{
    public class UpdateBookingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime Date { get; set; }
    }
}
