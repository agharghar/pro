using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvocaBin.Models.cause
{
    class cause
    {
        private string id_cause;
        private DateTime date_creation;
        private DateTime date_session;
        private string etat;

        public string Etat
        {
            get { return etat; }
            set { etat = value; }
        }
        

public DateTime Date_session
{
  get { return date_session; }
  set { date_session = value; }
}private int id_client;
        private string nom_avocat;
        private string signe_cause;
        private string type_cause;
        private string juge;
        private string avocat_adversaire;
        private string type_tribunal;
        private int id_adv;
        private string poursuite;
        private string ville;
        private string num_cause_tribunal;
        private string commisaire_judiciaire;
        private string appel;
        private int duree;
        private float montant;

        public float Montant
        {
            get { return montant; }
            set { montant = value; }
        }

        public int Duree
        {
            get
            {
                return duree;
            }

            set
            {
                duree = value;
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

        public DateTime Date_creation
        {
            get
            {
                return date_creation;
            }

            set
            {
                date_creation = value;
            }
        }

        public int Id_client
        {
            get
            {
                return id_client;
            }

            set
            {
                id_client = value;
            }
        }

        public string Nom_avocat
        {
            get
            {
                return nom_avocat;
            }

            set
            {
                nom_avocat = value;
            }
        }

        public string Signe_cause
        {
            get
            {
                return signe_cause;
            }

            set
            {
                signe_cause = value;
            }
        }

        public string Type_cause
        {
            get
            {
                return type_cause;
            }

            set
            {
                type_cause = value;
            }
        }

        public string Juge
        {
            get
            {
                return juge;
            }

            set
            {
                juge = value;
            }
        }

        public string Avocat_adversaire
        {
            get
            {
                return avocat_adversaire;
            }

            set
            {
                avocat_adversaire = value;
            }
        }

        public int Id_adv
        {
            get
            {
                return id_adv;
            }

            set
            {
                id_adv = value;
            }
        }

        public string Poursuite
        {
            get
            {
                return poursuite;
            }

            set
            {
                poursuite = value;
            }
        }

        public string Ville
        {
            get
            {
                return ville;
            }

            set
            {
                ville = value;
            }
        }

        public string Num_cause_tribunal
        {
            get
            {
                return num_cause_tribunal;
            }

            set
            {
                num_cause_tribunal = value;
            }
        }

        public string Type_tribunal
        {
            get
            {
                return type_tribunal;
            }

            set
            {
                type_tribunal = value;
            }
        }

        public string Commisaire_judiciaire
        {
            get
            {
                return commisaire_judiciaire;
            }

            set
            {
                commisaire_judiciaire = value;
            }
        }

        public string Appel
        {
            get
            {
                return appel;
            }

            set
            {
                appel = value;
            }
        }
    }
}
