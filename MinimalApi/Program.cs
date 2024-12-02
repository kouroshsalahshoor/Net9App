using Microsoft.AspNetCore.Cors;
using MinimalApi.models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

#region services

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

var name = builder.Configuration.GetValue<string>("name");

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

app.MapGet("/", () => name);
app.MapGet("/genres", [EnableCors("free")] () =>
{
    var models = new List<Genre>();

    for (int i = 1; i <= 10; i++)
    {
        models.Add(new Genre() { Id = i, Name = "Genre " + i.ToString() });
    }
    return models;
});

#endregion

app.Run();
