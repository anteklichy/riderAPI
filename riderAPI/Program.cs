//kontener konfiguracji naszej aplikacji

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using riderAPI.Modele;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//zbuduj serwisy w kontenerze
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/api/animals/{id:int}", (int id) =>
{
    var animal = DataBase.animals.FirstOrDefault(a => a.id == id);
    return animal is null ? Results.NotFound($"Student with {id} not found") : Results.Ok(animal);
});

app.MapPost("/api/animals", ([FromBody] Animal data) =>
{
    var animal = DataBase.animals.Exists(a => a.id == data.id);
    if (animal) return Results.Conflict($"Student with {data.id} already exists");
    return Results.Created($"/api/animals/{data.id}", data);
});

app.Run();
