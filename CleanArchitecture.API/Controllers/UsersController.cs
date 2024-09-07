using CleanArchitecture.Application.UseCases.CreateUser;
using CleanArchitecture.Application.UseCases.DeleteUser;
using CleanArchitecture.Application.UseCases.GetAllUser;
using CleanArchitecture.Application.UseCases.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    /// <summary>
    /// API Controller for managing users.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator instance to handle requests.</param>
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="request">The request object containing user information.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>Returns the created user information.</returns>
        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>Returns a list with all users.</returns>
        [HttpGet]
        public async Task<ActionResult<List<GetAllUserResponse>>> GetAll(CancellationToken cancellationToken)
        {
            List<GetAllUserResponse> response = await _mediator.Send(new GetAllUserRequest(), cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="request">The request object containing updated user information.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>Returns the updated user information.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateUserResponse>> Update(Guid id, UpdateUserRequest request, CancellationToken cancellationToken)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Deletes a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>Returns the deleted user information.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteUserResponse>> Delete(Guid? id, CancellationToken cancellationToken)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var deleteUserRequest = new DeleteUserRequest(id.Value);
            var response = await _mediator.Send(deleteUserRequest, cancellationToken);
            return Ok(response);
        }
    }
}
