using System;

namespace Assignment1
{

    // Class describing a Estate object with type of warehouse
    // Inherits from BuildingCommercial class

    [Serializable]
    public class Warehouse : BuildingCommercial
    {

        private string _nbrOfLoadingPorts;

        public Warehouse(int id, string category, string type, string legalForm, Address address, string nbrOfLoadingPorts)
            : base(id, category, type, legalForm, address)
        {
            this._nbrOfLoadingPorts = nbrOfLoadingPorts;
        }

        public string NbrOfLoadingPorts
        {
            get { return _nbrOfLoadingPorts; }
            set
            {
                _nbrOfLoadingPorts = value;
            }
        }

        public override string ToString()
        {
            string str = "ID: " + Id + " \n" + Category +
                " \n" + Type + " \n" + LegalForm +
                " \nNbr of loading ports: " + NbrOfLoadingPorts + " \n" + Address.ToString();

            return str;
        }
    }
}
