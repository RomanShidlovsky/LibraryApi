using Application;
using Persistence;
using Persistence.Context;
using Persistence.Seed;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.ConfigurePersistence(builder.Configuration);
builder.Services.ConfigureApplication();
builder.Services.ConfigureApiBehavior();
builder.Services.ConfigureCorsPolicy();
builder.Services.ConfigureJwtBearerAuthentication(builder.Configuration);
builder.Services.ConfigureSwagger();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var serviceScope = app.Services.CreateScope();
var dataContext = serviceScope.ServiceProvider.GetService<DataContext>();
dataContext?.Database.EnsureCreated();

var seedInitializer = serviceScope.ServiceProvider.GetRequiredService<SeedInitializer>();
await seedInitializer.Init();

app.UseHttpsRedirection();
app.UseCors();
app.UseErrorHandler();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();