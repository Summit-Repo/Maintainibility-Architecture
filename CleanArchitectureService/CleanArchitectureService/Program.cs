using Application;
using AutoMapper;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.GetRepositoryDependency(builder.Configuration);
builder.Services.GetBusinessRuleDependency();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());





var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
