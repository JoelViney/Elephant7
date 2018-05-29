using System;
using System.Collections.Generic;
using System.Text;

namespace Elephant7.Factories
{
    /// <summary>
    /// This class provides Shared/Static* functions that can
    /// be used to get random words and generate sentences, headings and paragraphs.
    /// * This means it is not associated with a specific instance 
    /// of a class or structure.  
    /// </summary>
    public class TextFactory
    {
        private RandomEx _random;

        static DataFile _wordFile;
        static DataFile _wordNoiseFile;

        #region Constructors...

        internal TextFactory(RandomEx random)
        {
            this._random = random;
            _wordFile = new DataFile(random, "Word.txt", 1);
            _wordNoiseFile = new DataFile(random, "WordNoise.txt", 1);
        }

        #endregion
        
        /// <summary>Returns a random combination of characters and numbers.</summary>
        public string Code()
        {
            return Code(50);
        }

        /// <summary>Returns a random combination of characters and numbers.</summary>
        /// <param name="maxLength">
        /// The maximum length of the word.
        /// If this is 0 it will default to a code between 10 and 50 characters.
        /// </param>
        public string Code(int maxLength)
        {
            string code = "";
            maxLength = _random.NumberCurved(1, maxLength, 1);

            for (int i = 0; i < maxLength; i++)
            {
                // Return a number or a string?
                int number = _random.Number(1, 10);
                if (number < 5)
                    code = code + Convert.ToChar(_random.Number(Convert.ToInt32('a'), Convert.ToInt32('z')));
                else if (number < 9)
                    code = code + Convert.ToChar(_random.Number(Convert.ToInt32('A'), Convert.ToInt32('Z')));
                else
                    code = code + _random.Number(0, 9).ToString();
            }

            return code;
        }

        /// <summary>Returns a random combination of characters and numbers.</summary>
        /// <param name="maxLength">
        /// The maximum length of the word.
        /// If this is 0 it is considered to have no maximum length.
        /// </param>
        /// <param name="format">The format to create the code to. '#' = Number 'a' = Lowercase letter. 'A' = Uppercase letter.</param>
        public string Code(string format)
        {
            string code = "";
            char[] charArray = format.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                char ch = charArray[i];
                switch (ch)
                {
                    case '#':
                        code = code + _random.Number(0, 9).ToString();
                        break;
                    case 'a':
                        code = code + Convert.ToChar(_random.Number(Convert.ToInt32('a'), Convert.ToInt32('z')));
                        break;
                    case 'A':
                        code = code + Convert.ToChar(_random.Number(Convert.ToInt32('A'), Convert.ToInt32('Z')));
                        break;
                    default:
                        code = code + ch.ToString();
                        break;
                }
            }
            return code;
        }

        /// <summary>Returns a single random word.</summary>
        public string Word()
        {
            return Word(0);
        }

        /// <summary>Returns a single random word smaller than the specified maximum length.</summary>
        /// <param name="maxLength">
        /// The maximum length of the word.
        /// If this is 0 it is considered to have no maximum length.
        /// </param>
        public string Word(int maxLength)
        {
            if (maxLength == 0)
            {
                return _wordFile.GetRandomLine();
            }
            else
            {
                string word;
                word = _wordFile.GetRandomLine();
                if (word.Length > maxLength)
                    return word.Substring(0, maxLength);
                else
                    return word;
            }
        }

        /// <summary>Returns a short sentence of random words.</summary>
        public string Sentence()
        {
            return Sentence(0);
        }

        /// <summary>Returns a short sentence of random words smaller than the specified maximum length.</summary>
        /// <param name="maxLength">
        /// The maximum length of the word.
        /// If this is 0 it is considered to have no maximum length.
        /// </param>
        public string Sentence(int maxLength)
        {
            int count = _random.NumberCurved(3, 14, 2); // 3-14 Words
            string sentence = "";
            string word = "";

            if (maxLength == 1)
                return "."; // Stop the smartasses trying to crash me
            else if (maxLength != 0)
                maxLength--;    // Make it a bit shorter so we can add a full stop ect...

            // Add the first word
            count++;
            if (_random.Number(4) == 0)
                word = TextHelper.TitleCase(NoiseWord());
            else
                word = TextHelper.TitleCase(Word());

            if (maxLength == 0)
                sentence = sentence + word;
            else
            {
                if ((sentence.Length + word.Length) < maxLength)
                    sentence = sentence + word;
                else
                    sentence = word.Substring(0, maxLength);
            }

            // Add the rest
            for (int i = 1; i < count; i++)
            {
                // Mabe add a comma
                if (i > 2 && (_random.Number(6) == 1))
                {
                    word = ",";
                }
                word = " " + NoiseWord() + " " + Word();

                if (maxLength == 0 || (sentence.Length + word.Length) < maxLength)
                {
                    sentence = sentence + word;
                }
            }

            if (_random.Number(20) == 0)
                sentence = sentence + "!";  // Very important sentence
            else if (_random.Number(20) == 0)
                sentence = sentence + "?";  // Confused sentence
            else
                sentence = sentence + ".";  // Normal sentence
            return sentence;
        }

        /// <summary>Returns a short sentence of random words in title case used to represent a Heading.</summary>
        public string Heading()
        {
            return Heading(0);
        }

        /// <summary>Returns a short sentence of random words in title case used to represent a Heading smaller than the specified maximum length.</summary>
        /// <param name="maxLength">
        /// The maximum length of the word.
        /// If this is 0 it is considered to have no maximum length.
        /// </param>
        public string Heading(int maxLength)
        {
            string output = "";
            int wordCount = _random.Number(1, 8);

            for (int i = 0; i <= wordCount; i++)
            {
                string word = "";
                if ((i % 3) == 0)
                {
                    word = NoiseWord();
                }
                else if (_random.Number(1, 4) == 1)
                {   // This was a freeky bug I wrote, that creates interesting headings
                    word = output + Word();
                }
                else
                {
                    word = Word();
                }

                if (maxLength == 0 || (output.Length + word.Length) < maxLength)
                {
                    output = output + " " + word;
                }
            }

            output = TextHelper.TitleCase(output.Trim());

            return output;
        }

        /// <summary>Returns a paragraph of random words.</summary>
        public string Paragraph()
        {
            return Paragraph(0);
        }

        /// <summary>Returns a paragraph of random words smaller than the specified maximum length.</summary>
        /// <param name="maxLength">
        /// The maximum length of the word.
        /// If this is 0 it is considered to have no maximum length.
        /// </param>
        public string Paragraph(int maxLength)
        {
            string paragraph = "";
            string sentence = "";
            int count = _random.Number(1, 6) + _random.Number(1, 6) + _random.Number(1, 6); // 3-18 Sentences
            for (int i = 0; i < count; i++)
            {
                sentence = Sentence();
                if (maxLength == 0 || (paragraph.Length + sentence.Length) <= maxLength)
                {
                    paragraph = paragraph + sentence;
                    if (paragraph.Length < maxLength)
                    {
                        paragraph = paragraph + " ";
                    }
                }
            }
            paragraph = paragraph.Trim();
            return paragraph;
        }

        /// <summary>
        /// Returns a single noise word (a word that is used to fill out a sentence
        /// e.g. 'a' 'of' 'where'.
        /// </summary>
        internal string NoiseWord()
        {
            return _wordNoiseFile.GetRandomLine();
        }

    }
}
