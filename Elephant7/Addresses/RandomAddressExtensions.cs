using System;
using System.Collections.Generic;
using System.Text;
using Elephant7.People;

namespace Elephant7.Addresses
{
    public static class RandomAddressExtensions
    {
        private const int StreetPrefixPercentage = 2;   // The percentage chance of the prefix being added to the file
        private const int UnitFlatPercentage = 2;       // The chance of the address being a unit
        private const int UnitFlatMaxNumber = 100;      // The highest number unit
        private const int UnitFlatGenerateWeight = 4;   // The wieght for generating a lower numberrr

        private const int StreetNumberMax = 1000;           // The highest number of the street
        private const int StreetNumberGenerateWeight = 8;   // The weight for generating a lower street number

        private static Lazy<DataFile> _streetNameFile;
        private static Lazy<DataFile> _streetPrefixFile;
        private static Lazy<DataFile> _streetTypeFile;
        private static Lazy<DataFile> _addressLocalityFile;

        #region Constructors...

        static RandomAddressExtensions()
        {
            _streetNameFile = new Lazy<DataFile>(() => new DataFile("StreetName.txt", 1));
            _streetPrefixFile = new Lazy<DataFile>(() => new DataFile("StreetPrefix.txt", 1));
            _streetTypeFile = new Lazy<DataFile>(() => new DataFile("StreetType.txt", 1));
            _addressLocalityFile = new Lazy<DataFile>(() => new DataFile("AddressLocality.txt", 1));
        }

        #endregion

        /// <summary>
        /// Returns an AddressInstance object with a random Address.
        /// </summary>
        public static Address NextAddress(this Random random)
        {
            var person = random.NextPerson();

            var address = new Address()
            {
                // TOTO Add CompanyName
                Name = person.FullName,
                Street1 = random.NextStreetAddress()
                // TODO: Add Street2
            };

            string line = _addressLocalityFile.Value.GetRandomLine(random);
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
        private static string NextStreetAddress(this Random random)
        {
            string street1 = string.Format("{0}{1} {2}{3} {4}",
                random.NextPercentage() <= UnitFlatPercentage ? random.NextNumberCurved(UnitFlatMaxNumber, UnitFlatGenerateWeight) + "/" : "",
                random.NextNumberCurved(StreetNumberMax, StreetNumberGenerateWeight),
                random.NextPercentage() <= StreetPrefixPercentage ? _streetPrefixFile.Value.GetRandomLine(random) + " " : "",
                _streetNameFile.Value.GetRandomLine(random),
                _streetTypeFile.Value.GetRandomLine(random)
                );

            return street1;
        }
    }
}
