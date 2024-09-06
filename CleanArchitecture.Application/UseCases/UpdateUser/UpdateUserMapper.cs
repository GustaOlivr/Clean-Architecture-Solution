using AutoMapper;
using CleanArchitecture.Application.UseCases.CreateUser;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.UpdateUser
{
    /// <summary>
    /// Defines the mappings between the request, response, and entity for the CreateUser use case.
    /// </summary>
    public sealed class UpdateUserMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserMapper"/> class.
        /// Configures mappings between <see cref="UpdateUserRequest"/>, <see cref="User"/>, and <see cref="UpdateUserResponse"/>.
        /// </summary>
        public UpdateUserMapper()
        {
            // Mapping from CreateUserRequest to User entity.
            CreateMap<UpdateUserRequest, User>();

            // Mapping from User entity to CreateUserResponse.
            CreateMap<User, UpdateUserResponse>();
        }
    }
}
