using Dobby.Api.Resources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobby.Api.Validators
{
    public class SaveChatResourceValidator: AbstractValidator<SaveChatResource>
    {
        public SaveChatResourceValidator()
        {
            RuleFor(a => a.PartijId)
                .NotEmpty()
                .WithMessage("Partij is verplicht");
        }
    }
}
