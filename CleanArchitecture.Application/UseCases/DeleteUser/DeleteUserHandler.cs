using AutoMapper;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.DeleteUser
{
    /// <summary>
    /// Handles the request to delete a user by interacting with the repository and unit of work.
    /// </summary>
    public sealed class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteUserHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work to manage transactions.</param>
        /// <param name="userRepository">The user repository to access user data.</param>
        /// <param name="mapper">The AutoMapper instance for object mapping.</param>
        public DeleteUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the process of deleting a user.
        /// </summary>
        /// <param name="request">The request containing the ID of the user to be deleted.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A response containing information about the deleted user.</returns>
        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.Id, cancellationToken);

            if (user == null) return default;

            _userRepository.Delete(user);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<DeleteUserResponse>(user);
        }
    }
}
