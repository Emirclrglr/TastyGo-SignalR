namespace SignalR.UI.Dtos.MessageDtos
{
    public class UpdateMessageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public DateTime MessageDate { get; set; }
        public bool Status { get; set; }
    }
}
