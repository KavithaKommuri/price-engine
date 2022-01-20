using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PriceEngine.Quotations;
using PriceEngine.Validations;
using PriceEngine.Core.Models;
using PriceEngineSolution.Requests;
using PriceEngine.Core.Quotations;

namespace PriceEngine.Configurations
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRequestInjections(this IServiceCollection services)
        {
            return services
                .AddSingleton<IQuotationSystem, AdmiralQuotation>()
                .AddSingleton<IQuotationSystem, AXAQuotation>()
                .AddSingleton<IQuotationSystem, BupaQuotation>()
                .AddSingleton<IDataValidator<PriceRequest>, PriceRequestValidator>()
                .AddSingleton<IDataValidator<RiskData>, RiskDataValidator>()
                .AddSingleton(p => new PriceEngine(p.GetServices<IQuotationSystem>()));
        }
    }
}
