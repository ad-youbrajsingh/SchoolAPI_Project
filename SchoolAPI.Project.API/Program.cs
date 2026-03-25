using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using SchoolAPI.Project.API.Middlewares;
using SchoolAPI.Project.Application.Interfaces;
using SchoolAPI.Project.Infrastructure;
using SchoolAPI.Project.Infrastructure.Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddMediatR(cff =>
{
    cff.RegisterServicesFromAssembly(Assembly.Load("SchoolAPI.Project.Application"));
});
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddAutoMapper(Assembly.Load("SchoolAPI.Project.Application"));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(Assembly.Load("SchoolAPI.Project.Application"));

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .Enrich.WithThreadId()
    .Enrich.WithMachineName()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
