using System;
using System.Collections.Generic;
using System.Text;
using ContractSystem.Domain.Model;
using FluentValidation;

namespace ContractSystem.Domain.Validation
{
    /// <summary>
    /// by this class we use FluentValidation for add custom validation to our classes.we should add this class to mvc in the endpoint.core startup
    /// </summary>
    public class ContractModelValidator : AbstractValidator<ContractModel>
    {
        public ContractModelValidator()
        {
            RuleFor(c => c.EndDate).GreaterThan(x => x.StartDate);
        }
    }
}
