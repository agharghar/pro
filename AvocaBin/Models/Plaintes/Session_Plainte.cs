using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvocaBin.Models.Plaintes
{
    class Session_Plainte
    {
        private int id_session;

        public int Id_session
        {
            get { return id_session; }
            set { id_session = value; }
        }
        private DateTime date_session;
        private string id_plainte;
        private string decision;


        public DateTime Date_session
        {
            get
            {
                return date_session;
            }

            set
            {
                date_session = value;
            }
        }

        public string Id_plainte
        {
            get
            {
                return id_plainte;
            }

            set
            {
                id_plainte = value;
            }
        }

        public string Decision
        {
            get
            {
                return decision;
            }

            set
            {
                decision = value;
            }
        }
    }
}
