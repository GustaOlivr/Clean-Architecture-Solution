using CleanArchitecture.Application.UseCases.CreateUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.UpdateUser
{
    /// <summary>
    /// Represents the request to create a new user in the system.
    /// This record encapsulates the data required to create a user.
    /// </summary>
    /// <param name="Id">The Identifier of the user to be update.</param>
    /// <param name="Email">The email address of the user to be update.</param>
    /// <param name="Name">The name of the user to be update.</param>
    /// <remarks>
    /// This request is sent to the MediatR pipeline, where it will be handled by a corresponding handler
    /// that processes the creation of the user.
    /// </remarks>
    public sealed record UpdateUserRequest(Guid Id,
                                           string Email, 
                                           string Name) : IRequest<UpdateUserResponse>;
}
