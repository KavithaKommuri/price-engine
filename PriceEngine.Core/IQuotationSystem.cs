using PriceEngine.Core.Models;

namespace PriceEngine.Core.Quotations
{
    public interface IQuotationSystem
    {
        string Name { get; }
        Quotation GetQuotation(RiskData riskData);
    }
}
