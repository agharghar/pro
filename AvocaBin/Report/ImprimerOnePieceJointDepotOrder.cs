using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AvocaBin.Report
{
    public partial class ImprimerOnePieceJointDepotOrder : Form
    {
        SqlConnection cnx = connection.getConnection();
        SqlCommand CmdInfo = new SqlCommand();
        SqlCommand CmdPieceJointOrder = new SqlCommand();
        SqlDataAdapter da;
        SqlDataAdapter da1;
        DataSetPrintOnePieceDepot ds = new DataSetPrintOnePieceDepot();
        int id_PieceJointDepotOrder;
        public ImprimerOnePieceJointDepotOrder(int id_PieceJointDepotOrder)
        {
            this.id_PieceJointDepotOrder= id_PieceJointDepotOrder;
            InitializeComponent();
        }

        private void ImprimerOnePieceJointDepotOrder_Load(object sender, EventArgs e)
        {
            if (cnx.State == ConnectionState.Closed)
            {
                cnx.Open();
            }

            CmdPieceJointOrder.CommandText = "select [Num_Depot_piece],[Num_File],[Titre],[Image_depot_piece] from Depot_piece where Num_Depot_piece=" + id_PieceJointDepotOrder + "";
            CmdPieceJointOrder.Connection = cnx;
            da = new SqlDataAdapter(CmdPieceJointOrder);
            da.Fill(ds, "Depot_piece");


            CmdInfo = new SqlCommand("select top(1) * from avocat", cnx);
            da1 = new SqlDataAdapter(CmdInfo);
            da1.Fill(ds, "avocat");


            ReportOnePlgntDepotPiece i = new ReportOnePlgntDepotPiece();
            i.SetDataSource(ds);
            crystalReportViewer1.ReportSource = i;
            cnx.Close();
        }
    }
}
