using Application.Interfaces;
using Application.UseCases;
using Infrastructure.Database;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//DI
var services = builder.Services;
services.AddScoped<ITaskRepository, TaskRepository>();
services.AddScoped<CreateTaskUseCase, CreateTaskUseCase>();
services.AddScoped<GetTasksUseCase, GetTasksUseCase>();
services.AddScoped<GetTaskUseCase, GetTaskUseCase>();
services.AddScoped<UpdateTaskUseCase, UpdateTaskUseCase>();
services.AddScoped<DeleteTaskUseCase, DeleteTaskUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
