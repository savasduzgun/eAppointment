using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Enums;
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

            //migration yaparken db ye map lemek için
            //db ye kayıt yaparken value kaydet geri okurken ordaki value al DepartmenEnum a dönüştürerek geri ver
            builder.Property(p => p.Department)
                .HasConversion(v => v.Value, v => DepertmentEnum.FromValue(v))
                .HasColumnName("Department");
        }
    }
}
