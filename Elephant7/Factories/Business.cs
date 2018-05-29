using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Elephant7.Factories
{
    public class BusinessFactory
    {
        private RandomEx _random;

        #region Constructors...

        internal BusinessFactory(RandomEx random)
        {
            this._random = random;
        }

        #endregion



        public string Abn()
        {
            return String.Format("{0} {1} {2} {3}", _random.Number(99), _random.Number(999), _random.Number(999), _random.Number(999));
        }

        public string BusinessName(int maxLength)
        {
            string output = "";
            int wordCount = _random.NumberCurved(1, 6, 2);

            for (int i = 0; i <= wordCount; i++)
            {
                string word = "";

                if (i == wordCount && _random.Number(1, 4) == 1)
                {
                    word = "Co";
                }
                else if (i == wordCount && _random.Number(1, 4) == 1)
                {
                    word = "Inc";
                }
                else if (i == wordCount && _random.Number(1, 4) == 1)
                {
                    word = "PTY LTD";
                }
                else if (i != 0 && _random.Number(1, 8) == 1)
                {
                    word = _random.Text.NoiseWord();
                }
                else if (_random.Number(1, 4) == 1)
                {   // This was a freeky bug I wrote, that creates interesting headings
                    word = output + _random.Text.Word();
                }
                else
                {
                    word = _random.Text.Word();
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

        public string MobileNumber()
        {
            return String.Format("{0:0000000000}", _random.Number(0, 999999999));
        }

        public string TaxFileNumber()
        {
            // TODO: Do check digit that actually works?
            // Are there demo TFNs that we should be using?
            var str = String.Format("{0:D9}", _random.Number(0, 999999999));

            Debug.Assert(str.Length <= 9);
            return str;
        }

    }
}
