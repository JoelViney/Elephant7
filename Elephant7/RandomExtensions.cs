using System;
using System.Collections.Generic;

namespace Elephant7
{
    /// <summary>
    /// Extends System.Random and provides more specific random methods.
    /// </summary>
    public static class RandomExtensions
    {
        #region Boolean

        /// <summary>Returns a random boolean value.</summary>
        public static Boolean NextBoolean(this Random random)
        {
            return (random.Next(0, 1) == 1);
        }

        #endregion


        #region Currency

        public static decimal NextCurrency(this Random random)
        {
            decimal dec = random.NextDecimal(1000000); // Make it a reasonable number, say 1 mil
            return Math.Round(dec, 2);
        }

        public static decimal NextCurrency(this Random random, decimal max)
        {
            decimal dec = random.NextDecimal(0, max);
            return Math.Round(dec, 2);
        }

        public static decimal NextCurrency(this Random random, decimal min, decimal max)
        {
            decimal dec = random.NextDecimal(min, max);
            return Math.Round(dec, 2);
        }

        #endregion

        #region DateTime

        /// <summary>Returns a random date.</summary>
        /// <returns>Returns the generated date ranging from 1-Jan-0001 to 31-Dec-9999.</returns>
        public static DateTime NextDateTime(this Random random)
        {
            //  Date variables are stored as IEEE 64-bit (8-byte) integers that represent dates ranging
            // from January 1 of the year 1 through December 31 of the year 9999, and times from 0:00:00 (midnight) through 11:59:59 PM.
            return random.NextDateTime(System.DateTime.MinValue, System.DateTime.MaxValue);
        }

        /// <summary>Returns a random date between the date range provided.</summary>
        public static DateTime NextDateTime(this Random random, DateTime minValue, DateTime maxValue)
        {
            TimeSpan span = maxValue - minValue;
            int randomMinutes = random.Next(0, (int)span.TotalMinutes + 1);
            return minValue + TimeSpan.FromMinutes(randomMinutes);
        }

        #endregion


        #region Decimal

        /// <summary>
        /// Returns an Int32 with a random value across the entire range of
        /// possible values.
        /// </summary>
        private static int NextInt32(Random random)
        {
            unchecked
            {
                int firstBits = random.Next(0, 1 << 4) << 28;
                int lastBits = random.Next(0, 1 << 28);
                return firstBits | lastBits;
            }
        }

        /// <summary>Returns a random decimal value.</summary>
        public static decimal NextDecimal(this Random random)
        {
            return random.NextDecimal(decimal.MinValue, decimal.MaxValue);
        }

        /// <summary>Returns a random decimal value less than the provided max value.</summary>
        public static decimal NextDecimal(this Random random, decimal max)
        {
            return random.NextDecimal(decimal.Zero, max);
        }

        /// <summary>Returns a random decimal between the provided min and max values.</summary>
        public static decimal NextDecimal(this Random random, decimal min, decimal max)
        {
            byte fromScale = new System.Data.SqlTypes.SqlDecimal(min).Scale;
            byte toScale = new System.Data.SqlTypes.SqlDecimal(max).Scale;

            byte scale = (byte)(fromScale + toScale);
            if (scale > 28)
            {
                scale = 28;
            }

            decimal r = new decimal(random.Next(), random.Next(), random.Next(), false, scale);
            if (Math.Sign(min) == Math.Sign(max) || min == 0 || max == 0)
            {
                return decimal.Remainder(r, max - min) + min;
            }

            bool getFromNegativeRange = (double)min + random.NextDouble() * ((double)max - (double)min) < 0;
            return getFromNegativeRange ? decimal.Remainder(r, -min) + min : decimal.Remainder(r, max);
        }

        #endregion

        #region Enum

        /// <summary>Returns a random value from the provided enumeration.</summary>
        public static T NextEnum<T>(this Random random)
        {
            Array values = System.Enum.GetValues(typeof(T));
            var value = (T)values.GetValue(random.Next(0, values.Length));
            return value;
        }

        #endregion


        #region IList

        /// <summary>Returns a random value from the provided list.</summary>
        public static T NextListItem<T>(this Random random, IList<T> list)
        {
            if (list.Count == 0)
                return default(T);

            int index = random.Next(0, list.Count);

            var value = list[index];
            return value;
        }

        #endregion


        #region Number

        /// <summary>
        /// Returns a random whole number between 0 and the max parameter.
        /// </summary>
        public static int NextNumber(this Random random, int max)
        {
            return random.Number(0, max);
        }

        /// <summary>Returns a random whole number between the min and max parameters.</summary>
        public static int Number(this Random random, int min, int max)
        {
            return random.Next(min, (max + 1));
        }

        #endregion


        #region Number Curved

        /// <summary>Returns a whole number between 0 and the max parameter which is weighted to return results in the lower range.</summary>
        public static int NextNumberCurved(this Random random, int max)
        {
            return random.NextNumberCurved(1, max, 1);
        }

        /// <summary>Returns a whole number weighted to return results in the lower range.</summary>
        /// <param name="weight">
        /// The higher the weight the more likley that the number will be closer to 0.
        /// A weight of 1 returns a non-weighted number.
        /// </param>
        public static int NextNumberCurved(this Random random, int max, int weight)
        {
            return random.NextNumberCurved(1, max, weight);
        }

        /// <summary>Returns a whole number weighted to return results in the lower range.</summary>
        /// <param name="weight">
        /// The higher the weight the more likley that the number will be closer to 0.
        /// A weight of 1 returns a non-weighted number.
        /// </param>
        public static int NextNumberCurved(this Random random, int min, int max, int weight)
        {
            // Yeah i know its simple and stupid but im too tired to learn any maths
            int val = max;
            for (int i = 1; i <= weight; i++)
            {
                val = Math.Min(val, random.Number(min, max));
            }
            return val;
        }

        #endregion


        #region Percentage

        /// <summary>Returns a random whole number from 1 to 100.</summary>
        public static int NextPercentage(this Random random)
        {
            return random.Number(1, 100);
        }

        #endregion

        #region T

        /// <summary>Returns one of the objects passed in as a parameter.</summary>
        public static T NextParameter<T>(this Random random, params T[] args)
        {
            int index = random.Next(0, args.Length);

            T value = args[index];

            return value;
        }

        #endregion
    }
}
