using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvocaBin.Models.cause
{
    class PJ_cause
    {
        private int id_pj_cause;
        private Byte[] photo;
        private string titre;
        private DateTime date_enregistrement;
        private string id_cause;

    

        public byte[] Photo
        {
            get
            {
                return photo;
            }

            set
            {
                photo = value;
            }
        }

        public string Titre
        {
            get
            {
                return titre;
            }

            set
            {
                titre = value;
            }
        }

        public DateTime Date_enregistrement
        {
            get
            {
                return date_enregistrement;
            }

            set
            {
                date_enregistrement = value;
            }
        }

        public string Id_cause
        {
            get
            {
                return id_cause;
            }

            set
            {
                id_cause = value;
            }
        }

        public int Id_pj_cause
        {
            get
            {
                return id_pj_cause;
            }

            set
            {
                id_pj_cause = value;
            }
        }
    }
}
