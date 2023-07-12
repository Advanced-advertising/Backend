using System.Text.Json.Serialization;
using ADvanced.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();
string connection = "Server=(localdb)\\mssqllocaldb;Database=applicationdb;Trusted_Connection=True;";
builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
//builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();
 
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();
app.Run();