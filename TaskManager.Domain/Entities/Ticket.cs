using System.ComponentModel.DataAnnotations;

namespace TaskManager.Domain.Entities
{
    public enum TicketType { Epic, Story, Task }

    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TicketType Type { get; set; }
        public int? ParentTicketId { get; set; }
        public Ticket? ParentTicket { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;
        public string TenantId { get; set; } = string.Empty;

        [Timestamp]
        public byte[] RowVersion { get; set; } = null!;
    }
}
