using AircraftParkingPlanning;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var setup = new Setup();
builder.Services.AddSingleton(setup);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(options =>
{
  options.WithOrigins("http://localhost:3000")
    .WithMethods(HttpMethods.Get)
    .WithMethods(HttpMethods.Post)
    .WithExposedHeaders(HeaderNames.ContentType)
    .WithHeaders(HeaderNames.ContentType);
});
app.MapControllers();

app.Run();
