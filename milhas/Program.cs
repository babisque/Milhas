using Microsoft.EntityFrameworkCore;
using Milhas.Domain.Testimonial;
using Milhas.Infrastructure.Data;
using Milhas.Infrastructure.Respository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MilhasContext>(opts => 
    opts.UseSqlServer(builder.Configuration.GetConnectionString("Milhas"), opts => opts.MigrationsAssembly("Milhas.API")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();

var app = builder.Build();

/*
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
*/

app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();