using System;

namespace Assignment1
{

    // Class describing a Estate object with type of shop
    // Inherits from BuildingCommercial class

    [Serializable]
    public class Shop : BuildingCommercial
    {

        private string _hasEscalator;

        public Shop(int id, string category, string type, string legalForm, Address address, string hasEscalator) 
            : base(id, category, type, legalForm, address)
        {
            this._hasEscalator = hasEscalator;
        }

        public string HasEscalator
        {
            get { return _hasEscalator; }
            set
            {
                _hasEscalator = value;
            }
        }

        public override string ToString()
        {
            string str = "ID: " + Id + " \n" + Category +
                " \n" + Type + " \n" + LegalForm +
                " \nHas escalator: " + HasEscalator + " \n" + Address.ToString();

            return str;
        }
    }
}
