using System;

namespace Assignment1
{

    // Class describing a Estate object with type of house
    // Inherits from BuildingResidental class

    [Serializable]
    public class House : BuildingResidential
    {
        private string _nbrOfBalconys;

        public House(int id, string category, string type, string legalForm, Address address, string nbrOfBalconys) 
            : base(id, category, type, legalForm, address)
        {
            this._nbrOfBalconys = nbrOfBalconys;
        }
        
        public string NbrOfBalconys
        {
            get { return _nbrOfBalconys; }
            set
            {
                _nbrOfBalconys = value;
            }
        }

        public override string ToString()
        {
            string str = "ID: " + Id + " \n" + Category +
                " \n" + Type + " \n" + LegalForm +
                " \nNbr of balconys: " + NbrOfBalconys + " \n" + Address.ToString();

            return str;
        }
    }
}
