using Marketplace.Domain.Shared;
using Marketplace.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain.UserProfile
{
    public class DisplayName : Value<DisplayName>
    {
        public string Value { get; }

        internal DisplayName(string displayName) => Value =
        displayName;

        public static DisplayName FromString(
            string displayName,
            CheckTextForProfanity hasProfanity)
        {
            if (displayName.IsEmpty())
                throw new ArgumentNullException(nameof(FullName));

            if (hasProfanity(displayName))
                throw new DomainExceptions.ProfanityFoundException(displayName);

            return new DisplayName(displayName);
        }

        public static implicit operator string(DisplayName displayName)
            => displayName.Value;

        // Satisfy the serialization requirements
        protected DisplayName() { }
    }
}
