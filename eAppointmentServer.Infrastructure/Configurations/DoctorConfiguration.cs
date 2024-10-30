using eAppointmentServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAppointmentServer.Infrastructure.Configurations
{
    internal sealed class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        //doktorlar tablosuna ayar vermek istenirse;
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(p => p.FirstName).HasColumnType("varchar(50)");
            builder.Property(p => p.LastName).HasColumnType("varchar(50)");
            //builder.HasIndex(x => x.FirstName).IsUnique();
            //builder.HasIndex(x => x.FirstName).IsUnique();
            //builder.HasIndex(p => new { p.FirstName, p.LastName }).IsUnique();
        }
    }
}
