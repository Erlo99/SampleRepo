using Application.Dto.Authentication;
using Domain.Http.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {
        /// <summary>
        /// Return User by Id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await Mediator.Send(new GetUserByIdQueryRequest() {Id = id});
            return Ok(user);
        }

        /// <summary>
        /// Returns list of Users
        /// </summary>
        /// <param name="request">User data</param>
        /// <returns></returns>
        [HttpGet("List")]
        public async Task<IActionResult> GetUserList([FromQuery] GetUserListQueryRequest request)
        {
            var user = await Mediator.Send(request);
            return Ok(user);
        }

        /// <summary>
        /// Adds new User
        /// </summary>
        /// <param name="request">User data</param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AllowAnonymous]
        public async Task<IActionResult> PostUser([FromBody] CreateUserCommandRequest request)
        {
            var user = await Mediator.Send(request);
            return Created($"api/User/{user.Id}", user);
        }

        /// <summary>
        /// Updates User
        /// </summary>
        /// <param name="request">User data</param>
        /// <param name="id">User Id</param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchUser(Guid id, [FromBody] UpdateUserCommandRequest request)
        {
            request.Id = id;
            var user = await Mediator.Send(request);
            return Ok(user);
        }
    }
}
