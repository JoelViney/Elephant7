using System;
using System.Collections.Generic;
using System.Text;

namespace Elephant7.Addresses
{

    /// <summary>
    /// Represents a street address in the following format.
    /// [(Unit or Flat Number)/](Street Number) (Street Name) (Street Type)
    /// 
    /// 229 Acton Rd
    /// ACTON PARK TAS 7021
    /// </summary>
    public class Address
    {

        internal Address()
        {

        }

        public string CompanyName { get; internal set; }

        public string Name { get; internal set; }

        public string Street1 { get; internal set; }

        public string Street2 { get; internal set; }

        public string Suburb { get; internal set; }

        public string StateAbbreviation { get; internal set; }

        public string State
        {
            get
            {
                switch (this.StateAbbreviation)
                {
                    case "ACT": return "Australian Capital Territory";
                    case "QLD": return "Queensland";
                    case "NSW": return "New South Wales";
                    case "NT": return "Northern Territory";
                    case "SA": return "South Australia";
                    case "VIC": return "Victoria";
                    case "WA": return "Western Australia";
                    default: return StateAbbreviation;
                }
            }
        }

        public string PostCode { get; internal set; }

    }
}
