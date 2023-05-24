namespace AuthService.Common.Models;

public class UserEmail
{
    public required string Email { get; set; }
    public required long UserId { get; set; }
    public User User { get; set; } = null!;
    public bool EmailConfirmed { get; set; }
    public bool MainEmail { get; set; }

    
    public UserEmail(string email, long userId)
    {
        Email = email;
        UserId = userId;
    }
}