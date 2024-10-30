using eAppointmentServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAppointmentServer.Infrastructure.Configurations
{
    internal sealed class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        //appointment tablosuna ayar vermek istenirse;
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
        
        }
    }
}
