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
using System.Data.SqlClient;

namespace AvocaBin
{
    public partial class دليل_الهاتف : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection cnx = connection.getConnection();
        public دليل_الهاتف()
        {
            InitializeComponent();
        }

        private void دليل_الهاتف_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
        }


        public void search()
        {
            if (textBoxRechercheContact.Text == "" && radioButtonAutre.Checked == true)
            {
                dataGridView1.Rows.Clear();
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnx;
                cmd.CommandText = "select nom,telephone from contact";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString());
                }
                dr.Close();
                cnx.Close();
            }
            else
            {
                if (textBoxRechercheContact.Text != "" && radioButtonAutre.Checked == true)
                {
                    dataGridView1.Rows.Clear();
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnx;
                    cmd.CommandText = "select nom,telephone from contact where nom like '" + textBoxRechercheContact.Text + "%'";
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString());
                    }
                    dr.Close();
                    cnx.Close();

                }
                else
                {
                    if (textBoxRechercheContact.Text == "" && radioButtonClient.Checked == true)
                    {
                        dataGridView1.Rows.Clear();
                                if (cnx.State == ConnectionState.Closed)
                                {
                                cnx.Open();
                                 }
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = cnx;
                            cmd.CommandText = "select nom,telephone from client_cause";
                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString());
                            }
                            dr.Close();
                            cnx.Close();
                    }
                    else
                    {
                        if (textBoxRechercheContact.Text != "" && radioButtonClient.Checked == true)
                        {
                            dataGridView1.Rows.Clear();
                              if (cnx.State == ConnectionState.Closed)
                                {
                                cnx.Open();
                                 }
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = cnx;
                            cmd.CommandText = "select nom,telephone from client_cause where nom like '" + textBoxRechercheContact.Text + "%'";
                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString());
                            }
                            dr.Close();
                            cnx.Close();
                        }
                    }
                }
            }

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxNomContact.Text!= "" && textBoxTel.Text!="")
                {


                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnx;
                    cmd.CommandText = "insert into contact values('" + textBoxNomContact.Text + "','" + textBoxTel.Text + "')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("الاضافة ثمث بنجاح", "الاضافة", MessageBoxButtons.OK);
                    textBoxNomContact.Clear();
                    textBoxTel.Clear();
                    cnx.Close();
                }
                else
                {
                    MessageBox.Show("المرجو ملئ المعلومات");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void radioButtonAutre_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonAutre.Checked == true)
                {
                    dataGridView1.Rows.Clear();
                    simpleButtonAjouter.Visible = true;
                    simpleButtonModification.Visible = true;
                    simpleButtonSupprimer.Visible = true;
                    pictureBox1.Visible = false;
                    textBoxNomContact.Visible = true;
                    textBoxTel.Visible = true;
                    separatorControl2.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true; 
                    dropDownButton2.Visible = true;
                    dropDownButton3.Visible = true;
                    if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnx;
                    cmd.CommandText = "select nom,telephone from contact";
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString());
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

        private void radioButtonClient_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonClient.Checked == true)
                {
                    dataGridView1.Rows.Clear();
                    simpleButtonAjouter.Visible = false;
                    simpleButtonModification.Visible = false;
                    simpleButtonSupprimer.Visible = false;
                    textBoxNomContact.Visible = false;
                    textBoxTel.Visible = false;
                    separatorControl2.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    pictureBox1.Visible = true;
                    dropDownButton2.Visible = false;
                    dropDownButton3.Visible = false;
                    if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnx;
                    cmd.CommandText = "select nom,telephone from client_cause";
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString());
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

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count>0)
            {
                textBoxNomContact.Text=dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBoxTel.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
            else
            {
                MessageBox.Show("المرجو تحديد المعلومات");
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            try
            {
                if ( radioButtonClient.Checked==true)
                {
                    dataGridView1.Rows.Clear();
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnx;
                    cmd.CommandText = "select nom,telephone from client_cause";
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString());
                    }
                    dr.Close();
                    cnx.Close();

                }
                if(radioButtonAutre.Checked==true )
                {
                    dataGridView1.Rows.Clear();
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnx;
                    cmd.CommandText = "select nom,telephone from contact";
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString());
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

        private void dropDownButton1_Click(object sender, EventArgs e)
        {
            textBoxRechercheContact.Clear();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxNomContact.Text != "")
                {
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnx;
                    cmd.CommandText = "delete from contact where nom='" + textBoxNomContact.Text + "' and telephone='" + textBoxTel.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("ثم الحدف بنجاح ", "الحدف", MessageBoxButtons.OK);
                    textBoxNomContact.Clear();
                    textBoxTel.Clear();
                    cnx.Close();
                }
                else
                {
                    MessageBox.Show("المرجو اختيار الحقل المراد حدفه");
                }

                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButtonModification_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count>0)
                {


                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnx;
                    cmd.CommandText = "update contact set nom='" + textBoxNomContact.Text + "' , telephone='" + textBoxTel.Text + "' where nom='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "' and telephone='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("ثم التعديل بنجاح ", "التعديل", MessageBoxButtons.OK);
                    textBoxNomContact.Clear();
                    textBoxTel.Clear();
                    cnx.Close();
                }
                else
                {
                    MessageBox.Show("المرجو اختيار الحقل المراد تعديله");
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxRechercheContact_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void dropDownButton2_Click(object sender, EventArgs e)
        {
            textBoxNomContact.Clear();
        }

        private void dropDownButton3_Click(object sender, EventArgs e)
        {
            textBoxTel.Clear();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}