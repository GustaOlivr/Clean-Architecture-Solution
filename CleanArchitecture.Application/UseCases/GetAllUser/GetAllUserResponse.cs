namespace CleanArchitecture.Application.UseCases.GetAllUser
{
    /// <summary>
    /// Represents the response returned after creating a new user.
    /// </summary>
    public sealed record GetAllUserResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public string? Name { get; set; }
    }
}