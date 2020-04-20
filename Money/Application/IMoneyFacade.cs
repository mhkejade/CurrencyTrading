using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyTrading.Money.Application.Request;

namespace CurrencyTrading.Money.Application
{
    public interface IMoneyFacade
    {
        Task Exchange(MoneyExchangeRequest moneyExchangeRequest, string token);
        Task<Dictionary<string, double>> UserBalance(string token);
        Task Send(SendMoneyRequest sendMoneyRequest, string token);
    }
}
