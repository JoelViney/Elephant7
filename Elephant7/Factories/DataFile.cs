using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Elephant7.Factories
{
    /// <summary>
    /// This represents the information about a TestData file that is used 
    /// to retrive random individual lines from the file.
    /// </summary>
    internal class DataFile
    {
        private RandomEx _random;

        private string _fileName;
        private int _randomNumberWeight;
        private string[] _lines;

        #region Constructors...

        /// <summary>Default Constructor</summary>
        /// <param name="fileName">The name and extension of the text file</param>
        /// <param name="randomNumberWeight">The weight value applied to the selection of a random line</param>
        internal DataFile(RandomEx random, string fileName, int randomNumberWeight)
        {
            this._random = random;
            this._fileName = fileName;
            this._randomNumberWeight = randomNumberWeight;
        }

        #endregion

        private string FilePathName
        {
            get
            {
                string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data");
                string filePathName = Path.Combine(folderPath, _fileName);
                return filePathName;
            }
        }

        internal string GetRandomLine()
        {
            if (_lines == null)
            {
                _lines = File.ReadAllLines(this.FilePathName);
            }

            int index = _random.NumberCurved((_lines.Length - 1), _randomNumberWeight);

            string output = _lines[index];

            return output;
        }
    }
}
