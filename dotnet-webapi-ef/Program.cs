using dotnet_webapi_ef.DataContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
 
builder.Services.AddDbContext<VideoGameDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection"), o => o.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "videogame")));

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection"), o => o.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "users")));

// This option is optimize for READ-ONLY 
// builder.Services.AddDbContext<UserContext>(options =>
//    options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection"))
//        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<UserDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();