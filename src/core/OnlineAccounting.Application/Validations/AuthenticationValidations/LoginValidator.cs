using FluentValidation;
using OnlineAccounting.Application.Authentication.Models;

namespace OnlineAccounting.Application.Validations.AuthenticationValidations;

public sealed class LoginValidator : AbstractValidator<LoginInput>
{
    public LoginValidator()
    {
        RuleFor(i => i.EmailOrUsername).NotEmpty().WithMessage("Email is required.");
        RuleFor(i => i.Password).NotEmpty().WithMessage("Password is required.");
    }
}