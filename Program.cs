using DapperData.Data;
using DapperData.Repositary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//interface for database helper
builder.Services.AddTransient<IDataAccess, DataAccess>();
//interface for repositary
builder.Services.AddTransient<IUserRepositary, UserRepositary>();
// Add services to the container.
builder.Services.AddControllersWithViews();
//Enable cors horizon request
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
    builder => builder
 .WithOrigins("https://localhost:7138")
 .AllowAnyMethod()
 .AllowAnyHeader()
 .AllowCredentials()
 .SetPreflightMaxAge(TimeSpan.FromSeconds(86400)));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//enable cors
app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
