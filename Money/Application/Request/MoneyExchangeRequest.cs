namespace CurrencyTrading.Money.Application.Request
{
    public class MoneyExchangeRequest
    {
        public string FromCurrencyName { get; }
        public string ToCurrencyName { get; }
        public double Amount { get; }

        public MoneyExchangeRequest(string fromCurrencyName, string toCurrencyName, double amount)
        {
            FromCurrencyName = fromCurrencyName;
            ToCurrencyName = toCurrencyName;
            Amount = amount;
        }
    }
}