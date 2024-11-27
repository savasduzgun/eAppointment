using DefaultCorsPolicyNugetPackage;
using eAppointmentServer.Application;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Infrastructure;
using eAppointmentServer.WebAPI;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

//api nin d��ar�dan kullan�labilmesi i�in cors politikas�, tek bir uygulama var o da api yi t�ketece�i i�in herkese a��k bir endpoint gibi yaz�l�r nuget paket kurulur. DefaultCorsPolicy
builder.Services.AddDefaultCors();

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

app.UseCors(); //Cors politikas� kullan�laca�� belirtiliyor

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

Helper.CreateUserAsync(app).Wait(); //kullan�c� yoksa olu�turmak i�in Helper class �n� kullan�r.

app.Run();
