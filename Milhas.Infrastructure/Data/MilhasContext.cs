using Microsoft.EntityFrameworkCore;
using Milhas.Domain.Testimonial;

namespace Milhas.Infrastructure.Data;
public class MilhasContext : DbContext
{
    public DbSet<Testimonial> Testimonials { get; set; }

    public MilhasContext(DbContextOptions<MilhasContext> opts) : base(opts) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
