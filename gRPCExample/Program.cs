using gRPCServer.Procedures;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpc();

builder.WebHost
    .UseUrls()
    .UseKestrel()
    .ConfigureKestrel(options =>
    {
        var gRPCPort = 5229;
        var defaultProjectPort = 5228;
        options.Listen(IPAddress.Any, gRPCPort, listenOptions =>
        {
            listenOptions.Protocols = HttpProtocols.Http2;
        });
        options.Listen(IPAddress.Any, defaultProjectPort, listenOptions =>
        {
            listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
        });
    })
    .UseContentRoot(Directory.GetCurrentDirectory());

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

app.MapGrpcService<UserService>();

app.Run();
