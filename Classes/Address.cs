using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Enum;


namespace Assignment_1.Classes
{

    /// <summary>
    /// A class to represent an address
    /// <author> Agnes Hägnestrand and Andreas Holm</author>
    /// </summary>
    public class Address
    {
        public string street;
        public string ZipCode;
        public string city;
        public Countries country;
        //private string uniqueAttribute;



        /// <summary>
        /// Constructor for the Address class, sets all the properties
        /// </summary>
        /// <param name="street"></param>
        /// <param name="ZipCode"></param>
        /// <param name="city"></param>
        /// <param name="country"></param>
        public Address(string street, string ZipCode, string city, Countries country)
        {
            this.street = street;
            this.ZipCode = ZipCode;
            this.city = city;
            this.country = country;
        }

        public string Street { get => street; set => street = value; }
        public string ZIPCode { get => ZipCode; set => ZipCode = value; }
        public string City { get => city; set => city = value; }
        public Countries Country { get => country; set => country = value; }
        
    }
}
