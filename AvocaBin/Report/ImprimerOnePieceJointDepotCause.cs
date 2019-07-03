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
using AvocaBin.Report;
namespace AvocaBin.Report
{
    public partial class ImprimerOnePieceJointDepotCause : Form
    {
        DataSetPrintOnePieceDepot dsOnePieceJoint = new DataSetPrintOnePieceDepot();
        SqlConnection cnx = connection.getConnection();
        SqlCommand cmdPieceJointCause = new SqlCommand();
        SqlCommand cmdInfoAvocat = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataAdapter da1 = new SqlDataAdapter();

        int id_PieceJointDepotCause;
        public ImprimerOnePieceJointDepotCause(int id_PieceJointDepotCause)
        {
            this.id_PieceJointDepotCause = id_PieceJointDepotCause;
            InitializeComponent();
        }

        private void ImprimerOnePieceJointDepotCause_Load(object sender, EventArgs e)
        {
            if (cnx.State==ConnectionState.Closed)
            {
                cnx.Open();
            }


            cmdPieceJointCause.CommandText = "select [Num_Depot_piece],[Num_File],[Titre],[Image_depot_piece] from Depot_piece where Num_Depot_piece=" + id_PieceJointDepotCause + "";
            cmdPieceJointCause.Connection = cnx;
            da = new SqlDataAdapter(cmdPieceJointCause);
            da.Fill(dsOnePieceJoint, "Depot_piece");


            cmdInfoAvocat = new SqlCommand("select top(1) * from avocat", cnx);
            da1 = new SqlDataAdapter(cmdInfoAvocat);
            da1.Fill(dsOnePieceJoint, "avocat");


            ReportOneCauseDepotPiece i = new ReportOneCauseDepotPiece();
            i.SetDataSource(dsOnePieceJoint);
            crystalReportViewerOneCause.ReportSource = i;
            cnx.Close();



        }
    }
}
