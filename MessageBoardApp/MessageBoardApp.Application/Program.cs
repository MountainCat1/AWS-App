using MessageBoardApp.Application;
using MessageBoardApp.Application.Domain.Repositories;
using MessageBoardApp.Application.WebSockets;
using MessageBoardApp.Application.Service.CQRS;
using MessageBoardApp.Infrastructure.Contexts;
using MessageBoardApp.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebSocketHandlerCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddWebSocketManager();

if (builder.Environment.IsDevelopment())
    services.AddDbContext<MessageDbContext>(options => options.UseInMemoryDatabase("BaseDatabase"));
else
    services.AddDbContext<MessageDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("BaseDatabase")));

services.AddScoped<IBoardMessageRepository, BoardMessageRepository>();
services.AddAutoMapper(typeof(MappingProfile));

services.AddMediatR(typeof(CqrsAssemblyMarker));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseWebSockets();

app.MapWebSocketManager("/ws", app.Services.GetRequiredService<MessageWebSocketHandler>());

app.MapControllers();

app.UseCors(x => x
    .WithOrigins(Environment.GetEnvironmentVariable("ASPNETCORE_ALLOWED_ORIGINS")?.Split(";") ?? Array.Empty<string>())
    .AllowAnyMethod()
    .AllowCredentials()
    .AllowAnyHeader());

app.Run();