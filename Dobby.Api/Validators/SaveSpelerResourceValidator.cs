using Dobby.Api.Resources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobby.Api.Validators
{
    public class SaveSpelerResourceValidator: AbstractValidator<SaveSpelerResource>
    {
        public SaveSpelerResourceValidator()
        {
            RuleFor(a => a.GebruikerId)
                .NotEmpty()
                .WithMessage("Gebruiker is verplicht");
            RuleFor(a => a.PartijId)
                .NotEmpty()
                .WithMessage("Partij is verplicht");
            RuleFor(a => a.RatingAanBeginVanWedstrijd)
                .NotEmpty()
                .WithMessage("Rating is verplicht");
            RuleFor(a => a.KleurSpeler)
                .NotEmpty()
                .WithMessage("Kleur is verplicht");
        }
    }
}
