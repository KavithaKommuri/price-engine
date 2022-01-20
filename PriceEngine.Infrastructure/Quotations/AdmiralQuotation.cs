using PriceEngine.Extensions;
using PriceEngine.Core.Models;
using PriceEngine.Core.Quotations;

namespace PriceEngine.Quotations
{
    public class AdmiralQuotation : IQuotationSystem
    {
        public string Name => "Admiral";

        public Quotation GetQuotation(RiskData riskData)
        {
            //makes a call to an external service - SNIP
            //var response = _someExternalService.PostHttpRequest(requestData);
            if (!CanFetchQuote(riskData)) return null;
            var response = new
            {
                Price = 123.45M,
                IsSuccess = true,
                Tax = 123.45M * 0.12M,
                Name = Name
            };

            return response.ConvertToType<Quotation>();
        }

        private bool CanFetchQuote(RiskData riskData)
        {
            return riskData.DOB.HasValue;
        }
    }
}
