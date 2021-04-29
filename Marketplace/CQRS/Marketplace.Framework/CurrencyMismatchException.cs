using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Framework
{
    public class CurrencyMismatchException : Exception
    {
        public CurrencyMismatchException(string message) :
          base(message)
        {
        }
    }
}
