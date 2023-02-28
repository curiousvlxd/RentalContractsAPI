using Microsoft.EntityFrameworkCore;
using RentalContractsAPI.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );
builder.Services.AddDbContext<RentalContractsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RentalContractsContext")));
builder.Services.AddScoped<RentalContractsContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(с =>
{
    с.SwaggerDoc("v1", new()
    {
        Title = "RentalContracts API",
        Description = "Сервіс розміщення технологічного обладнання виробничих приміщень.",
        Contact = new()
        {
            Name = "Тімченко Владислав Олексійович",
            Email = "vlxdtimchenko@gmail.com",
            Url = new Uri("https://github.com/curiousvlxd")
        },
        Version = "v1"
    });        
});

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();