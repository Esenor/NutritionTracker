namespace NutritionTracker.Domain.Entities
{
    public class User
    {
        public int Id { get; }
        public string Email { get; }
        public string Hash { get; }
        public string Salt { get; }
        public IEnumerable<string> Roles { get; }

        public User(int id, string email, string hash, string salt, IEnumerable<string> roles)
        {
            Id = id;
            Email = email;
            Hash = hash;
            Salt = salt;
            Roles = roles;
        }
    }
}
