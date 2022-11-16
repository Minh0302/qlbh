using Microsoft.EntityFrameworkCore;
using NLog;
using Test.Data;
using Test.Helpers;
using Test.Repositories;
using Test.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("QLBH"));
});
builder.Services.AddScoped(typeof(IGenerictRepository<>), typeof(GenerictRepository<>));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IBuyOrderService, BuyOrderService>();
builder.Services.AddScoped<IBuyOrderDetailService, BuyOrderDetailService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddAutoMapper(typeof(Program));
LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/Helpers/nlog.config"));
builder.Services.AddScoped<ILoggerManager, LoggerManager>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
