using AutoMapper;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.GetAllUser
{
    /// <summary>
    /// Handles the get all users in the system by processing the <see cref="GetAllUserRequest"/>.
    /// </summary>
    public sealed class GetAllUserHandler : IRequestHandler <GetAllUserRequest, List<GetAllUserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllUserHandler"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository for managing user data.</param>
        /// <param name="mapper">The mapper to convert between request, entity, and response objects.</param>
        public GetAllUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the processing of a <see cref="GetAllUserRequest"/> and returns a <see cref="GetAllUserResponse"/>.
        /// </summary>
        /// <param name="request">The request containing the user details to be created.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation, containing the created user details.</returns>
        public async Task <List<GetAllUserResponse>> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
        {
            // Map the request to a User entity.
            var users = await _userRepository.GetAll(cancellationToken);

            // Map the User entity to the response and return it.
            return _mapper.Map<List<GetAllUserResponse>>(users);
        }
    }
}