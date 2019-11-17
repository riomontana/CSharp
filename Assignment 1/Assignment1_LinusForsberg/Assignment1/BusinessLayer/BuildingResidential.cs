using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{

    // Class describing a residential building
    // inherits from abstract class Estate

    [Serializable]
    public class BuildingResidential : Estate
    {

        public BuildingResidential(int id, string category, string type, string legalForm, Address address)
            : base(id, category, type, legalForm, address)
        {
        }
    }
}
