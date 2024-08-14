using NutritionTracker.Infrastructure;
using NutritionTracker.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services from other projects
builder.Services.AddDataSourceContext();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureRepositories();
builder.Services.AddInfrastructureServices();
builder.Services.AddInfrastructureAuthentication(builder.Configuration);

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
