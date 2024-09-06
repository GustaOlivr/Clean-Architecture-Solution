using AutoMapper;
using CleanArchitecture.Application.UseCases.CreateUser;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.UpdateUser
{
    /// <summary>
    /// Handles the updates of a user in the system by processing the <see cref="    /// <summary>
    /// Handles the creation of a new user in the system by processing the <see cref="UpdateUserRequest"/>.
    /// </summary>
    public sealed class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work to manage transaction commits.</param>
        /// <param name="userRepository">The user repository for managing user data.</param>
        /// <param name="mapper">The mapper to convert between request, entity, and response objects.</param>
        public UpdateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the processing of a <see cref="UpdateUserRequest"/> and returns a <see cref="UpdateUserResponse"/>.
        /// </summary>
        /// <param name="request">The request containing the user details to be created.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation, containing the created user details.</returns>
        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.Id, cancellationToken);

            if (user is null) return default;

            user.Name = request.Name;
            user.Email = request.Email;

            // Create the user in the repository.
            _userRepository.Update(user);

            // Commit the transaction.
            await _unitOfWork.Commit(cancellationToken);

            // Map the User entity to the response and return it.
            return _mapper.Map<UpdateUserResponse>(user);
        }
    }
}
