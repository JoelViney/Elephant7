using Elephant7.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elephant7.Factories
{
    /// <summary>
    /// This class provides a way to generate Addresses.
    /// </summary>
    internal class AddressFactory
    {
        private const int StreetPrefixPercentage = 2;   // The percentage chance of the prefix being added to the file
        private const int UnitFlatPercentage = 2;       // The chance of the address being a unit
        private const int UnitFlatMaxNumber = 100;      // The highest number unit
        private const int UnitFlatGenerateWeight = 4;   // The wieght for generating a lower numberrr

        private const int StreetNumberMax = 1000;           // The highest number of the street
        private const int StreetNumberGenerateWeight = 8;   // The weight for generating a lower street number

        private RandomEx _random;

        private DataFile _streetNameFile;
        private DataFile _streetPrefixFile;
        private DataFile _streetTypeFile;
        private DataFile _addressLocalityFile;

        #region Constructors...

        internal AddressFactory(RandomEx random)
        {
            this._random = random;
            this._streetNameFile = new DataFile(random, "StreetName.txt", 10);
            this._streetPrefixFile = new DataFile(random, "StreetPrefix.txt", 1);
            this._streetTypeFile = new DataFile(random, "StreetType.txt", 2);
            this._addressLocalityFile = new DataFile(random, "AddressLocality.txt", 1);
        }

        #endregion

        /// <summary>
        /// Returns an AddressInstance object with a random Address.
        /// </summary>
        public Address GetAddress()
        {
            var person = this._random.Person();

            var address = new Address()
            {
                // TOTO Add CompanyName
                Name = person.FullName,
                Street1 = GetStreetAddress()
                // TODO: Add Street2
            };

            string line = _addressLocalityFile.GetRandomLine();
            string[] lines = line.Split(',');

            // TODO: Fix this up...
            address.PostCode = lines[0].Replace(@"""", "");
            address.Suburb = lines[1].Replace(@"""", "");
            address.StateAbbreviation = lines[2].Replace(@"""", "");

            return address;
        }

        /// <summary>
        /// Builds and returns a random street address in the following format. 
        /// [(Unit or Flat Number)/](Street Number) (Street Name) (Street Type)
        /// e.g. '229 Acton Road' or '12/181 Oxford Street'
        /// </summary>
        private string GetStreetAddress()
        {
            string street1 = string.Format("{0}{1} {2}{3} {4}",
                _random.Percentage() <= UnitFlatPercentage ? _random.NumberCurved(UnitFlatMaxNumber, UnitFlatGenerateWeight) + "/" : "",
                _random.NumberCurved(StreetNumberMax, StreetNumberGenerateWeight),
                _random.Percentage() <= StreetPrefixPercentage ? _streetPrefixFile.GetRandomLine() + " " : "",
                _streetNameFile.GetRandomLine(),
                _streetTypeFile.GetRandomLine()
                );

            return street1;
        }

    }
}
