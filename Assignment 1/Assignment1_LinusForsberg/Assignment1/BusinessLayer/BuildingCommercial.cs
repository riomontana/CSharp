using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{

    // Class describing a commercial building
    // inherits from abstract class Estate

    [Serializable]
    public class BuildingCommercial : Estate
    {
        public BuildingCommercial(int id, string category, string type, string legalForm, Address address)
            : base(id, category, type, legalForm, address)
        {

        }

    }
}
