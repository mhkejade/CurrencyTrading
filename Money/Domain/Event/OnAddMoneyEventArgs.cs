using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyTrading.Money.Application.Request;

namespace CurrencyTrading.Money.Domain.Event
{
    public class OnAddMoneyEventArgs : EventArgs
    {
        public int UserId { get; set; }
        public string CurrencyName { get; set; }
        public double Amount { get; set; }
    }
}
