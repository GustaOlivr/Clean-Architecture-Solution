using AutoMapper;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.CreateUser
{
    /// <summary>
    /// Handles the creation of a new user in the system by processing the <see cref="CreateUserRequest"/>.
    /// </summary>
    public sealed class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
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
        public CreateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the processing of a <see cref="CreateUserRequest"/> and returns a <see cref="CreateUserResponse"/>.
        /// </summary>
        /// <param name="request">The request containing the user details to be created.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation, containing the created user details.</returns>
        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            // Map the request to a User entity.
            var user = _mapper.Map<User>(request);

            // Create the user in the repository.
            _userRepository.Create(user);

            // Commit the transaction.
            await _unitOfWork.Commit(cancellationToken);

            // Map the User entity to the response and return it.
            return _mapper.Map<CreateUserResponse>(user);
        }
    }
}