using PriceEngine.Core.Models;
using PriceEngine.Core.Quotations;
using PriceEngine.Quotations;
using PriceEngineSolution.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceEngine.Tests
{
    public class MockQuotationTestsDataProvider : IQuotationSystem
    {
        private readonly string _name;
        private readonly decimal _price;
        private readonly decimal _tax;
        private readonly bool _canFetchQuote;
        public MockQuotationTestsDataProvider(string name, decimal price, decimal tax, bool canFetchQuote)
        {
            _name = name;
            _price = price;
            _tax = tax;
            _canFetchQuote = canFetchQuote;
        }
        public string Name => _name;

        public Quotation GetQuotation(RiskData riskData)
        {
            if (!_canFetchQuote) return null;
            return new Quotation()
            {
                Name = _name,
                Price = _price,
                Tax = _tax
            };
        }
    }
}
