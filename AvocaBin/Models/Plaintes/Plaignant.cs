using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvocaBin.Models.Plaintes
{
    class Plaignant
    {
        private int idPlaignant;

        public int IdPlaignant
        {
            get { return idPlaignant; }
            set { idPlaignant = value; }
        }
        private String typePlaignant;

        public String TypePlaignant
        {
            get { return typePlaignant; }
            set { typePlaignant = value; }
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

        public String Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }
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


    }
}
