using Marketplace.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Marketplace.Domain.ClassifiedAd
{
    public class ClassifiedAdText : Value<ClassifiedAdText>
    {
        public string Value { get; private set; }

        internal ClassifiedAdText(string text) => Value = text;

        protected ClassifiedAdText() { }

        public static ClassifiedAdText FromString(string text) =>
            new ClassifiedAdText(text);

        public static implicit operator string(ClassifiedAdText text) =>
            text.Value;
    }
}
