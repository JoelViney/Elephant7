using Elephant7.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elephant7.Factories
{
    internal class PersonFactory
    {
        private RandomEx _random;

        private DataFile _titleMaleFile;
        private DataFile _titleFemaleFile;
        private DataFile _firstNameMaleFile;
        private DataFile _firstNameFemaleFile;
        private DataFile _lastNameFile;


        internal PersonFactory(RandomEx random)
        {
            this._random = random;
            this._titleMaleFile = new DataFile(random, "TitleMale.txt", 2);
            this._titleFemaleFile = new DataFile(random, "TitleFemale.txt", 2);
            this._firstNameMaleFile = new DataFile(random, "FirstNameMale.txt", 2);
            this._firstNameFemaleFile = new DataFile(random, "FirstNameFemale.txt", 2);
            this._lastNameFile = new DataFile(random, "LastName.txt", 2);
        }

        public Person GetPerson()
        {
            var person = new Person();

            if (this._random.Percentage() > 50)
            {
                person.Gender = GenderType.Male;
                person.Title = _titleMaleFile.GetRandomLine();
                person.FirstName = _firstNameMaleFile.GetRandomLine();
                if (this._random.Percentage() > 30)
                {
                    person.MiddleName = _firstNameMaleFile.GetRandomLine();
                }
            }
            else
            {
                person.Gender = GenderType.Female;
                person.Title = _titleFemaleFile.GetRandomLine();
                person.FirstName = _firstNameFemaleFile.GetRandomLine();
                if (this._random.Percentage() > 30)
                {
                    person.MiddleName = _firstNameFemaleFile.GetRandomLine();
                }
            }

            person.DateOfBirth = this._random.DateTime(new DateTime(1930, 01, 01), DateTime.Now.AddYears(-15));
            person.LastName = _lastNameFile.GetRandomLine();
            person.EmailAddress = String.Format("{0}.{1}@test.com", person.FirstName, person.LastName);
            return person;
        }
    }
}
