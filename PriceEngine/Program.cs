using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PriceEngine.Core.Models;
using PriceEngine.Validations;
using PriceEngineSolution.Requests;
using System;

namespace PriceEngine
{
    public class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var logger = serviceProvider.GetService<ILogger<Program>>();
            logger.LogDebug("Logger is working!");

            var request = new PriceRequest()
            {
                RiskData = new RiskData() //hardcoded here, but would normally be from user input above
                {
                    DOB = DateTime.Parse("1980-01-01"),
                    FirstName = "John",
                    LastName = "Smith",
                    Make = Core.Enums.Make.Make1,
                    Value = 500
                }
            };

            var validator = serviceProvider.GetService<IDataValidator<PriceRequest>>();
            ValidateRequest(validator, logger, request);

            var priceEngine = serviceProvider.GetService<PriceEngine>();
            var bestQuotation = priceEngine.GetBestQuotation(request);
            logger.LogInformation($"Your price is :  {bestQuotation?.Price}, from insurer: { bestQuotation?.Name}. This includes tax of {bestQuotation?.Tax}");

        }

        private static void ValidateRequest(IDataValidator<PriceRequest> validator,ILogger<Program> logger, PriceRequest request)
        {
            var dataValidationErrors = validator.Validate(request);
            if (!dataValidationErrors.IsValid)
            {
                var validationFailureMessage = $"Validation failed:\r\n{string.Join("\r\n", dataValidationErrors.Errors)}";
                logger.LogError(validationFailureMessage);
                throw new System.Exception(validationFailureMessage);
            }
        }
    }
}
