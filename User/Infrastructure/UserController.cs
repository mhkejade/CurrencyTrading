using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyTrading.Money.Domain.Model;
using CurrencyTrading.Money.Application;
using CurrencyTrading.Money.Application.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CurrencyTrading.User.Infrastructure
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly TradingEngineDbContext _context;

        public UserController(ILogger<UserController> logger, TradingEngineDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        // temporary endpoint to create user
        // supposedly on another app
        [HttpPost]
        [Route("save")]
        public async Task<ActionResult<Domain.Model.User>> Save(Domain.Model.User user)
        {

            Currency currency = await _context.Currencies.Where(f => f.Name.Equals("USD")).FirstOrDefaultAsync();
            if (currency == null)
            {
                currency = new Currency("USD", 2);
                _context.Currencies.Add(currency);
                await _context.SaveChangesAsync();
            }

            if (user.Balance == null)
            {
                user.Balance = new Balance();
                user.Balance.CurrencyBalances = new List<CurrencyBalance>();
                user.Balance.CurrencyBalances.Add(new CurrencyBalance() { Amount = 100, Currency = currency });
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }

            return user;
        }

        [HttpPost]
        [Route("init-users")]
        public async Task<ActionResult<IList<Domain.Model.User>>> Init()
        {

            var usd = new Currency("USD", 50);
            _context.Currencies.Add(usd);

            var php = new Currency("PHP", 1);
            _context.Currencies.Add(php);

            var aud = new Currency("AUD", 2);
            _context.Currencies.Add(aud);

            var eur = new Currency("EUR", 2);
            _context.Currencies.Add(eur);

            var gbp = new Currency("GBP", 2);
            _context.Currencies.Add(gbp);

            await _context.SaveChangesAsync();

            var user = new Domain.Model.User();
            user.UserName = "User1";
            user.Balance = new Balance();
            user.Balance.CurrencyBalances = new List<CurrencyBalance>();
            user.Balance.CurrencyBalances.Add(new CurrencyBalance() { Amount = 100, Currency = usd });
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var user2 = new Domain.Model.User();
            user2.UserName = "User2";
            user2.Balance = new Balance();
            user2.Balance.CurrencyBalances = new List<CurrencyBalance>();
            user2.Balance.CurrencyBalances.Add(new CurrencyBalance() { Amount = 100, Currency = usd });
            _context.Users.Add(user2);
            await _context.SaveChangesAsync();

            var result = await _context.Users.Include(User => User.Balance)
                .ThenInclude(f => f.CurrencyBalances)
                .ThenInclude(f => f.Currency)
                .Select(f => f).ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<IList<Domain.Model.User>>> Balance()
        {
            var result = await _context.Users.Include(User => User.Balance)
                .ThenInclude(f => f.CurrencyBalances)
                .ThenInclude(f => f.Currency)
                .Select(f => f).ToListAsync();
            return Ok(result);
        }


    }
}
