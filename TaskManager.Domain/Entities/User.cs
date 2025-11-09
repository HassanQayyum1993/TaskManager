namespace TaskManager.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public ICollection<UserTicket> UserTickets { get; set; } = new List<UserTicket>();
    }
}
