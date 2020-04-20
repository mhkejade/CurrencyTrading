namespace CurrencyTrading.Money.Application.Request
{
    public class SendMoneyRequest
    {
        public string ToUser { get; }
        public string CurrencyName { get; }
        public double Amount { get; }

        public SendMoneyRequest(string toUser, string currencyName, double amount)
        {
            ToUser = toUser;
            CurrencyName = currencyName;
            Amount = amount;
        }
    }
}