using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvocaBin.Models.Plaintes
{
    class depot_plaint
    {
        private int id_depot;

        public int Id_depot
        {
            get { return id_depot; }
            set { id_depot = value; }
        }
        private string id_plainte;

        public string Id_plainte
        {
            get { return id_plainte; }
            set { id_plainte = value; }
        }
        private string nom;

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        private string nom_adv;

        public string Nom_adv
        {
            get { return nom_adv; }
            set { nom_adv = value; }
        }
        private float montant;

        public float Montant
        {
            get { return montant; }
            set { montant = value; }
        }

        private string num_check;

        public string Num_check
        {
            get { return num_check; }
            set { num_check = value; }
        }
   
    }
}
