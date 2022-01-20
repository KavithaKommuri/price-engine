using PriceEngine.Core.Models;
using PriceEngine.Core.Quotations;
using PriceEngineSolution.Requests;
using System;
using System.Collections.Generic;
using Xunit;

namespace PriceEngine.Tests
{
    public class PriceEngineTests
    {       
        PriceRequest _priceRequest;

        public PriceEngineTests()
        {           
            _priceRequest = new PriceRequest()
            {
                RiskData = new RiskData() { FirstName = "Kavitha", LastName = "Desu", Value = 500 }
            };
         }

        [Theory]
        [MemberData(nameof(PriceEngine_TestData))]
        public void PriceEngine_ShouldReturnBestQuotationPrice(List<IQuotationSystem> quotationSystems, Quotation expectedQuotation)
        {
            var priceEngine = new PriceEngine(quotationSystems);
            var quotation = priceEngine.GetBestQuotation(_priceRequest);
            Assert.Equal(expectedQuotation?.Price, quotation?.Price);
        }

        [Fact]
        public void PriceEngine_ShouldThrowException_WhenQuotationSystemsNotAvaialble()
        {
            var priceEngine = new PriceEngine(null);            
            Assert.Throws<NullReferenceException>(() => priceEngine.GetBestQuotation(_priceRequest));
        }
        public static IEnumerable<object[]> PriceEngine_TestData => new List<object[]>
        {
            new object[] { new List<IQuotationSystem>(), null},
            new object[] { GetMockQuotationSystems(), new Quotation() { Name ="Lowest", Price = 10, Tax = 0   }  },
            new object[] { GetMockDataWithNoFectchFromSystems(), null }
        };

        private static List<IQuotationSystem> GetMockQuotationSystems()
        {
            return new List<IQuotationSystem>()
           {
               new MockQuotationTestsDataProvider("Lowest", 10, 10, true),
               new MockQuotationTestsDataProvider("Highest", 1000, 10, true),
               new MockQuotationTestsDataProvider("CannotFetch", 0, 0, false)
            };        
        }

        private static List<IQuotationSystem> GetMockDataWithNoFectchFromSystems()
        {
            return new List<IQuotationSystem>()
           {
               new MockQuotationTestsDataProvider("Lowest", 10, 10, false),
               new MockQuotationTestsDataProvider("Highest", 1000, 10, false),
               new MockQuotationTestsDataProvider("CannotFetch", 0, 0, false)
            };
        }

     

       
    }
}
