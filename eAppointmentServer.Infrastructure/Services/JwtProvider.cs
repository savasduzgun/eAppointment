using eAppointmentServer.Application.Services;
using eAppointmentServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
