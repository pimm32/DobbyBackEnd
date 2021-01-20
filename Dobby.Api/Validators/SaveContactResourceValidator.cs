using Dobby.Api.Resources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobby.Api.Validators
{
    public class SaveContactResourceValidator: AbstractValidator<SaveContactResource>
    {
        public SaveContactResourceValidator()
        {
            RuleFor(a => a.GebruikerId)
               .NotEmpty()
               .WithMessage("Gebruikersnaam moet bekend zijn");
            RuleFor(a => a.ContactId)
                .NotEmpty()
                .WithMessage("Contact moet bekend zijn");
        }
    }
}
