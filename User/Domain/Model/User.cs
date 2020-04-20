using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using CurrencyTrading.Money.Domain.Model;
using CurrencyTrading.Money.Domain.Event;
using CurrencyTrading.Money.Domain.Exception;

namespace CurrencyTrading.User.Domain.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public Balance Balance { get; set; }

        public void Exchange(Money.Domain.Model.Money money, Currency to)
        {
            Balance.Exchange(money, to);
        }

        public void ReceiveMoney(Money.Domain.Model.Money money)
        {
            Balance.AddMoney(money);
        }

        public IDictionary<string, double> GetBalance()
        {
            return Balance.GetAllMoney().ToDictionary(t => t.Currency.Name, t => t.Amount);
        }

        public void SendMoney(User userTo, Money.Domain.Model.Money money)
        {
            this.Balance.ChargeMoney(money);
            userTo.ReceiveMoney(money);
        }

       


    }
}
