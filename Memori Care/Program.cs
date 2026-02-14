using Memori_Care.Data;
using Memori_Care.Interfaces;
using Memori_Care.Profiles;
using Memori_Care.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

//1. Connection String
var connectionString = builder.Configuration.GetConnectionString("MemoriCareConnection");

// 2. Registrar o AppDbContext para usar SQL Server
builder.Services.AddDbContext<AppDbContext>(opts =>
    opts.UseSqlServer(connectionString));

// 3. Services
builder.Services.AddScoped<IPacienteService, PacienteService>();

// 4. Profile
builder.Services.AddAutoMapper(typeof(MemoriProfile));

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
