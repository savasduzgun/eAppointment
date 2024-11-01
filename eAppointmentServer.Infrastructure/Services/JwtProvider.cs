using eAppointmentServer.Application.Services;
using eAppointmentServer.Domain.Entities;

namespace eAppointmentServer.Infrastructure.Services
{
    internal sealed class JwtProvider : IJwtProvider
    {
        public string CreateToken(AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}
