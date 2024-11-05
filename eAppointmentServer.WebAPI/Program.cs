using DefaultCorsPolicyNugetPackage;
using eAppointmentServer.Application;
using eAppointmentServer.Infrastructure;

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

app.Run();
