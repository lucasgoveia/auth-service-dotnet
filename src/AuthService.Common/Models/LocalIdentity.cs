namespace AuthService.Common.Models;

public class LocalIdentity
{
    public required long Id { get; set; }
    public required long UserId { get; set; }
    public User User { get; private set; } = null!;
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public DateTime LockoutEndDate { get; set; }
    public int AccessFailedCount { get; set; }
}