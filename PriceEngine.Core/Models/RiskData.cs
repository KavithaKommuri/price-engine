using PriceEngine.Core.Enums;
using System;

namespace PriceEngine.Core.Models
{
    public class RiskData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Value { get; set; }
        public Make Make { get; set; }
        public DateTime? DOB { get; set; }
    }
}
