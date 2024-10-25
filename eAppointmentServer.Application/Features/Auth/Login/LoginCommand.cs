using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Auth.Login
{
    //Kullanıcı giriş için gereken değerler istenecek
    public sealed record LoginCommand(
        string UserNameOrEmail,
        string Password) : IRequest<Result<LoginCommandResponse>>;
}
