using NumberSortAPI.Interfaces;
using NumberSortAPI.Services;
using NumberSortAPI.SortingAlgorithms;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<SortingSpeedComparisonService>();
builder.Services.AddSingleton<IFileService, FileService>();
builder.Services.AddScoped<ISortAlgorithm, BubbleSort>();
builder.Services.AddScoped<NumberSortService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
