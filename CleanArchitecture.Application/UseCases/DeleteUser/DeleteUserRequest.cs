using MediatR;

namespace CleanArchitecture.Application.UseCases.DeleteUser
{
    /// <summary>
    /// Represents a request to delete a user by their unique identifier.
    /// </summary>
    /// <param name="Id">The unique identifier of the user to delete.</param>
    public sealed record DeleteUserRequest(Guid Id) : IRequest<DeleteUserResponse>;
}
