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
    public partial class ImprimerOnePieceJointDepotPlgnt : Form
    {
        DataSetPrintOnePieceDepot dsOnePieceJointPlgnt = new DataSetPrintOnePieceDepot();
        SqlConnection cnx = connection.getConnection();
        SqlCommand cmdPieceJointPlgnt = new SqlCommand();
        SqlCommand cmdInfoAvocat = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataAdapter da1 = new SqlDataAdapter();

        int id_PieceJointDepotPlgn;
        public ImprimerOnePieceJointDepotPlgnt(int id_PieceJointDepotPlgnt)
        {
            this.id_PieceJointDepotPlgn = id_PieceJointDepotPlgnt;
            InitializeComponent();
        }

        private void ImprimerOnePieceJointDepotPlgnt_Load(object sender, EventArgs e)
        {

            cmdPieceJointPlgnt.CommandText = "select [Num_Depot_piece],[Num_File],[Titre],[Image_depot_piece] from Depot_piece where Num_Depot_piece=" + id_PieceJointDepotPlgn.ToString();
            cmdPieceJointPlgnt.Connection = cnx;
            da = new SqlDataAdapter(cmdPieceJointPlgnt);
            da.Fill(dsOnePieceJointPlgnt, "Depot_piece");


            cmdInfoAvocat = new SqlCommand("select top(1) * from avocat", cnx);
            da1 = new SqlDataAdapter(cmdInfoAvocat);
            da1.Fill(dsOnePieceJointPlgnt, "avocat");


            ReportOnePlgntDepotPiece i = new ReportOnePlgntDepotPiece();
            i.SetDataSource(dsOnePieceJointPlgnt);
            crystalReportViewerPlgnt.ReportSource = i;
            crystalReportViewerPlgnt.Refresh();


        }
    }
}
