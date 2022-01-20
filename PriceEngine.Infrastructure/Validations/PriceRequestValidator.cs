using FluentValidation;
using FluentValidation.Results;
using PriceEngineSolution.Requests;

namespace PriceEngine.Validations
{
    public class PriceRequestValidator : AbstractValidator<PriceRequest>, IDataValidator<PriceRequest>
    {
        public PriceRequestValidator()
        {
            CreateRules();
        }

        //TODO: this can be generalised if time is available.
        protected override bool PreValidate(ValidationContext<PriceRequest> context, ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("PriceRequest", "Price request cannot be null"));
                return false;
            }
            return base.PreValidate(context, result);
        }

        private void CreateRules()
        {
            RuleFor(pr => pr).NotEmpty().WithMessage("Price request is required");
            RuleFor(pr => pr.RiskData).NotEmpty().WithMessage("Risk Data is required");
            RuleFor(pr => pr.RiskData).SetValidator(new RiskDataValidator());
        }
    }
}
