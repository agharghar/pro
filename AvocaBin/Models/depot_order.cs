using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AvocaBin.Models;

namespace AvocaBin.Models
{
    
     class depot_order
    {
        
            private int id_depot;

            public int Id_depot
            {
                get { return id_depot; }
                set { id_depot = value; }
            }
            private string id_order;

            public string Id_order
            {
                get { return id_order; }
                set { id_order = value; }
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

