using Persistence.Core;
using Application.Core;
using Domain.Helpers;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host("amqp://guest:guest@localhost:5672");
    });
});

//config.AddMassTransit(x =>
//{
//    x.UsingRabbitMq((cntxt, cfg) =>
//    {
//        cfg.Host("localhost", "/", c =>
//        {
//            c.Username("guest");
//            c.Password("guest");
//        });
//    });
//}));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterPersistence(builder.Configuration["Database"].ToString());
builder.Services.RegisterApplication();
builder.Services.RegisterDomain();
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
