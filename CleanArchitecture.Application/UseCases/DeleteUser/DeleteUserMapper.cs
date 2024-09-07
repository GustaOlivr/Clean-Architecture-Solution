using AutoMapper;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.DeleteUser
{
    /// <summary>
    /// Mapper profile for deleting users, defining mappings between request, user entity, and response.
    /// </summary>
    public sealed class DeleteUserMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteUserMapper"/> class.
        /// </summary>
        public DeleteUserMapper()
        {
            CreateMap<DeleteUserRequest, User>();
            CreateMap<User, DeleteUserResponse>();
        }
    }
}
