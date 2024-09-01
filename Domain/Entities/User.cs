namespace CleanArchitecture.Domain.Entities
{
    /// <summary>
    /// Represents a user entity in the domain.
    /// </summary>
    public sealed class User
    {
        /// <summary>
        /// Email address of the user.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Name of the user.
        /// </summary>
        public string? Name { get; set; }
    }
}
