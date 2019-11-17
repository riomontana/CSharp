using System;

namespace Assignment1
{

    // Class describing a Estate object with type of villa
    // Inherits from BuildingResidental class

    [Serializable]
    public class Villa : BuildingResidential
    {

        private string _hasPool;

        public Villa(int id, string category, string type, string legalForm, Address address, string hasPool) 
            : base(id, category, type, legalForm, address)
        {
            this._hasPool = hasPool;
        }

        public string HasPool
        {
            get { return _hasPool; }
            set
            {
                _hasPool = value;
            }
        }

        public override string ToString()
        {
            string str = "ID: " + Id + " \n" + Category +
                " \n" + Type + " \n" + LegalForm +
                " \nHas pool: " + HasPool + " \n" + Address.ToString();

            return str;
        }
    }
}
