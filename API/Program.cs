using Application.Repository;
using Application.Repository.IRepository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IJobCategoryRepository, JobCategoryRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

//https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-9.0
var _allowSpecificOrigins = "MyAllowSpecificOrigins";
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("open",
//        builder => builder.AllowAnyOrigin().AllowAnyHeader());
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: _allowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7207",
                                                    "http://www.xxx.com")
                                                    .AllowAnyHeader()
                                                    .AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(_allowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
