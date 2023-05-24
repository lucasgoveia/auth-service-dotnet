namespace AuthService.Api.Features.Register;

public static class RegistrationType
{
    public const string Email = "email";
    public const string PhoneNumber = "phone-number";
}

public record RegisterAccount
{
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
    public required string Password { get; init; }
    public required string RegistrationType { get; init; }
    public required string Name { get; init; }
}
