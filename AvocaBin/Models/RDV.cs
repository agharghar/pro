using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvocaBin.Models.RDV
{
      class  RDV
    {
        private string CinRDV;

        public string CinRDV1
        {
            get { return CinRDV; }
            set { CinRDV = value; }
        }

        private DateTime DateRDV;

        public DateTime DateRDV1
        {
            get { return DateRDV; }
            set { DateRDV = value; }
        }

        private string Nom;

        public string Nom1
        {
            get { return Nom; }
            set { Nom = value; }
        }

        private string Cause;

        public string Cause1
        {
            get { return Cause; }
            set { Cause = value; }
        }


        public RDV()
        {

        }
        



    }
}
