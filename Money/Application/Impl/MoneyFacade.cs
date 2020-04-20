using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyTrading.Money.Application.Request;
using CurrencyTrading.Money.Domain.Exception;
using CurrencyTrading.Money.Domain.Model;
using CurrencyTrading.User.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CurrencyTrading.Money.Application.Impl
{
    public class MoneyFacade : IMoneyFacade
    {
        private readonly ILogger<UserController> _logger;
        private readonly TradingEngineDbContext _context;

        public MoneyFacade(ILogger<UserController> logger, TradingEngineDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Exchange(MoneyExchangeRequest moneyExchangeRequest, string token)
        {
            var from = await findCurrency(moneyExchangeRequest.FromCurrencyName);
            var to = await findCurrency(moneyExchangeRequest.ToCurrencyName);
            var user = await findUserByToken(token);
            user.Exchange(new Domain.Model.Money(from, moneyExchangeRequest.Amount), to);
            await _context.SaveChangesAsync();
        }

        public async Task Send(SendMoneyRequest sendMoneyRequest, string token)
        {
            var from = await findUserByToken(token);
            var to = await findUserByToken(sendMoneyRequest.ToUser);
            var currency = await findCurrency(sendMoneyRequest.CurrencyName);
            from.SendMoney(to, new Domain.Model.Money(currency, sendMoneyRequest.Amount));
            await _context.SaveChangesAsync();
        }

        public async Task<Dictionary<string, double>> UserBalance(string token)
        {
            var result = await findUserByToken(token);
            return result.Balance.CurrencyBalances.ToDictionary(f => f.Currency.Name, f => f.Amount);
        }

        private async Task<Currency> findCurrency(string currencyName)
        {
            var result = await _context.Currencies.Where(f =>
                f.Name.Equals(currencyName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefaultAsync();
            if(result == null)
                throw new CurrencyNotFoundException($"Currency {currencyName} not found!");
            return result;
        }

        private async Task<User.Domain.Model.User> findUserByToken(string token)
        {
            var result = await _context.Users.Include(User => User.Balance)
                .ThenInclude(f => f.CurrencyBalances)
                .ThenInclude(f => f.Currency)
                .Where(f => f.UserName.Equals(token))
                .Select(f => f).FirstOrDefaultAsync();
            
            if(result == null)
                throw new UserNotFoundException($"UserName: {token} not found!");
            return result;
        }

    }
}
