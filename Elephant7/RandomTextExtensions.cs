using Elephant7.Helpers;
using System;
using System.Diagnostics;

namespace Elephant7
{
    /// <summary>
    /// Provides access to Text based random values such as words, sentences and paragraphs.
    /// </summary>
    public static class RandomTextExtensions
    {
        private static readonly Lazy<DataFile> _wordFile;
        private static readonly Lazy<DataFile> _wordNoiseFile;

        static RandomTextExtensions()
        {
            _wordFile = new Lazy<DataFile>(() => new DataFile("Word.txt"));
            _wordNoiseFile = new Lazy<DataFile>(() => new DataFile("WordNoise.txt"));
        }

        /// <summary>
        /// Returns a single noise word (a word that is used to fill out a sentence
        /// e.g. 'a' 'of' 'where'.
        /// </summary>
        internal static string NextNoiseWord(this Random random)
        {
            return _wordNoiseFile.Value.GetRandomLine(random);
        }

        #region Code

        /// <summary>Returns a random combination of characters and numbers.</summary>
        public static string NextCode(this Random random)
        {
            return random.NextCode(50);
        }

        /// <summary>Returns a random combination of characters and numbers.</summary>
        /// <param name="maxLength">The maximum length of the code.</param>
        public static string NextCode(this Random random, int maxLength)
        {
            string code = "";
            maxLength = random.NextNumberCurved(1, maxLength, 1);

            for (int i = 0; i < maxLength; i++)
            {
                // Return a number or a string?
                int number = random.Number(1, 10);
                if (number < 5)
                    code += Convert.ToChar(random.Number(Convert.ToInt32('a'), Convert.ToInt32('z')));
                else if (number < 9)
                    code += Convert.ToChar(random.Number(Convert.ToInt32('A'), Convert.ToInt32('Z')));
                else
                    code += random.Number(0, 9).ToString();
            }

            return code;
        }

        /// <summary>Returns a random combination of characters and numbers.</summary>
        /// <param name="format">The format to create the code to. '#' = Number 'a' = Lowercase letter. 'A' = Uppercase letter.</param>
        public static string NextCode(this Random random, string format)
        {
            string code = "";
            char[] charArray = format.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                char ch = charArray[i];
                switch (ch)
                {
                    case '#':
                        code += random.Number(0, 9).ToString();
                        break;
                    case 'a':
                        code += Convert.ToChar(random.Number(Convert.ToInt32('a'), Convert.ToInt32('z')));
                        break;
                    case 'A':
                        code += Convert.ToChar(random.Number(Convert.ToInt32('A'), Convert.ToInt32('Z')));
                        break;
                    default:
                        code += ch.ToString();
                        break;
                }
            }
            return code;
        }

        #endregion

        #region Heading

        /// <summary>Returns a short sentence of random words in title case used to represent a Heading.</summary>
        public static string NextHeading(this Random random)
        {
            return random.NextHeading(0);
        }

        /// <summary>Returns a short sentence of random words in title case used to represent a Heading smaller than the specified maximum length.</summary>
        /// <param name="maxLength">
        /// The maximum length of the word.
        /// If this is 0 it is considered to have no maximum length.
        /// </param>
        public static string NextHeading(this Random random, int maxLength)
        {
            string output = "";
            int wordCount = random.Number(1, 8);

            for (int i = 0; i <= wordCount; i++)
            {
                string word;
                if ((i % 3) == 0)
                {
                    word = random.NextNoiseWord();
                }
                else if (random.Number(1, 4) == 1)
                {   // This was a freeky bug I wrote, that creates interesting headings
                    word = output + random.NextWord();
                }
                else
                {
                    word = random.NextWord();
                }

                if (maxLength == 0 || (output.Length + word.Length) < maxLength)
                {
                    output = output + " " + word;
                }
            }

            output = TextHelper.TitleCase(output.Trim());

            return output;
        }

        #endregion

        #region Paragraph

        /// <summary>Returns a paragraph of random words.</summary>
        public static string NextParagraph(this Random random)
        {
            return random.NextParagraph(0);
        }

        /// <summary>Returns a paragraph of random words smaller than the specified maximum length.</summary>
        /// <param name="maxLength">
        /// The maximum length of the word.
        /// If this is 0 it is considered to have no maximum length.
        /// </param>
        public static string NextParagraph(this Random random, int maxLength)
        {
            string paragraph = "";
            int count = random.Number(1, 6) + random.Number(1, 6) + random.Number(1, 6); // 3-18 Sentences
            for (int i = 0; i < count; i++)
            {
                var sentence = random.NextSentence();
                if (maxLength == 0 || (paragraph.Length + sentence.Length) <= maxLength)
                {
                    paragraph += sentence;
                    if (paragraph.Length < maxLength)
                    {
                        paragraph += " ";
                    }
                }
            }
            paragraph = paragraph.Trim();
            return paragraph;
        }

        #endregion

        #region Sentence

        /// <summary>Returns a short sentence of random words.</summary>
        public static string NextSentence(this Random random)
        {
            return random.NextSentence(0);
        }

        /// <summary>Returns a short sentence of random words smaller than the specified maximum length.</summary>
        /// <param name="maxLength">
        /// The maximum length of the word.
        /// If this is 0 it is considered to have no maximum length.
        /// </param>
        public static string NextSentence(this Random random, int maxLength)
        {
            int count = random.NextNumberCurved(3, 14, 2); // 3-14 Words
            string sentence = "";
            string word;

            if (maxLength == 1)
                return "."; // Stop the smartasses trying to crash me
            else if (maxLength != 0)
                maxLength--;    // Make it a bit shorter so we can add a full stop ect...

            // Add the first word
            count++;
            if (random.NextNumber(4) == 0)
                word = TextHelper.TitleCase(random.NextNoiseWord());
            else
                word = TextHelper.TitleCase(random.NextWord());

            if (maxLength == 0)
                sentence += word;
            else
            {
                if ((sentence.Length + word.Length) < maxLength)
                    sentence += word;
                else
                    sentence = word.Substring(0, maxLength);
            }

            // Add the rest
            for (int i = 1; i < count; i++)
            {
                // Mabe add a comma
                if (i > 2 && (random.NextNumber(6) == 1))
                {
                    word += ",";
                }
                word += " " + random.NextNoiseWord() + " " + random.NextWord();

                if (maxLength == 0 || (sentence.Length + word.Length) < maxLength)
                {
                    sentence += word;
                }
            }

            if (random.NextNumber(20) == 0)
                sentence += "!";  // Very important sentence
            else if (random.NextNumber(20) == 0)
                sentence += "?";  // Confused sentence
            else
                sentence += ".";  // Normal sentence
            return sentence;
        }

        #endregion

        #region Word

        /// <summary>Returns a single random word.</summary>
        public static string NextWord(this Random random)
        {
            return random.NextWord(0);
        }

        /// <summary>Returns a single random word smaller than the specified maximum length.</summary>
        /// <param name="maxLength">
        /// The maximum length of the word.
        /// If this is 0 it is considered to have no maximum length.
        /// </param>
        public static string NextWord(this Random random, int maxLength)
        {
            if (maxLength == 0)
            {
                return _wordFile.Value.GetRandomLine(random);
            }
            else
            {
                string word;
                word = _wordFile.Value.GetRandomLine(random);
                if (word.Length > maxLength)
                    return word.Substring(0, maxLength);
                else
                    return word;
            }
        }

        #endregion


        #region BusinessName

        // Not sure where this should really go.

        /// <summary>Returns a random business name.</summary>
        public static string NextBusinessName(this Random random, int maxLength)
        {
            string output = "";
            int wordCount = random.NextNumberCurved(1, 6, 2);

            for (int i = 0; i <= wordCount; i++)
            {
                string word;
                if (i == wordCount && random.Number(1, 4) == 1)
                {
                    word = "Co";
                }
                else if (i == wordCount && random.Number(1, 4) == 1)
                {
                    word = "Inc";
                }
                else if (i == wordCount && random.Number(1, 4) == 1)
                {
                    word = "PTY LTD";
                }
                else if (i != 0 && random.Number(1, 8) == 1)
                {
                    word = random.NextNoiseWord();
                }
                else if (random.Number(1, 4) == 1)
                {   // This was a freeky bug I wrote, that creates interesting headings
                    word = output + random.NextWord();
                }
                else
                {
                    word = random.NextWord();
                }

                if (output == "")
                {
                    if (maxLength == 0 || word.Length <= maxLength)
                    {
                        output += word;
                    }
                }
                else
                {
                    if (maxLength == 0 || (output + " " + word).Length <= maxLength)
                    {
                        output = output + " " + word;
                    }
                }

                Debug.Assert(output.Length <= maxLength);
            }

            output = TextHelper.TitleCase(output);

            return output;
        }

        #endregion

    }
}
