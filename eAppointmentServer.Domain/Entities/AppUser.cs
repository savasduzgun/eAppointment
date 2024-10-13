using Microsoft.AspNetCore.Identity;

namespace eAppointmentServer.Domain.Entities
{
    public sealed class AppUser : IdentityUser<Guid>
    {
        //identity paketinde olmayan propertyler
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        //FullName db ye kaydolmaz çağrınca FirstName+LastName olarak gelir
        public string FullName => string.Join(" ", FirstName, LastName);
    }
}
