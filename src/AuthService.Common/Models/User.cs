namespace AuthService.Common.Models;

public class User
{
    public required long Id { get; set; }
    public required string Name { get; set; }
    public string? MainEmail { get; set; }
    public string? MainPhoneNumber { get; set; }

    public List<LocalIdentity> Emails { get; set; } = new();
    public List<UserPhoneNumber> PhoneNumbers { get; set; } = new();
    public List<LocalIdentity> LocalIdentities { get; set; } = new();
    public List<ThirdPartyIdentity> ThirdPartyIdentities { get; set; } = new();
}