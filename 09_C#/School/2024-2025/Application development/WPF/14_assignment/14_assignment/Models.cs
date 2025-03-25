namespace _14_assignment;

public static class Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; init; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastLogin { get; set; }
    }
}