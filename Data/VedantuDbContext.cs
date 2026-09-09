using Microsoft.EntityFrameworkCore;
using Vedantu.Models;

namespace Vedantu.Data;

public class VedantuDbContext : DbContext
{
    public VedantuDbContext(DbContextOptions<VedantuDbContext> options) : base(options) { }

    public DbSet<Student> Students => Set<Student>();
}
