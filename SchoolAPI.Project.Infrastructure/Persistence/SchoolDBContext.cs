using Microsoft.EntityFrameworkCore;
using SchoolAPI.Project.Domain.Entities;

namespace SchoolAPI.Project.Infrastructure.Persistence;

public class SchoolDBContext : DbContext
{
    public SchoolDBContext(DbContextOptions<SchoolDBContext> options) : base(options)
    { }

    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(256);

            entity.HasIndex(e => e.Email)
                .IsUnique();

            entity.Property(e => e.DateOfBirth)
                .IsRequired();

            entity.Property(e => e.CreatedOn)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            entity.Property(e => e.UpdatedAt);
            
            entity.Ignore(e => e.Age);
        });
    }

}
