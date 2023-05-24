using AuthService.Common;
using FastEndpoints;
using FluentValidation;

namespace AuthService.Api.Features.Register;

public class RegisterAccountValidator : Validator<RegisterAccount>
{
    private static string[] _registrationTypes = { RegistrationType.Email, RegistrationType.PhoneNumber };

    public RegisterAccountValidator(IPasswordValidator passwordValidator)
    {
        RuleFor(x => x.RegistrationType)
            .NotEmpty()
            .Must(x => _registrationTypes.Contains(x));

        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2);

        When(x => x.RegistrationType == RegistrationType.Email, () =>
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
        });

        When(x => x.RegistrationType == RegistrationType.PhoneNumber, () =>
        {
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .Matches(
                    @"^\(?(?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$");
        });

        RuleFor(x => x.Password)
            .NotNull()
            .Must(passwordValidator.Validate)
                .WithMessage("Insecure password");
    }
}