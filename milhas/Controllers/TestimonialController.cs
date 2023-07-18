using Microsoft.AspNetCore.Mvc;
using Milhas.API.Envelopes;
using Milhas.Domain.Testimonial;

namespace Milhas.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestimonialController : ControllerBase
{
    private readonly ITestimonialRepository _testimonialRepository;

    public TestimonialController(ITestimonialRepository testimonialRepository)
    {
        _testimonialRepository = testimonialRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] TestimonialRQ req)
    {
        var imagesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
        if (!Directory.Exists(imagesDirectory))
            Directory.CreateDirectory(imagesDirectory);

        var path = Path.Combine(imagesDirectory, req.Image.FileName);
        using (var stream = new FileStream(path, FileMode.Create))
        {
            await req.Image.CopyToAsync(stream);
        }

        var testimonial = new Testimonial
        {
            Name = req.Name,
            Testimony = req.Testimony,
            ImagePath = path
        };

        await _testimonialRepository.AddAsync(testimonial);

        return CreatedAtAction(nameof(Get), new { id = testimonial.Id }, testimonial);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var testimonials = await _testimonialRepository.GetAllAsync();
        return Ok(testimonials);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var testimonial = await _testimonialRepository.GetByIdAsync(id);
        if (testimonial == null)
        {
            return NotFound();
        }
        return Ok(testimonial);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, TestimonialRQ req)
    {
        var testimonial = new Testimonial
        {
            Id = id,
            Name = req.Name,
            Testimony = req.Testimony,
        };

        await _testimonialRepository.UpdateAsync(testimonial);
        
        return Ok(testimonial);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _testimonialRepository.DeleteAsync(id);
        return Ok();
    }
}
