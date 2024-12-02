using Application.Repository;
using Infrastructure.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using MinimalApi.models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

#region services

var name = builder.Configuration.GetValue<string>("name");

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(config =>
    {
        //config.WithOrigins(builder.Configuration["allowedOrigins]!)
        config.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });

    options.AddPolicy("free", config => { config.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });

});

builder.Services.AddOutputCache();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<ICategoryRepository , CategoryRepository>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

#region middleware
app.UseCors("free");

app.UseOutputCache();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => name).CacheOutput();

var categoriesGroup = app.MapGroup("/categories");
categoriesGroup.MapGet("/", async (ICategoryRepository repository) =>
{
    return Results.Ok(await repository.Get());
});

categoriesGroup.MapGet("/{id}", async (ICategoryRepository repository, int id) =>
{
    var model = await repository.Get(id);

    if (model is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(model);
});

app.MapGet("/genres", [EnableCors("free")] () =>
{
    var models = new List<Genre>();

    for (int i = 1; i <= 10; i++)
    {
        models.Add(new Genre() { Id = i, Name = "Genre " + i.ToString() });
    }
    return models;
}).CacheOutput(x=>x.Expire(TimeSpan.FromSeconds(10)));

#endregion

app.Run();
