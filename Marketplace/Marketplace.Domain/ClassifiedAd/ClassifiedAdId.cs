﻿using Marketplace.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain.ClassifiedAd
{
    public class ClassifiedAdId : Value<ClassifiedAdId>
    {
        public Guid Value { get; }

        public ClassifiedAdId(Guid value) => Value = value;

        public static implicit operator Guid(ClassifiedAdId self) => self.Value;

        public static implicit operator ClassifiedAdId(string value)
           => new ClassifiedAdId(Guid.Parse(value));
    }
}
