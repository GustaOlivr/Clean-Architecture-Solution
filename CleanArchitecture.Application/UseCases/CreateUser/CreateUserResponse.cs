namespace CleanArchitecture.Application.UseCases.CreateUser
{
    /// <summary>
    /// Represents the response returned after creating a new user.
    /// </summary>
    public sealed record CreateUserResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly created user.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the email address of the newly created user.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the name of the newly created user.
        /// </summary>
        public string? Name { get; set; }
    }
}