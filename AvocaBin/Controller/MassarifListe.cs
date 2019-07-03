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


namespace AvocaBin.Controller
{
    public partial class MassarifListe : Form
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection cnx = connection.getConnection();
        SqlDataReader dr;


        public MassarifListe()
        {
            
            InitializeComponent();
            
        }
        private List<Control> GetAllControls(Control container, List<Control> list)
        {
            foreach (Control c in container.Controls)
            {

                if (c.Controls.Count > 0)
                    list = GetAllControls(c, list);
                else
                    list.Add(c);
            }

            return list;
        }
        private List<Control> GetAllControls(Control container)
        {
            return GetAllControls(container, new List<Control>());
        }
        private void MassarifListe_Load(object sender, EventArgs e)
        {
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Sultan Nahia", 12));
            try
            {
                if (cnx.State == ConnectionState.Closed) { cnx.Open(); }
                dataGridViewRecherche.Rows.Clear();
                cmd.CommandText = "SELECT DISTINCT p.id_paiement,c.id_cause,avance,date_paiement,total_paiement FROM  dbo.Paiement p , dbo.cause c where p.id_cause=c.id_cause";
                cmd.Connection = cnx;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridViewRecherche.Rows.Add(dr["id_paiement"].ToString(), dr["id_cause"].ToString(), dr["date_paiement"].ToString(), dr["total_paiement"].ToString(), dr["avance"].ToString());
                }
                dr.Close();
                dr.Dispose();
                cnx.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtRecherche.Text!="")
                {
                    dataGridViewRecherche.Rows.Clear();
                    if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                    cmd.CommandText = "select p.id_paiement,c.id_cause,avance,date_paiement,total_paiement from dbo.Paiement p , dbo.cause c where c.id_cause = '" + txtRecherche.Text + "'";
                    cmd.Connection = cnx;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dataGridViewRecherche.Rows.Add(dr["id_paiement"].ToString(), dr["id_cause"].ToString(), dr["date_paiement"].ToString(), dr["total_paiement"].ToString(), dr["avance"].ToString());
                    }
                    dr.Close();
                    cnx.Close();
                }
                if (txtRecherche.Text == "")
                {
                    dataGridViewRecherche.Rows.Clear();
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                    cmd.CommandText = "SELECT DISTINCT p.id_paiement,c.id_cause,avance,date_paiement,total_paiement FROM  dbo.Paiement p , dbo.cause c where p.id_cause=c.id_cause";
                    cmd.Connection = cnx;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dataGridViewRecherche.Rows.Add(dr["id_paiement"].ToString(), dr["id_cause"].ToString(), dr["date_paiement"].ToString(), dr["total_paiement"].ToString(), dr["avance"].ToString());
                    }
                    dr.Close();
                    cnx.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void معلوماتعناToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProposNous p = new ProposNous();
            p.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (dataGridViewRecherche.Rows.Count != 0)
            {
                PrintMassarifForm f = new PrintMassarifForm();
                f.idPaiement = (string)dataGridViewRecherche.CurrentRow.Cells[0].Value;
                f.Show();
            }
        }
        private void copyAlltoClipboar()
        {
            dataGridViewRecherche.RowHeadersVisible = false;
            dataGridViewRecherche.SelectAll();
            DataObject dataObj = dataGridViewRecherche.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            copyAlltoClipboar();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewRecherche.SelectedRows.Count !=0 )
                {
                    cmd.Parameters.Clear();
                    if (cnx.State == ConnectionState.Closed) { cnx.Open(); }
                    cmd.Connection = cnx;
                    cmd.CommandText = "delete Paiement where id_paiement like '"+(string)dataGridViewRecherche.SelectedRows[0].Cells[0].Value+"'";
                    cmd.ExecuteNonQuery();

                    dataGridViewRecherche.Rows.Clear();
                    cmd.CommandText = "SELECT DISTINCT p.id_paiement,c.id_cause,avance,date_paiement,total_paiement FROM  dbo.Paiement p , dbo.cause c where p.id_cause=c.id_cause";
                    cmd.Connection = cnx;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dataGridViewRecherche.Rows.Add(dr["id_paiement"].ToString(), dr["id_cause"].ToString(), dr["date_paiement"].ToString(), dr["total_paiement"].ToString(), dr["avance"].ToString());
                    }
                    dr.Close();
                    dr.Dispose();
                    cnx.Close();
                    cnx.Close();
                    MessageBox.Show("تم الحدف بنجاح");
                }
                else
                {
                    MessageBox.Show("الرجاء إعادة المحاولة");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int mouseX = 0;
        int mouseY = 0;
        bool mouseDown;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 400;
                mouseY = MousePosition.Y - 40;
                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
