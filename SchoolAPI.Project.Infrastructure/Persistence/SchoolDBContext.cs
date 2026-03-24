using Microsoft.EntityFrameworkCore;
using SchoolAPI.Project.Domain.Entities;

namespace SchoolAPI.Project.Infrastructure.Persistence;

public class SchoolDBContext : DbContext
{
    public SchoolDBContext(DbContextOptions<SchoolDBContext> options) : base(options)
    { }

    public DbSet<Student> Students { get; set; }

}
