using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
//using AvocaBin.Controller;
using AvocaBin.Operation;
using System.Data.SqlClient;
using AvocaBin.Models;
using System.Data;

namespace AvocaBin
{
    public partial class Tableau_Des_RDV : DevExpress.XtraEditors.XtraForm
    {

        SqlConnection cnx = connection.getConnection();
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        public Tableau_Des_RDV()
        {
            InitializeComponent();
        }

        
        private void simpleButton7_Click(object sender, EventArgs e)
        {
            if (txtBoxCinRDV.Text != "")
            {
                try
                {
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "update RDV set DateRDV='" + dateTimePickerDateRDV.Value + "', Nom='" + txtBoxNomRDV.Text + "', Cause='" + txtDescriptionRDV.Text + "' where CinRDV='" + txtBoxCinRDV.Text + "' ";
                    cmd.Connection = cnx;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("ثم التعديل بنجاح ", "التعديل", MessageBoxButtons.OK);
                    txtBoxCinRDV.Clear();
                    dateTimePickerDateRDV.Text = "";
                    txtBoxNomRDV.Clear();
                    txtDescriptionRDV.Clear();
                    history.AddHistory(" جدول المواعيد", "التعديل", txtBoxCinRDV.Text);
                    cnx.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("المرجوا اختيار الموعد المراد التعديل عليه");
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            if (txtBoxCinRDV.Text != "")
            {
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "delete from RDV where CinRDV='" + txtBoxCinRDV.Text + "'";
                cmd.Connection = cnx;
                cmd.ExecuteReader();
                MessageBox.Show("ثم الحدف بنجاح ", "الحدف", MessageBoxButtons.OK);
                txtBoxCinRDV.Clear();
                dateTimePickerDateRDV.Text = "";
                txtBoxNomRDV.Clear();
                txtDescriptionRDV.Clear();
                history.AddHistory(" جدول المواعيد", "الحدف", txtBoxCinRDV.Text);
                cnx.Close();
            }
            else
            {
                MessageBox.Show(" المرجوا اختيار الموعد المراد حدفه");
            }
        }
        public void getdata() {
            try
            {
              //  ds.Tables["RDV"].Clear();
                ds.Tables.Clear();
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select CinRDV as[ر.ب.و],Nom as[الاسم],DateRDV as[التاريخ],Cause as[سبب الزيارة] from RDV";
                cmd.Connection = cnx;
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "RDV");
                //SqlDataReader dr = cmd.ExecuteReader();
                dataGridView1.DataSource = ds.Tables["RDV"];
                //while (dr.Read())
                //{
                //    dataGridView1.Rows.Add(dr["CinRDV"].ToString(), dr["Nom"].ToString(), dr["DateRDV"].ToString(), dr["Cause"].ToString());
                //}
                //dr.Close();
                cnx.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
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
        private void Tableau_Des_RDV_Load(object sender, EventArgs e)
        {
           
            getdata();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            txtBoxCinRDV.Clear();
            dateTimePickerDateRDV.Text = "";
            txtBoxNomRDV.Clear();
            txtDescriptionRDV.Clear();
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
        private void txtDescriptionRDV_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (txtBoxCinRDV.Text != "")
            {
                try
                {
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }

                    SqlCommand cmd = new SqlCommand();
                    //cmd.CommandText = "insert into RDV(CinRDV,DateRDV,Nom,Cause) values(@cin,@date,@nom,@cause)";
                    cmd.CommandText = "insert into RDV values('" + txtBoxCinRDV.Text + "','" + dateTimePickerDateRDV.Value + "','" + txtBoxNomRDV.Text + "','" + txtDescriptionRDV.Text + "')";

                    cmd.Connection = cnx;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("الاضافة ثمث بنجاح ", "الاضافة", MessageBoxButtons.OK);
                    history.AddHistory(" جدول المواعيد", "الاضافة", txtBoxCinRDV.Text);
                    txtBoxCinRDV.Clear();
                    dateTimePickerDateRDV.Text = "";
                    txtBoxNomRDV.Clear();
                    txtDescriptionRDV.Clear();

                    cnx.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show(" المرجوا ادخال البيانات ");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnx;
                cmd.Parameters.AddWithValue("@date1",dateTimePickerDeRDV.Value.ToString());
                cmd.Parameters.AddWithValue("@date2",dateTimePickerARDV.Value.ToString() );
                cmd.CommandText = "select CinRDV as[ر.ب.و],Nom as[الاسم],DateRDV as[التاريخ],Cause as[سبب الزيارة] from RDV where DateRDV BETWEEN @date1 and @date2";
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
                cmd.Parameters.Clear();
                history.AddHistory(" جدول المواعيد", "البحث", txtBoxCinRDV.Text);
                cnx.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtBoxCinRDV.Text=dataGridView1.CurrentRow.Cells[0].Value.ToString();
            dateTimePickerDateRDV.Text=dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtBoxNomRDV.Text=dataGridView1.CurrentRow.Cells[1].Value.ToString();;
            txtDescriptionRDV.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            //try
            //{
                
            //    if (cnx.State == ConnectionState.Closed)
            //    {
            //        cnx.Open();
            //    }
            //    DataTable dt = new DataTable();
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.CommandText = "select * from RDV";
            //    cmd.Connection = cnx;
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    dt.Load(dr);
            //    dataGridView1.DataSource = dt;
            //    dr.Close();
            //    cnx.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            getdata();
            dateTimePickerARDV.Text = "";
            dateTimePickerDeRDV.Text = "";
        }

        private void txtNomRDV_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                if (txtNomRDV.Text=="")
                {
                  // dataGridView1.Rows.Clear();

                    
                   // SqlCommand cmd = new SqlCommand();
                   // cmd.CommandText = "select * from RDV";
                   // cmd.Connection = cnx;
                   // da.Fill(ds, "RDV");
                   // dataGridView1.DataSource = ds.Tables["RDV"];
                   // //SqlDataReader dr = cmd.ExecuteReader();
                   // //dataGridView1.Rows.Clear();
                   // //while (dr.Read())
                   // //{
                   // //    dataGridView1.Rows.Add(dr["CinRDV"].ToString(), dr["Nom"].ToString(), dr["DateRDV"].ToString(), dr["Cause"].ToString());
                   // //}
                   // //dr.Close();
                    ds.Tables["RDV"].Clear();
                        getdata();
                    
                }
                else
	            {
                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand();
                        SqlDataReader dr;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = cnx;
                        cmd.Parameters.AddWithValue("@nom", txtNomRDV.Text);
                        cmd.Parameters.AddWithValue("@cin", txtNomRDV.Text);
                        cmd.CommandText = "select CinRDV as[ر.ب.و],Nom as[الاسم],DateRDV as[التاريخ],Cause as[سبب الزيارة] from RDV where Nom=@nom or CinRDV=@cin";
                        dr = cmd.ExecuteReader();
                        dt.Load(dr);
                        dataGridView1.DataSource = dt;
                        dr.Close();
                        cmd.Parameters.Clear();
	            }
               
                cnx.Close();

        }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dropDownButton1_Click(object sender, EventArgs e)
        {
            txtNomRDV.Clear();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            copyAlltoClipboardTableau();
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
        private void copyAlltoClipboardTableau()
        {

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void simpleButton10_Click(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}