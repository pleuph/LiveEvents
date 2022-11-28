using LiveEvents.Data;
using LiveEvents.Data.Repositories;
using LiveEvents.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LiveEventsDbContext>(options =>
    options.UseSqlServer("Server=localhost;Database=LiveEvents;Integrated Security=True;TrustServerCertificate=True;"));

builder.Services.AddTransient<ILiveEventParticipantRepository, LiveEventParticipantRepository>();
builder.Services.AddTransient<ILiveEventParticipantService, LiveEventParticipantService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
