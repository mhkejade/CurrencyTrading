using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CurrencyTrading.Money.Domain.Exception
{
    public class CurrencyNotFoundException : System.Exception
    {
        public CurrencyNotFoundException()
        {
        }

        public CurrencyNotFoundException(string message) : base(message)
        {
        }

        public CurrencyNotFoundException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected CurrencyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
