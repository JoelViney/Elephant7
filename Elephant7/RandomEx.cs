using Elephant7.Factories;
using Elephant7.Models;
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
        private Lazy<AddressFactory> _addressFactory;
        private Lazy<BusinessFactory> _businessFactory;
        private Lazy<PersonFactory> _personFactory;
        private Lazy<TextFactory> _textFactory;

        #region Constructors...

        public RandomEx()
        {
            this._random = new Random();
            this._addressFactory = new Lazy<AddressFactory>(() => new AddressFactory(this));
            this._businessFactory = new Lazy<BusinessFactory>(() => new BusinessFactory(this));
            this._personFactory = new Lazy<PersonFactory>(() => new PersonFactory(this));
            this._textFactory = new Lazy<TextFactory>(() => new TextFactory(this));

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

        #region Address

        public Address Address()
        {
            var item = this._addressFactory.Value.GetAddress();

            return item;
        }

        #endregion


        #region Boolean

        public Boolean Boolean()
        {
            return (_random.Next(0, 1) == 1);
        }

        #endregion


        #region Business

        public BusinessFactory Business
        {
            get
            {
                var item = this._businessFactory.Value;

                return item;
            }
        }

        #endregion


        #region Currency

        public decimal Currency()
        {
            decimal dec = Decimal(1000000); // Make it a reasonable number, say 1 mil
            return Math.Round(dec, 2);
        }

        public decimal Currency(decimal max)
        {
            decimal dec = Decimal(0, max);
            return Math.Round(dec, 2);
        }

        public decimal Currency(decimal min, decimal max)
        {
            decimal dec = Decimal(min, max);
            return Math.Round(dec, 2);
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


        #region Decimal

        /// <summary>
        /// Returns an Int32 with a random value across the entire range of
        /// possible values.
        /// </summary>
        private int NextInt32()
        {
            unchecked
            {
                int firstBits = _random.Next(0, 1 << 4) << 28;
                int lastBits = _random.Next(0, 1 << 28);
                return firstBits | lastBits;
            }
        }

        public decimal Decimal()
        {
            return Decimal(decimal.MinValue, decimal.MaxValue);
        }

        public decimal Decimal(decimal max)
        {
            return Decimal(decimal.Zero, max);
        }

        public decimal Decimal(decimal min, decimal max)
        {
            byte fromScale = new System.Data.SqlTypes.SqlDecimal(min).Scale;
            byte toScale = new System.Data.SqlTypes.SqlDecimal(max).Scale;

            byte scale = (byte)(fromScale + toScale);
            if (scale > 28)
            {
                scale = 28;
            }

            decimal r = new decimal(_random.Next(), _random.Next(), _random.Next(), false, scale);
            if (Math.Sign(min) == Math.Sign(max) || min == 0 || max == 0)
            {
                return decimal.Remainder(r, max - min) + min;
            }

            bool getFromNegativeRange = (double)min + _random.NextDouble() * ((double)max - (double)min) < 0;
            return getFromNegativeRange ? decimal.Remainder(r, -min) + min : decimal.Remainder(r, max);
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


        #region Percentage

        /// <summary>Returns a random whole number from 1 to 100.</summary>
        public int Percentage()
        {
            return Number(1, 100);
        }

        #endregion


        #region Person

        public Person Person()
        {
            var item = this._personFactory.Value.GetPerson();

            return item;
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


        #region Text

        public TextFactory Text
        {
            get
            {
                var item = this._textFactory.Value;

                return item;
            }
        }

        #endregion
    }
}
