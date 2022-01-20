using PriceEngine.Core.Enums;
using PriceEngine.Extensions;
using PriceEngine.Core.Models;
using System.Collections.Generic;
using PriceEngine.Core.Quotations;

namespace PriceEngine.Quotations
{
    public class AXAQuotation : IQuotationSystem
    {
        private static List<Make> _allowedMakes = new List<Make>
        {
            Make.Make1,
            Make.Make2
        };
        public string Name => "AXA";

        public Quotation GetQuotation(RiskData riskData)
        {
            if (!CanFetchQuote(riskData)) return null;
            var response = new
            {
                Price = 234.56M,
                HasPrice = true,
                Tax = 123.45M * 0.12M,
                Name = Name
            };

            return response.ConvertToType<Quotation>();
        }
        private bool CanFetchQuote(RiskData riskData)
        {
            return _allowedMakes.Contains(riskData.Make);
        }
    }
}
