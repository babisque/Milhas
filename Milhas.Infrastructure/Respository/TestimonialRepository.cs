using Microsoft.EntityFrameworkCore;
using Milhas.Domain.Testimonial;
using Milhas.Infrastructure.Data;

namespace Milhas.Infrastructure.Respository;
public class TestimonialRepository : ITestimonialRepository
{
    private readonly MilhasContext _context;

    public TestimonialRepository(MilhasContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Testimonial testimonial)
    {
        await _context.Testimonials.AddAsync(testimonial);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var testimonial = await _context.Testimonials.FindAsync(id);
        if (testimonial != null)
        {
            _context.Testimonials.Remove(testimonial);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Testimonial>> GetAllAsync()
    {
        return await _context.Testimonials.ToListAsync();
    }

    public async Task<Testimonial> GetByIdAsync(int id)
    {
        return await _context.Testimonials.FindAsync(id);
    }

    public async Task UpdateAsync(Testimonial testimonial)
    {
        _context.Testimonials.Update(testimonial);
        await _context.SaveChangesAsync();
    }
}
