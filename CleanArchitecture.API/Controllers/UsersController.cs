using CleanArchitecture.Application.UseCases.CreateUser;
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
            //var validator = new CreateUserValidator();
            //var validatorResult = await validator.ValidateAsync(request);

            //if (!validatorResult.IsValid)
            //{
            //    return BadRequest(validatorResult.Errors);
            //}
            //try
            //{
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
            //}

            //catch (FluentValidation.ValidationException ex) 
            //{
            //    return BadRequest(new {Message = ex.Message});

            //}

        }
    }
}
