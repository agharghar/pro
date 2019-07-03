using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvocaBin.Models.Plaintes
{
    class Par_plaignant
    {
        private int idParPlaignant;

        public int IdParPlaignant
        {
            get { return idParPlaignant; }
            set { idParPlaignant = value; }
        }
        private String typeParPlaignant;

        public String TypeParPlaignant
        {
            get { return typeParPlaignant; }
            set { typeParPlaignant = value; }
        }
        private String cin;

        public String Cin
        {
            get { return cin; }
            set { cin = value; }
        }
        private String nom;

        public String Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        private String telephone;

      
        private String representantLegal;

        public String RepresentantLegal
        {
            get { return representantLegal; }
            set { representantLegal = value; }
        }
        private String RegistreDeCommerce;

        public String RegistreDeCommerce1
        {
            get { return RegistreDeCommerce; }
            set { RegistreDeCommerce = value; }
        }
        private String adresse;

        public String Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }

        public override string ToString()
        {
            return nom;
        }
       

    }
}
