using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Visiotech_API.Data;
using Visiotech_API.Extensions;
using Visiotech_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PostgresDbContext>(options =>
{
    options.UseNpgsql(
        "Host=postgres_db;Database=visiotech;Username=user;Password=Bz3kW.AJT7MV8t@",
        options =>
        {
            options.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "vineyards");
            options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            options.CommandTimeout(1500);
            options.EnableRetryOnFailure();
        });
});

builder.Services.AddScoped<VisiotechService>();

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
