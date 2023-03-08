using BackEnd.Models;
using BackEnd.Services;
using Microsoft.EntityFrameworkCore;
using BackEnd.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TestDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestDBConnection")));

builder.Services.AddScoped<IMonedaService, MonedaService>();
builder.Services.AddScoped<ISucursalService, SucursalService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddCors(opt =>
    {
        opt.AddPolicy("CorsPolicy", policy => { policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
    }
);

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

app.UseCors("CorsPolicy");

app.Run();