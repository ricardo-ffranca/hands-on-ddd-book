using Marketplace.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
    public class ClassifiedAdId : Value<ClassifiedAdId>
    {
        private Guid Value { get; }

        public ClassifiedAdId(Guid value) => Value = value;

        public static implicit operator Guid(ClassifiedAdId self) => self.Value;
    }
}
