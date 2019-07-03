using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvocaBin.Models.cause
{
    class adversaire_cause
    {
        private int id_adv_cause;
        private string type_adversaire;
        private string cin;
        private string nom;
        private string representant_legal;
        private string registre_commerce;
        private string adresse;
        private string adjoint;


        public int Id_adv_cause
        {
            get { return id_adv_cause; }
            set { id_adv_cause = value; }
        }
        public string Type_adversaire
        {
            get
            {
                return type_adversaire;
            }

            set
            {
                type_adversaire = value;
            }
        }

        public string Cin
        {
            get
            {
                return cin;
            }

            set
            {
                cin = value;
            }
        }

        public string Representant_legal
        {
            get
            {
                return representant_legal;
            }

            set
            {
                representant_legal = value;
            }
        }

        public string Registre_commerce
        {
            get
            {
                return registre_commerce;
            }

            set
            {
                registre_commerce = value;
            }
        }

        public string Adresse
        {
            get
            {
                return adresse;
            }

            set
            {
                adresse = value;
            }
        }

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public string Adjoint
        {
            get
            {
                return adjoint;
            }

            set
            {
                adjoint = value;
            }
        }
    }
}
