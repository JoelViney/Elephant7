using System;
using System.Collections.Generic;

namespace Elephant7
{
    // Static 
    public partial class RandomEx
    {
        /// <summary>This is exposed so we can write tests.</summary>
        private static Lazy<Random> _instance;

        static RandomEx()
        {
            _instance = new Lazy<Random>(() => new Random());
        }
    }

    /// <summary>Provides an interface to access all of the Random functionality.</summary>
    public partial class RandomEx
    {

        private Random _random;

        #region Constructors...

        public RandomEx()
        {
            this._random = new Random();

        }

        public RandomEx(int seed)
        {
            this._random = new Random(seed);

        }

        public RandomEx(Random random)
        {
            this._random = random;

        }

        #endregion


        #region Boolean

        public Boolean Boolean()
        {
            return (_random.Next(0, 1) == 1);
        }

        #endregion


        #region DateTime

        /// <summary>Generates a random date.</summary>
        /// <returns>Returns the generated date ranging from 1-Jan-0001 to 31-Dec-9999.</returns>
        public DateTime DateTime()
        {
            //  Date variables are stored as IEEE 64-bit (8-byte) integers that represent dates ranging
            // from January 1 of the year 1 through December 31 of the year 9999, and times from 0:00:00 (midnight) through 11:59:59 PM.
            return DateTime(System.DateTime.MinValue, System.DateTime.MaxValue);
        }

        public DateTime DateTime(DateTime minValue, DateTime maxValue)
        {
            TimeSpan span = maxValue - minValue;
            int randomMinutes = _random.Next(0, (int)span.TotalMinutes + 1);
            return minValue + TimeSpan.FromMinutes(randomMinutes);
        }

        #endregion


        #region Enum

        public T Enum<T>()
        {
            Array values = System.Enum.GetValues(typeof(T));
            var value = (T)values.GetValue(_random.Next(0, values.Length));
            return value;
        }

        #endregion


        #region IList

        public T ListItem<T>(IList<T> list)
        {
            if (list.Count == 0)
                return default(T);

            int index = _random.Next(0, list.Count);

            var value = list[index];
            return value;
        }

        #endregion


        #region Number

        /// <summary>Returns a random whole number between 0 and the max parameter.</summary>
        public int Number(int max)
        {
            return Number(0, max);
        }

        /// <summary>Returns a random whole number between the min and max parameters.</summary>
        public int Number(int min, int max)
        {
            return _random.Next(min, (max + 1));
        }

        #endregion


        #region Number Curved

        /// <summary>Returns a whole number between 0 and the max parameter which is weighted to return results in the lower range.</summary>
        public int NumberCurved(int max)
        {
            return NumberCurved(1, max, 1);
        }

        /// <summary>Returns a whole number weighted to return results in the lower range.</summary>
        /// <param name="weight">
        /// The higher the weight the more likley that the number will be closer to 0.
        /// A weight of 1 returns a non-weighted number.
        /// </param>
        public int NumberCurved(int max, int weight)
        {
            return NumberCurved(1, max, weight);
        }

        /// <summary>Returns a whole number weighted to return results in the lower range.</summary>
        /// <param name="weight">
        /// The higher the weight the more likley that the number will be closer to 0.
        /// A weight of 1 returns a non-weighted number.
        /// </param>
        public int NumberCurved(int min, int max, int weight)
        {
            // Yeah i know its simple and stupid but im too tired to learn any maths
            int val = max;
            for (int i = 1; i <= weight; i++)
            {
                val = Math.Min(val, Number(min, max));
            }
            return val;
        }

        #endregion


        #region T

        public T Either<T>(params T[] args)
        {
            int index = _random.Next(0, args.Length);

            T value = args[index];

            return value;
        }

        #endregion
    }
}
