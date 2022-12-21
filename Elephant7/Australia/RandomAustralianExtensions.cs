using System;

namespace Elephant7.Australia
{
    public static class RandomAustralianExtensions
    {
        public static Australian Australian(this Random random)
        {
            return new Australian(random);
        }
    }
}
