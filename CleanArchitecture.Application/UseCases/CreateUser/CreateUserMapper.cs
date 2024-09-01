using AutoMapper;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.CreateUser
{
    /// <summary>
    /// Defines the mappings between the request, response, and entity for the CreateUser use case.
    /// </summary>
    public sealed class CreateUserMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserMapper"/> class.
        /// Configures mappings between <see cref="CreateUserRequest"/>, <see cref="User"/>, and <see cref="CreateUserResponse"/>.
        /// </summary>
        public CreateUserMapper()
        {
            // Mapping from CreateUserRequest to User entity.
            CreateMap<CreateUserRequest, User>();

            // Mapping from User entity to CreateUserResponse.
            CreateMap<User, CreateUserResponse>();
        }
    }
}