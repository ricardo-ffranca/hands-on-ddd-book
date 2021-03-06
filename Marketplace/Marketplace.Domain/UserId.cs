using Marketplace.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
    public class UserId : Value<UserId>
    {
        private Guid Value { get; set; }

        protected UserId() { }

        public UserId(Guid value) => Value = value;

        public static implicit operator Guid(UserId self) => self.Value;
    }
}