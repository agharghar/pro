using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvocaBin.Models.Plaintes
{
    class Decision
    {
        String decision;

        public String Decision1
        {
            get { return decision; }
            set { decision = value; }
        }
        int iddes;

        public int Iddes
        {
            get { return iddes; }
            set { iddes = value; }
        }

        String id_plainte;

        public String Id_plainte
        {
            get { return id_plainte; }
            set { id_plainte = value; }
        }

        public override string ToString()
        {
            return decision;
        }
        
    }
}
