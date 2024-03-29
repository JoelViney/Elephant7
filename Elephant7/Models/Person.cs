﻿using System;

namespace Elephant7.Models
{
    public enum GenderType
    {
        Male,
        Female
    }

    public class Person
    {
        internal Person()
        {

        }

        public string Title { get; internal set; }

        public string FirstName { get; internal set; }

        public string MiddleName { get; internal set; }

        public string LastName { get; internal set; }

        public GenderType Gender { get; internal set; }

        public string EmailAddress { get; internal set; }

        public DateTime DateOfBirth { get; set; }


        /// <summary>
        /// Returns the persons name in the following format [Title] [FirstName] [?MiddleName] [LastName]
        /// </summary>
        public string FullName
        {
            get
            {
                if (String.IsNullOrEmpty(this.MiddleName))
                    return String.Format("{0} {1} {2}", this.Title, this.FirstName, this.LastName);
                else
                    return String.Format("{0} {1} {2} {3}", this.Title, this.FirstName, this.MiddleName, this.LastName);
            }
        }
    }
}
