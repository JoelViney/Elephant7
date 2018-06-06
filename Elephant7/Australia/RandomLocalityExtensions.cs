using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Elephant7.Helpers;
using Elephant7.Texts;

namespace Elephant7.Australia
{
    public static class RandomLocalityExtensions
    {
        /// <summary>Returns a random Australian Business Number (ABN).</summary>
        public static string NextAbn(this Random random)
        {
            return String.Format("{0} {1} {2} {3}", random.NextNumber(99), random.NextNumber(999), random.NextNumber(999), random.NextNumber(999));
        }

        /// <summary>Returns a random Australian mobile phone number.</summary>
        public static string NextMobileNumber(this Random random)
        {
            return String.Format("{0:0000000000}", random.Number(0, 999999999));
        }

        /// <summary>Returns a random Australian Tax File Number.</summary>
        public static string NextTaxFileNumber(this Random random)
        {
            // TODO: Do check digit that actually works?
            // Are there demo TFNs that we should be using?
            var str = String.Format("{0:D9}", random.Number(0, 999999999));

            Debug.Assert(str.Length <= 9);
            return str;
        }

    }
}
