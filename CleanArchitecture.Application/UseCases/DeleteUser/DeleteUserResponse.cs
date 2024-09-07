namespace CleanArchitecture.Application.UseCases.DeleteUser
{
    /// <summary>
    /// Represents the response after a user has been deleted.
    /// </summary>
    public sealed record DeleteUserResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the deleted user.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the email of the deleted user.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the name of the deleted user.
        /// </summary>
        public string? Name { get; set; }
    }
}
