using MediatR;

namespace CleanArchitecture.Application.UseCases.CreateUser
{
    /// <summary>
    /// Represents the request to create a new user in the system.
    /// This record encapsulates the data required to create a user.
    /// </summary>
    /// <param name="Email">The email address of the user to be created.</param>
    /// <param name="Name">The name of the user to be created.</param>
    /// <remarks>
    /// This request is sent to the MediatR pipeline, where it will be handled by a corresponding handler
    /// that processes the creation of the user.
    /// </remarks>
    public sealed record CreateUserRequest(string Email, string Name) : IRequest<CreateUserResponse>;
}