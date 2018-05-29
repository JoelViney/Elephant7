using System;
using System.Collections.Generic;
using System.Text;

namespace Elephant7
{
    /// <summary>
    /// Provides common text manipulation functinality.
    /// </summary>
    internal static class TextHelper
    {
        /// <summary>
        /// Returns the given phrase in Title Case. 
        /// </summary>
        /// <param name="phrase">The phrase to be formatted.</param>
        /// <returns>formatted string; example: The Procedure Returns A 
        /// Formatted String In Title Case.</returns>
        internal static string TitleCase(string phrase)
        {
            System.Text.StringBuilder newString = new System.Text.StringBuilder();
            System.Text.StringBuilder nextString = new System.Text.StringBuilder();
            string[] phraseArray = phrase.Split(null);
            string word;
            string returnValue;

            for (int i = 0; i < phraseArray.Length; i++)
            {
                word = phraseArray[i].ToLower();
                if (word.Length > 1)
                {
                    if (word.Substring(1, 1) == "'")
                    {
                        // Process word with apostrophe at position 1 in 0 based string.
                        if (nextString.Length > 0)
                            nextString.Replace(nextString.ToString(), null);
                        nextString.Append(word.Substring(0, 1).ToUpper());
                        nextString.Append("'");
                        if (word.Length > 2)
                            nextString.Append(word.Substring(2, 1).ToUpper());
                        if (word.Length > 3)
                            nextString.Append(word.Substring(3).ToLower());
                        nextString.Append(" ");
                    }
                    else
                    {
                        if (word.Length > 1 && word.Substring(0, 2) == "mc")
                        {
                            // Process McName.
                            if (nextString.Length > 0)
                                nextString.Replace(nextString.ToString(), null);
                            nextString.Append("Mc");
                            if (word.Length > 2)
                                nextString.Append(word.Substring(2, 1).ToUpper());
                            if (word.Length > 3)
                                nextString.Append(word.Substring(3).ToLower());
                            nextString.Append(" ");
                        }
                        else
                        {
                            // Process normal word (possible apostrophe near end of word.
                            if (nextString.Length > 0)
                                nextString.Replace(nextString.ToString(), null);
                            nextString.Append(word.Substring(0, 1).ToUpper());
                            nextString.Append(word.Substring(1).ToLower());
                            nextString.Append(" ");
                        }
                    }
                }
                else
                {
                    // Process normal single character length word.
                    if (nextString.Length > 0) nextString.Replace(nextString.ToString(), null);
                    nextString.Append(word.ToUpper());
                    nextString.Append(" ");
                }

                newString.Append(nextString);
            }

            returnValue = newString.ToString();
            return returnValue.Trim();
        }
    }
}
