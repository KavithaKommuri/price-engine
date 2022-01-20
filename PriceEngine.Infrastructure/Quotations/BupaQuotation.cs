using PriceEngine.Extensions;
using PriceEngine.Core.Models;
using PriceEngine.Core.Quotations;

namespace PriceEngine.Quotations
{
    public class BupaQuotation : IQuotationSystem
    {
        public string Name => "Bupa";

        public Quotation GetQuotation(RiskData riskData)
        {
            if (!CanFetchQuote(riskData)) return null;
            var response = new
            {
                Price = 500M,
                IsSuccess = true,
                HasPrice = true,
                Tax = 123.45M * 0.12M,
                Name = Name
            };

            return response.ConvertToType<Quotation>();
        }

        private bool CanFetchQuote(RiskData riskData)
        {
            return true;
        }
    }
}
