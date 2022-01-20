using FluentValidation;
using FluentValidation.Results;
using PriceEngine.Core.Models;


namespace PriceEngine.Validations
{
    public class RiskDataValidator : AbstractValidator<RiskData>, IDataValidator<RiskData>
    {
        public RiskDataValidator()
        {
            CreateRules();
        }

        protected override bool PreValidate(ValidationContext<RiskData> context, ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("RiskData", "Risk Data cannot be null"));
                return false;
            }
            return base.PreValidate(context, result);
        }
        private void CreateRules()
        {
            RuleFor(rd => rd).NotEmpty().WithMessage("Risk Data is required");
            RuleFor(rd => rd.FirstName).NotEmpty().WithMessage("First name is required");
            RuleFor(rd => rd.LastName).NotEmpty().WithMessage("Surname name is required");
            RuleFor(rd => rd.Value).NotEmpty().WithMessage("Value is required");
        }
    }
}
