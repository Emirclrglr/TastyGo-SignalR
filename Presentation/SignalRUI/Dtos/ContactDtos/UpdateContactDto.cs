namespace SignalR.UI.Dtos.ContactDtos
{
    public class UpdateContactDto
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string FooterDescription { get; set; }
        public string FooterDescriptionTitle { get; set; }
        public string OpenDays { get; set; }
        public string OpenDaysDescription { get; set; }
        public string OpeningHours { get; set; }
    }
}
