using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using eAppointmentServer.Infrastructure.Context;
using GenericRepository;

namespace eAppointmentServer.Infrastructure.Repositories
{
    internal sealed class PatientRepository : Repository<Patient, ApplicationDbContext>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

    //bu repositoryler dependency injection yapılmalı ki uygulama Application katmanında bu interface i kullandığında hangi class a karşılık geleceğini bilmesi lazım bundan dolayı bunları infrastructure katmanında DependencyInjection classında haberdar edilir.
}
