namespace NutritionTracker.Domain.Entities
{
    public class User
    {
        public int Id { get; }
        public string Email { get; }
        public string Hash { get; }
        public byte[] Salt { get; }
        public string Role { get; }
        public bool Enabled { get; }

        public User(int id, string email, string hash, byte[] salt, string role, bool enabled)
        {
            Id = id;
            Email = email;
            Hash = hash;
            Salt = salt;
            Role = role;
            Enabled = enabled;
        }
    }
}
