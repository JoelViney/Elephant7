using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Elephant7.Helpers;
using Elephant7.Texts;

namespace Elephant7.Business
{
    public static class RandomBusinessExtensions
    {
        /// <summary>Returns a random Australian Business Number (ABN).</summary>
        public static string NextAbn(this Random random)
        {
            return String.Format("{0} {1} {2} {3}", random.NextNumber(99), random.NextNumber(999), random.NextNumber(999), random.NextNumber(999));
        }


        /// <summary>Returns a random business name.</summary>
        public static string NextBusinessName(this Random random, int maxLength)
        {
            string output = "";
            int wordCount = random.NextNumberCurved(1, 6, 2);

            for (int i = 0; i <= wordCount; i++)
            {
                string word = "";

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

        /// <summary>Returns a random Australian mobile phone number.</summary>
        public static string NextMobileNumber(this Random random)
        {
            return String.Format("{0:0000000000}", random.Number(0, 999999999));
        }

        /// <summary>Returns a random Australian Tax File Number.</summary>
        public static string NextTaxFileNumber(this Random random)
        {
            // TODO: Do check digit that actually works?
            // Are there demo TFNs that we should be using?
            var str = String.Format("{0:D9}", random.Number(0, 999999999));

            Debug.Assert(str.Length <= 9);
            return str;
        }

    }
}
