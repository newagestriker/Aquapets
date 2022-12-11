namespace Aquapets.Shared.Domain.Entities
{
    public record User
    {
        public User(string username, string password)
        {
            Id = new Guid();
            Username = username;
            Password = password;
        }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ValueObjects.UserRole? Role { get; set; }

    }
}
