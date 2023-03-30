using Attorney.Manager.Repository.Context;
using Microsoft.EntityFrameworkCore;
using WeatherBotV1.Mapping;
using WeatherBotV1.Services.OpenMeteo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IOpenMeteoService, OpenMeteoService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(cfg => { cfg.AddMaps(typeof(MappingProfile).Assembly); } );
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddDbContext<DataContext>(options => 
    options.UseMySql("server=127.0.0.1;port=3306;database=wether_data;Uid=root;Pwd=12345;", new MySqlServerVersion(new Version(8, 0, 30)))
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

app.Run();
