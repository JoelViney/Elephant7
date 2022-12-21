using System;

namespace Elephant7.Australia
{
    /// <summary>Contains random functionality specific to Australia.</summary>
    public class Australian
    {
        private readonly Random _random;

        internal Australian(Random random)
        {
            _random = random;
        }

        /// <summary>Returns a random Australian Business Number (ABN).</summary>
        public string NextAbn()
        {
            return String.Format("{0} {1} {2} {3}", _random.NextNumber(99), _random.NextNumber(999), _random.NextNumber(999), _random.NextNumber(999));
        }
    }
}
