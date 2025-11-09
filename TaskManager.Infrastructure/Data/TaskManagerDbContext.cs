using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Data
{
    public class TaskManagerDbContext : DbContext
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options) { }

        public DbSet<Organization> Organizations => Set<Organization>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserTicket> TicketAssignments => Set<UserTicket>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relationships
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Organization)
                .WithMany(o => o.Projects)
                .HasForeignKey(p => p.OrganizationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Tickets)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserTicket>()
                .HasKey(x => new { x.TicketId, x.UserId });
        }
    }
}
