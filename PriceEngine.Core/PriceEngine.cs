using PriceEngine.Core.Models;
using PriceEngine.Core.Quotations;
using PriceEngineSolution.Requests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceEngine
{
    public class PriceEngine
    {
        IEnumerable<IQuotationSystem> _quotationSystems;
        public PriceEngine(IEnumerable<IQuotationSystem> quotationSystems)
        {
            _quotationSystems = quotationSystems;
        }
        public Quotation GetBestQuotation(PriceRequest request)
        {          
              if (_quotationSystems == null) throw new NullReferenceException("No quotation systems available to retrieve best quote.");

              return _quotationSystems.Select(q => q.GetQuotation(request?.RiskData))
                                                      .Where(q => q!=null)
                                                      .OrderByDescending(q => q.Price)
                                                      .LastOrDefault();                
           
        }
    }
}
