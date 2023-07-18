namespace Milhas.Domain.Testimonial;
public interface ITestimonialRepository
{
    Task AddAsync(Testimonial testimonial);
    Task<IEnumerable<Testimonial>> GetAllAsync();
    Task<Testimonial> GetByIdAsync(int id);
    Task UpdateAsync(Testimonial testimonial);
    Task DeleteAsync(int id);
}
