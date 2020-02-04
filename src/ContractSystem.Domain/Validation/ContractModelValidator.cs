using System;
using System.Collections.Generic;
using System.Text;
using ContractSystem.Domain.Model;
using FluentValidation;

namespace ContractSystem.Domain.Validation
{
    public class ContractModelValidator : AbstractValidator<ContractModel>
    {
        public ContractModelValidator()
        {
            RuleFor(c => c.EndDate).GreaterThan(x => x.StartDate);
        }
    }
}
