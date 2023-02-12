using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Database
{
    public partial class AppointmentDbContext: DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options)
        : base(options)
        {
        }
        public DbSet<Appointment> Appoinments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
            modelBuilder.Entity<Appointment>(entity=>
            {
                entity.ToTable(nameof(Appointment));
                entity.Property(e => e.AppId).HasColumnType("Integer");
                entity.Property(e=> e.Name).HasColumnType("Varchar(20)");
                entity.Property(e => e.Email).HasColumnType("Varchar(100)");
                entity.Property(e => e.PhoneNo).HasColumnType("Varchar(20)");
                entity.Property(e => e.StartDate).HasColumnType("DateTime");
                entity.Property(e => e.EndDate).HasColumnType("DateTime");
                entity.Property(e => e.Date).HasColumnType("DateTime");
                entity.HasKey(e => e.AppId);
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
