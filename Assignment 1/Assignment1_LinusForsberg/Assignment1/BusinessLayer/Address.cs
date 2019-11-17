using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    // Class describing a Address object with simple get and set properties.
    // Implements interface IAddress

    [Serializable]
    public class Address : IAddress
    {
        private string _street;
        private string _zipCode;
        private string _city;
        private string _country;

        public Address(string street, string zipCode, string city, string country)
        {
            this._street = street;
            this._zipCode = zipCode;
            this._city = city;
            this._country = country;
        }

        public string Street {
            get { return _street; }
            set
            {
                _street = value;
            }
        }

        public string ZipCode {
            get { return _zipCode; }
            set
            {
                _zipCode = value;
            }
        }

        public string City {
            get { return _city; }
            set
            {
                _city = value;
            }
        }

        public string Country {
            get { return _country; }
            set
            {
                _country = value;
            }
        }

        public override string ToString()
        {
            string strAddress = "Address: " + Street + "\n" + ZipCode + " " + City + "\n" + Country;
            return strAddress;
        }
    }
}
