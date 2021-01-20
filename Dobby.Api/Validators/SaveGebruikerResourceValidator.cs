using Dobby.Api.Resources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobby.Api.Validators
{
    public class SaveGebruikerResourceValidator: AbstractValidator<SaveGebruikerResource>
    {
        public SaveGebruikerResourceValidator()
        {
            RuleFor(a => a.Gebruikersnaam)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(24)
                .WithMessage("Gebruikersnaam is verplicht en moet tussen de 4 en 24 karakters bevatten");
            RuleFor(a => a.Rating)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Rating is verplicht");
            RuleFor(a => a.Email)
                .EmailAddress()
                .NotEmpty()
                .WithMessage("Email is verplicht");
        }
    }
}
