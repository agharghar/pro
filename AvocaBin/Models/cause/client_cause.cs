using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvocaBin.Models.cause
{
    class client_cause
    {

        public int Id_client_cause
        {
            get
            {

                return id_client_cause;

            }
            set
            {

                id_client_cause = value;

            }
        }
        public string Type_client
        {
            get
            {
                return type_client;
            }

            set
            {
                type_client = value;
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

        public string Telephone
        {
            get
            {
                return telephone;
            }

            set
            {
                telephone = value;
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

        private string type_client;

        private string cin;

        private string nom;

        private string telephone;

        private string adjoint;

        private string representant_legal;

        private string registre_commerce;

        private string adresse;

        private int id_client_cause;





    }
}
