using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eAppointmentServer.WebAPI.Abstractions
{
    //bu class tüm controller için inherit edilen bir base class
    [Route("api/[controller]/[action]")] //metod ismi endpoint de görünsün diye action eklenir.
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        public readonly IMediator _mediator;

        protected ApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
