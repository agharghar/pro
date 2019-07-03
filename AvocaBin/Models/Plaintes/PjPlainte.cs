using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace AvocaBin.Models.Plaintes
{
    class PjPlainte
    {
        private int id_pj;

        public int Id_pj
        {
            get { return id_pj; }
            set { id_pj = value; }
        }
        private byte[] photo;

        public byte[] Photo
        {
            get { return photo; }
            set { photo = value; }
        }
        private String titre;

        public String Titre
        {
            get { return titre; }
            set { titre = value; }
        }
        private DateTime date_enregistrement;

        public DateTime Date_enregistrement
        {
            get { return date_enregistrement; }
            set { date_enregistrement = value; }
        }
        private String id_plainte;

        public String Id_plainte
        {
            get { return id_plainte; }
            set { id_plainte = value; }
        }
    }
}
