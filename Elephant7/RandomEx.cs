using System;
using System.Collections.Generic;

namespace Elephant7
{
    // STatic 
    public partial class RandomEx
    {
        /// <summary>This is exposed so we can write tests.</summary>
        private static Lazy<Random> RandomInstance { get; set; }


        static RandomEx()
        {
            RandomInstance = new Lazy<Random>(() => new Random());
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

        public Boolean Boolean()
        {
            return (_random.Next(0, 1) == 1);
        }

        public T Enum<T>()
        {
            Array values = System.Enum.GetValues(typeof(T));
            var value = (T)values.GetValue(_random.Next(0, values.Length));
            return value;
        }

        public T ListItem<T>(IList<T> list)
        {
            if (list.Count == 0)
                return default(T);

            int index = _random.Next(0, list.Count);

            var value = list[index];
            return value;
        }
    }
}
