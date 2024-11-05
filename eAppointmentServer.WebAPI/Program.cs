using DefaultCorsPolicyNugetPackage;
using eAppointmentServer.Application;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Infrastructure;
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

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scoped = app.Services.CreateScope())
{
    var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    if (!userManager.Users.Any()) //kullanýcý yoksa oluþturur
    {
        userManager.CreateAsync(new()
        {
            FirstName = "Savas",
            LastName = "Duzgun",
            Email = "admin@admin.com",
            UserName = "admin"
        }, "1").Wait();
    }
}

app.Run();
