using Microsoft.EntityFrameworkCore;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    // Membuat table Medicine
    public DbSet<Medicine> Medicines { get; set; }
}