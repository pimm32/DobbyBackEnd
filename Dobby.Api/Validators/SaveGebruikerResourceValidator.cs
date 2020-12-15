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
                .MinimumLength(8)
                .MaximumLength(20)
                .WithMessage("Gebruikersnaam is verplicht en moet tussen de 8 en 20 karakters bevatten");
            RuleFor(a => a.Rating)
                .NotEmpty()
                .WithMessage("Rating is verplicht");
        }
    }
}
