using FastEndpoints;

namespace AuthService.Api.Features.Register;

public class RegisterAccountEndpoint : Endpoint<RegisterAccount>
{
    public RegisterAccountEndpoint()
    {
        Post("/account");    
    }
    
    public override async Task HandleAsync(RegisterAccount req, CancellationToken ct)
    {
    }
}