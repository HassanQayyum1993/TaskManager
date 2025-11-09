namespace TaskManager.Domain.Entities
{
    public class UserTicket
    {
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
