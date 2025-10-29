using Desafio.Data;
using Desafio.Helpers;
using Desafio.Services.Interfaces;
using Desafio.Services.Logicas;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DesafioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DesafioContext") ?? throw new InvalidOperationException("Connection string 'DesafioContext' not found.")));

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(typeof(Mapeamento));

builder.Services.AddScoped<IClienteBLL, ClienteBLL>();
builder.Services.AddScoped<ViaCepBLL>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
