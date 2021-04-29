using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain.Shared
{
    public interface ICurrencyLookup
    {
        Currency FindCurrency(string currencyCode);
    }
}
