using System;

namespace Assignment1
{

    // Class describing a Estate object with type of townhouse
    // Inherits from BuildingResidental class

    [Serializable]
    public class Townhouse : BuildingResidential
    {
        private string _hasFirePlace;

        public Townhouse(int id, string category, string type, string legalForm, Address address, string hasFirePlace) 
            : base(id, category, type, legalForm, address)
        {
            this._hasFirePlace = hasFirePlace;
        }

        public string HasFirePlace
        {
            get { return _hasFirePlace; }
            set
            {
                _hasFirePlace = value;
            }
        }

        public override string ToString()
        {
            string str = "ID: " + Id + " \n" + Category +
                " \n" + Type + " \n" + LegalForm +
                " \nHas fireplace: " + HasFirePlace + " \n" + Address.ToString();

            return str;
        }
    }
}
