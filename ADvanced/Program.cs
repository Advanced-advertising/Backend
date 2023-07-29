using System.Text.Json.Serialization;
using ADvanced.Data;
using ADvanced.Data.Interfaces;
using ADvanced.Data.Repository;
using ADvanced.Dto;
using ADvanced.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder();
string connection = "Server=(localdb)\\mssqllocaldb;Database=advanceddb;Trusted_Connection=True;";
builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IRepository<Income>, IncomeRepository>();
builder.Services.AddScoped<IRepository<Address>, AddressRepository>();
builder.Services.AddScoped<IRepository<Ad>, AdRepository>();
builder.Services.AddScoped<IRepository<AdOrder>, AdOrderRepository>();
builder.Services.AddScoped<IRepository<Business>, BusinessRepository>();
builder.Services.AddScoped<IRepository<BusinessWorkingTime>, BussinesWorkingTimeRepository>();
builder.Services.AddScoped<IRepository<Payment>, PaymentRepository>();
builder.Services.AddScoped<IRepository<Screen>, ScreenRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

app.UseSerilogRequestLogging();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();
app.MapGet("/", () => $"Hello World!");
app.Run();