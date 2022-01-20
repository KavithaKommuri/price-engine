using FluentValidation;

namespace PriceEngine.Validations
{
    public interface IDataValidator<T> : IValidator<T>
    {
    }
}
