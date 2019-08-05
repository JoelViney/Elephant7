using System;
using System.IO;
using System.Reflection;

namespace Elephant7
{
    /// <summary>
    /// This represents the information about a TestData file that is used 
    /// to retrive random individual lines from the file.
    /// </summary>
    internal class DataFile
    {
        private string _fileName;
        private int _randomNumberWeight;
        private string[] _lines;

        #region Constructors...

        internal DataFile(string fileName) : this(fileName, 1)
        {

        }

        /// <summary>Default Constructor</summary>
        /// <param name="fileName">The name and extension of the text file</param>
        /// <param name="randomNumberWeight">The weight value applied to the selection of a random line</param>
        internal DataFile(string fileName, int randomNumberWeight)
        {
            this._fileName = fileName;
            this._randomNumberWeight = randomNumberWeight;
        }

        #endregion

        private void LoadFromFile()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var resourceName = $"{assembly.GetName().Name}.Data.{this._fileName}";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string result = reader.ReadToEnd();

                    this._lines = result.Split("\r\n");
                }
            }

        }

        internal string GetRandomLine(Random random)
        {
            if (_lines == null)
            {
                LoadFromFile();
            }

            int index = random.NextNumberCurved((_lines.Length - 1), _randomNumberWeight);

            string output = _lines[index];

            return output;
        }
    }
}
