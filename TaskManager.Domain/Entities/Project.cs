namespace TaskManager.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; } = null!;
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
