using Dobby.Api.Resources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobby.Api.Validators
{
    public class SaveBerichtResourceValidator: AbstractValidator<SaveBerichtResource>
    {
        public SaveBerichtResourceValidator()
        {
            RuleFor(a => a.Tekst)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(140);
            RuleFor(a => a.Datum)
                .NotEmpty()
                .WithMessage("Datum is verplicht");
            RuleFor(a => a.AfzenderId)
                .NotEmpty()
                .WithMessage("Afzender is verplicht");
            RuleFor(a => a.ChatId)
                .NotEmpty()
                .WithMessage("Chat is verplicht");
        }
    }
}
