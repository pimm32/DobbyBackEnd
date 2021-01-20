using Dobby.Api.Resources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobby.Api.Validators
{
    public class SavePartijResourceValidator : AbstractValidator<SavePartijResource>
    {
        public SavePartijResourceValidator()
        {
            RuleFor(a => a.SpeeltempoMinuten)
                .NotEmpty()
                .WithMessage("Speeltempo is verplicht");
            RuleFor(a => a.SpeeltempoFisherSeconden)
                .NotEmpty()
                .WithMessage("Fisher tempo kan maximaal 60 seconde zijn");
            RuleFor(a => a.TijdWitSpeler)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Tijd voor witspeler is verplicht");
            RuleFor(a => a.TijdZwartSpeler)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Tijd voor zwartspeler is verplicht");
        }
    }
}
