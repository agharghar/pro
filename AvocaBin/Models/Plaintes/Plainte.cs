using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AvocaBin.Models.Plaintes
{
    class Plainte
    {
        private String idPlainte;
        private string etat;
        private string num_archive;

        public string Num_archive
        {
            get { return num_archive; }
            set { num_archive = value; }
        }

        public string Etat
        {
            get { return etat; }
            set { etat = value; }
        }

        public String IdPlainte
        {
            get { return idPlainte; }
            set { idPlainte = value; }
        }
        private DateTime dateDepotPlainte;
        public DateTime DateDepotPlainte
        {
            get { return dateDepotPlainte; }
            set { dateDepotPlainte = value; }
        }
        private DateTime dateCreation;

        public DateTime DateCreation
        {
            get { return dateCreation; }
            set { dateCreation = value; }
        }
        
        private String signePlainte;

        public String SignePlainte
        {
            get { return signePlainte; }
            set { signePlainte = value; }
        }
        private int idPlaignant;

        public int IdPlaignant
        {
            get { return idPlaignant; }
            set { idPlaignant = value; }
        }
        private String ville;

        public String Ville
        {
            get { return ville; }
            set { ville = value; }
        }
        private String typeTribunal;

        public String TypeTribunal
        {
            get { return typeTribunal; }
            set { typeTribunal = value; }
        }

        public String typePlaint;
        public String TypePlaint
        {
            get { return typePlaint; }
            set { typePlaint = value; }
        }

        public Plainte()
        {
        }



    }
}
