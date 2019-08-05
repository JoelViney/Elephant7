using Elephant7.Models;
using System;

namespace Elephant7
{
    public static class RandomPersonExtensions
    {
        private static Lazy<DataFile> _titleMaleFile;
        private static Lazy<DataFile> _titleFemaleFile;
        private static Lazy<DataFile> _firstNameMaleFile;
        private static Lazy<DataFile> _firstNameFemaleFile;
        private static Lazy<DataFile> _lastNameFile;

        #region Constructors...

        static RandomPersonExtensions()
        {
            _titleMaleFile = new Lazy<DataFile>(() => new DataFile("TitleMale.txt", 2));
            _titleFemaleFile = new Lazy<DataFile>(() => new DataFile("TitleFemale.txt", 2));
            _firstNameMaleFile = new Lazy<DataFile>(() => new DataFile("FirstNameMale.txt", 2));
            _firstNameFemaleFile = new Lazy<DataFile>(() => new DataFile("FirstNameFemale.txt", 2));
            _lastNameFile = new Lazy<DataFile>(() => new DataFile("LastName.txt", 2));
        }

        #endregion

        /// <summary>Returns a person object populated with random values.</summary>
        public static Person NextPerson(this Random random)
        {
            var person = new Person();

            if (random.NextPercentage() > 50)
            {
                person.Gender = GenderType.Male;
                person.Title = _titleMaleFile.Value.GetRandomLine(random);
                person.FirstName = _firstNameMaleFile.Value.GetRandomLine(random);
                if (random.NextPercentage() > 30)
                {
                    person.MiddleName = _firstNameMaleFile.Value.GetRandomLine(random);
                }
            }
            else
            {
                person.Gender = GenderType.Female;
                person.Title = _titleFemaleFile.Value.GetRandomLine(random);
                person.FirstName = _firstNameFemaleFile.Value.GetRandomLine(random);
                if (random.NextPercentage() > 30)
                {
                    person.MiddleName = _firstNameFemaleFile.Value.GetRandomLine(random);
                }
            }

            person.DateOfBirth = random.NextDateTime(new DateTime(1930, 01, 01), DateTime.Now.AddYears(-15));
            person.LastName = _lastNameFile.Value.GetRandomLine(random);
            person.EmailAddress = String.Format("{0}.{1}@test.com", person.FirstName, person.LastName);
            return person;
        }
    }
}
