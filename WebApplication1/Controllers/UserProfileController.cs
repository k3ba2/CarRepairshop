using CarRepairshop.Application.UserProfile.Command.DeleteCurrentUser;
using CarRepairshop.Application.UserProfile.Queries.GetCurrentUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairshop.MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("CurrentUser")]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _mediator.Send(new GetCurrentUserQuery());
            return Ok(currentUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            var result = await _mediator.Send(new DeleteCurrentUserCommand(id));

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
