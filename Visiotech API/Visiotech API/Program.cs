using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Visiotech_API.Data;
using Visiotech_API.Extensions;
using Visiotech_API.Models;
using Visiotech_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
AppConfiguration config = new(builder.Configuration);
builder.Services.AddSingleton(config);

builder.Services.AddDbContext<PostgresDbContext>(options =>
{
    options.UseNpgsql(
        config.ConnectionString,
        options =>
        {
            options.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "vineyards"); // Si se modifica hay que cambiarlo tambi�n en PostgresDbContext
            options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            options.CommandTimeout(1500);
            options.EnableRetryOnFailure();
        });
});

builder.Services.AddScoped<IVisiotechService, VisiotechService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseDatabase();

app.Run();
