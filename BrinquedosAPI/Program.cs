using Microsoft.EntityFrameworkCore;
using BrinquedosAPI.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configurar o DbContext com SQL Server
builder.Services.AddDbContext<BrinquedosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { 
        Title = "Brinquedos API", 
        Version = "v1", 
        Description = "API para gerenciamento de brinquedos" 
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Brinquedos API v1"));
}

// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
