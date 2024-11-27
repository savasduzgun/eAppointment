using DefaultCorsPolicyNugetPackage;
using eAppointmentServer.Application;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Infrastructure;
using eAppointmentServer.WebAPI;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

//api nin dýþarýdan kullanýlabilmesi için cors politikasý, tek bir uygulama var o da api yi tüketeceði için herkese açýk bir endpoint gibi yazýlýr nuget paket kurulur. DefaultCorsPolicy
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

app.UseCors(); //Cors politikasý kullanýlacaðý belirtiliyor

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

Helper.CreateUserAsync(app).Wait(); //kullanýcý yoksa oluþturmak için Helper class ýný kullanýr.

app.Run();
