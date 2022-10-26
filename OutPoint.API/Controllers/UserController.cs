using MediatR;
using Microsoft.AspNetCore.Mvc;
using OutPoint.Application.Features.UserFeature.Commands;
using OutPoint.Application.Features.UserFeature.Queries;

namespace OutPoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new UserGetAllQuery()));
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var result = await _mediator.Send(new UserGetByEmailQuery {Email = email});
            
            if(result == null)
            {
                return BadRequest("No user found");
            }
            
            return Ok(result);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserRegisterCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.Success == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserLoginCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.Success == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
