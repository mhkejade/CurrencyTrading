using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyTrading.Money.Domain.Model
{
    public class Money
    {
        public Currency Currency { get; }
        public double Amount { get; }

        public Money(Currency currency, double amount)
        {
            Currency = currency;
            Amount = amount;
        }


        
    }
}
