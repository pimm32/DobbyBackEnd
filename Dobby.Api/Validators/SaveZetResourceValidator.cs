using Dobby.Api.Resources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobby.Api.Validators
{
    public class SaveZetResourceValidator: AbstractValidator<SaveZetResource>
    {
        public SaveZetResourceValidator()
        {
            RuleFor(a => a.BeginVeld)
                .NotEmpty()
                .InclusiveBetween(1, 50);

            RuleFor(a => a.EindVeld)
                .NotEmpty()
                .InclusiveBetween(1, 50);

            RuleFor(a => a.PartijId)
                .NotEmpty()
                .WithMessage("'PartijId' kan niet null zijn");

        }
    }
}
