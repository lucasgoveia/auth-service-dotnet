namespace AuthService.Common.Models;

public class UserPhoneNumber
{
    public required string PhoneNumber { get; set; }
    public required long UserId { get; set; }
    public User User { get; set; } = null!;
    public bool PhoneNumberConfirmed { get; set; }
    public bool MainPhoneNumber { get; set; }

    public UserPhoneNumber(string phoneNumber, long userId)
    {
        PhoneNumber = phoneNumber;
        UserId = userId;
    }
}