using AutoMapper;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.GetAllUser
{
    /// <summary>
    /// Defines the mappings between response and entity for the GetAllUser use case.
    /// </summary>
    public sealed class GetAllUserMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllUserMapper"/> class.
        /// Configures mappings between <see cref="User"/> and <see cref="GetAllUserResponse"/>.
        /// </summary>
        public GetAllUserMapper()
        {

            // Mapping from User entity to GetAllUserResponse.
            CreateMap<User, GetAllUserResponse>();
        }
    }
}