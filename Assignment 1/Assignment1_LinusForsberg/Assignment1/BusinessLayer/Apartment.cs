using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{

    // Class describing a Estate object with type of apartment
    // Inherits from BuildingResidental class

    [Serializable]
    public class Apartment : BuildingResidential
    {

        private string _nbrOfRooms;

        public Apartment(int id, string category, string type, string legalForm, Address address, string nbrOfRooms)
            : base(id, category, type, legalForm, address)
        {
            this._nbrOfRooms = nbrOfRooms;
        }

        public string NbrOfRooms
        {
            get { return _nbrOfRooms; }
            set
            {
                _nbrOfRooms = value;
            }
        }

        public override string ToString()
        {
            string str = "ID: " + Id + " \n" + Category +
                " \n" + Type + " \n" + LegalForm + 
                " \nNbr of rooms: " + NbrOfRooms + " \n" + Address.ToString();

            return str;
        }
    }
}
