using System;

namespace Assignment1
{

    // Abstract class describing a real estate object
    // Implements IEstate interface

   [Serializable]
   public abstract class Estate : IEstate
    {
        private int _id;
        private string _category;
        private string _type;
        private string _legalForm;
        private Address _address;

        public Estate(int id, string category, string type, string legalForm, Address address)
        {
            this._id = id;
            this._category = category;
            this._type = type;
            this._legalForm = legalForm;
            this._address = address;
        }

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
            }
        }

        public string Type {
            get { return _type; }
            set
            {
                _type = value;
            }
        }

        public string LegalForm {
            get { return _legalForm; }
            set
            {
                _legalForm = value;
            }
        }

        public Address Address {
            get { return _address; }
            set
            {
                _address = value;
            }
        }

        // override ToString to display customized information 
        public override string ToString()
        {
            string str = Type + ", " + Address.City + ", " + Address.Country;
            return str;
        }
    }
}
