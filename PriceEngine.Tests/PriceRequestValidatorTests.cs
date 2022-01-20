using PriceEngine.Validations;
using PriceEngine.Core.Models;
using PriceEngineSolution.Requests;
using System.Collections.Generic;
using Xunit;

namespace PriceEngine.Tests
{
    public class PriceRequestValidatorTests
    {
        public static IEnumerable<object[]> Validate_ReturnsCorrectValidate_TestData => new List<object[]>
        {
            new object[] { null , false },
            new object[] { new PriceRequest() , false },
            new object[] { new PriceRequest() {  RiskData = new RiskData() { FirstName = "Kavitha" } } , false },
            new object[] { new PriceRequest() {  RiskData = new RiskData() { FirstName = "Kavitha", LastName = "Desu" } } , false },
            new object[] { new PriceRequest() {  RiskData = new RiskData() { FirstName = "Kavitha", LastName = "Desu", Value = 500 } } , true }
        };

        [Theory]
        [MemberData(nameof(Validate_ReturnsCorrectValidate_TestData))]
        public void PriceRequestValidator_ShouldReturnCorrectly(PriceRequest request, bool expectedValue)
        {
            var priceRequestValidator = new PriceRequestValidator();
            var validationResult = priceRequestValidator.Validate(request);
            var actualValue = validationResult.IsValid;
            Assert.Equal(expectedValue, actualValue);            
        }
    }
}
