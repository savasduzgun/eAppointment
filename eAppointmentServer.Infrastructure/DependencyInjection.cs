using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using eAppointmentServer.Infrastructure.Context;
using eAppointmentServer.Infrastructure.Repositories;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eAppointmentServer.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            });

            //User manager dependency injection ile çağrıldığında DbContext ile bağlı olarak kullanılabileceğini belirtir. User manager üzerinden bir create işlemi yapılırsa action da belirtilen password bilgilerini kullanması gerektiğini belirtir.
            services.AddIdentity<AppUser, AppRole>(action =>
            {
                action.Password.RequiredLength = 1;
                action.Password.RequireUppercase = false;
                action.Password.RequireLowercase = false;
                action.Password.RequireNonAlphanumeric = false;
                action.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();
            

            //AddScope yaşam türüyle beraber repositoryinterface i biri inject ederek isterse hangi repository class ını vermesi gerektiği belirtiliyor.
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();

            //RepositoryPattern de UnitOfWorkPattern de kullanıldığı için, UnitOfWork de kayıt silme ve güncelleme işlemlerinde SaveChange metodunu ayrı şekilde çağırıp transaction ayrı yönetebilmeyi sağlar.ApplicationDbContext classı inheritine IUnitOfWork de eklenir.
            //IUnitOfWork inherit edildikten sonra dependencyinjection yapılır. Yani IUnitOfWork interface i ApplicationDbContex class ına bağlanır, çağrıldığında gelecek class.
            services.AddScoped<IUnitOfWork>(srv=>srv.GetRequiredService<ApplicationDbContext>());

            return services;    
        }
    }
}
