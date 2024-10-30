﻿using eAppointmentServer.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eAppointmentServer.Infrastructure.Context
{
    //Bu class ı diğer katmanlar direkt kullanamasın diye internal.
    //Repository kullanıldığı için ya onun üzerinden yada Identity kütüphanesi için kullanılan user managerlar yada diğer managerlar üzerinden işlem yapabilmesi lazım.
    internal sealed class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        //AppRole, AppUser ve AppUserRole ni db ye identity kütüphanesi bağlıyor.

        //Identity kütüphanesinin kullanılmayan classlarını db ye eklenmesin diye pasifize etmek gerekir.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<IdentityUserClaim<Guid>>();
            builder.Ignore<IdentityRoleClaim<Guid>>();
            builder.Ignore<IdentityUserLogin<Guid>>();
            builder.Ignore<IdentityUserToken<Guid>>();
        }
    }
}
