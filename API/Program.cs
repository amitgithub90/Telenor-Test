using API.Database;
using API.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppointmentDbContext>(options => options.UseSqlite("Name=AppoinmentDB"));
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddCors(option => option.AddPolicy("MyPolicy", builder => {
    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

}));

        
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API"); });
    
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();
app.MapControllers();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();
