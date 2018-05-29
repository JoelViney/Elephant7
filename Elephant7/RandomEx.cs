using System;

namespace Elephant7
{
    /// <summary>Provides an interface to access all of the Random functionality.</summary>
    public static class RandomEx
    {
        /// <summary>This is exposed so we can write tests.</summary>
        public static Random Random { get; set; }

        #region Constructors...

        static RandomEx()
        {
            Random = new Random();
        }

        #endregion

        public static Boolean Boolean()
        {
            return (Random.Next(0, 1) == 0);
        }
    }
}
