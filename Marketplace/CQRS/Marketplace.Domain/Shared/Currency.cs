using Marketplace.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain.Shared
{
    public class Currency : Value<Currency>
    {
        public string CurrencyCode { get; set; }
        public bool InUse { get; set; }
        public int DecimalPlaces { get; set; }

        public static Currency None = new Currency
        {
            InUse = false
        };
    }

}
