using Marketplace.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
    //TODO Ver sobre Structs e Record Types
    public class Money: Value<Money>
    {
        public decimal Amount { get; }

        public Money(decimal amount) => Amount = amount;

        public Money Add(Money summand) => new Money(Amount + summand.Amount);

        public Money Subtract(Money subtrahend) => new Money(Amount - subtrahend.Amount);

        public static Money operator +(Money summand1, Money summand2) => summand1.Add(summand2);

        public static Money operator -(Money minuend, Money subtrahend) => minuend.Subtract(subtrahend);
    }
}
