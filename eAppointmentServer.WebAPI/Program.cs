using eAppointmentServer.Application;
using eAppointmentServer.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication(); //DI extension metodu
builder.Services.AddInfrastructure(builder.Configuration); //DI extension metodu

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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