namespace AuthService.Common.Models;

public class ThirdPartyIdentity
{
    public required long UserId { get; set; }
    public User User { get; private set; } = null!;
    public required string ProviderName { get; set; }
    public required string ProviderId { get; set; }
}