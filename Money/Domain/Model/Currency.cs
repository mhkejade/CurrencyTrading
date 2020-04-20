using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyTrading.Money.Domain.Model
{
    public class Currency
    {
        public int CurrencyId { get; set; }
        public  string Name { get; set; }
        public double Ratio { get; set; }

        public Currency(string name, double ratio)
        {
            Name = name;
            Ratio = ratio;
        }

    }
}
