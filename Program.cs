using Microsoft.EntityFrameworkCore;
using Student_Registration.DbContexts;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
string ConnectionStringSettings = builder.Configuration.GetConnectionString("Student_RegistrationContext");
builder.Services.AddDbContext<RegistrationDbContext>(options => options.UseMySql(ConnectionStringSettings, ServerVersion.AutoDetect(ConnectionStringSettings)));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(option =>
option.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod())
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseRouting();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
