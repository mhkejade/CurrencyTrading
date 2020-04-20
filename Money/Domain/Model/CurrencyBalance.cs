using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyTrading.Money.Domain.Model
{
    public class CurrencyBalance
    {
        public int CurrencyBalanceId { get; set; }
        public double Amount { get; set; }
        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }
        public int BalanceId { get; set; }
       
    }
}
