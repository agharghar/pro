using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvocaBin.Models
{
    class CoercitionPhysique
    {
        private int n_coercition_physique;

        public int N_coercition_physique
        {
            get { return n_coercition_physique; }
            set { n_coercition_physique = value; }
        }
        private string n_dossier;

        public string N_dossier
        {
            get { return n_dossier; }
            set { n_dossier = value; }
        }
        private string client;

        public string Client
        {
            get { return client; }
            set { client = value; }
        }
        private string type_cause;

        public string Type_cause
        {
            get { return type_cause; }
            set { type_cause = value; }
        }
        private string tribune;

        public string Tribune
        {
            get { return tribune; }
            set { tribune = value; }
        }
        private string ville;

        public string Ville
        {
            get { return ville; }
            set { ville = value; }
        }
        private string ndossier_implement;

        public string Ndossier_implement
        {
            get { return ndossier_implement; }
            set { ndossier_implement = value; }
        }
        private string intime;

        public string Intime
        {
            get { return intime; }
            set { intime = value; }
        }
        private string commissaire_juridique;

        public string Commissaire_juridique
        {
            get { return commissaire_juridique; }
            set { commissaire_juridique = value; }
        }
        private DateTime date_application;

        public DateTime Date_application
        {
            get { return date_application; }
            set { date_application = value; }
        }
    }
}
