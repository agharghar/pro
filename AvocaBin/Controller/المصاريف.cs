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
using AvocaBin.Models;

namespace AvocaBin.Controller
{
    public partial class المصاريف : Form
    {
        SqlConnection cnx = connection.getConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public المصاريف()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBoxManager.Yes = "نعم";
                MessageBoxManager.No = "لا";
                MessageBoxManager.Register();
                DialogResult dr = MessageBox.Show("هل أنت متأكد من الاضافة .. ؟؟", "تنبيه", MessageBoxButtons.YesNo);
                MessageBoxManager.Unregister();
                if (dr == DialogResult.Yes)
                {
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                
                    cmd.CommandText = "insert into Paiement values(" + txb_avance.Text + ",getdate() ," + comboBox1.SelectedItem + ")";
                    cmd.Connection = cnx;
                    cmd.ExecuteNonQuery();
                    MessageBoxManager.OK = "حسنا";
                    MessageBoxManager.Register();
                    DialogResult d = MessageBox.Show("لقد ثمث الاضافة ...  ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cnx.Close();
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void المصاريف_Load(object sender, EventArgs e)
        {
            txb_montant.Enabled = false;
            try
            {
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                
                cmd.CommandText = "select id_cause from cause";
                cmd.Connection = cnx;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr[0].ToString());
                }
                dr.Close();
                cnx.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                
                cmd.CommandText = "select total_paiement from cause where id_cause='" + comboBox1.SelectedItem.ToString() + "'";
                cmd.Connection = cnx;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txb_montant.Text = dr[0].ToString();
                }
                dr.Close();
                cnx.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && txb_montant.Text != "" && txb_avance.Text != "" && CmbType.Text != "")
            {
            double totalAvance, montantTotal;
            bool fini;
            SqlCommand cmd1 = new SqlCommand();
            MessageBoxManager.Yes = "نعم";
            MessageBoxManager.No = "لا";
            MessageBoxManager.Register();
            DialogResult dr = MessageBox.Show("هل أنت متأكد من الاضافة .. ؟؟", "تنبيه", MessageBoxButtons.YesNo);
            MessageBoxManager.Unregister();
            if (dr == DialogResult.Yes)
            {
                montantTotal = double.Parse(txb_montant.Text);
                SqlDataReader dr1;

                cmd1.Connection = cnx;

                //check if payement is fully paid
                cmd1.CommandText = "select paeiment_fini from cause where id_cause = @id";
                cmd1.Parameters.Add("@id", comboBox1.SelectedItem);
                if (cnx.State == ConnectionState.Closed) { cnx.Open(); }
                dr1 = cmd1.ExecuteReader();
                dr1.Read();
                fini = (bool)dr1[0];
                cmd1.Parameters.RemoveAt("@id");
                cmd1.Dispose();
                dr1.Close();
                dr1.Dispose();
                if (fini == false)
                {
                    //paiment has not been finished
                    //get total avance of a cause
                    cmd1.CommandText = "select SUM(avance) from Paiement where id_cause = @id";
                    cmd1.Parameters.Add("@id", comboBox1.SelectedItem);
                    dr1 = cmd1.ExecuteReader();
                    dr1.Read();
                    if (dr1[0] != DBNull.Value)
                        totalAvance = (double)dr1[0];
                    else
                        totalAvance = 0;
                    cmd1.Parameters.RemoveAt("@id");
                    cmd1.Dispose();
                    dr1.Close();
                    dr1.Dispose();
                    if (totalAvance <= montantTotal)
                    {
                        cmd1.CommandText = "insert into Paiement values(" + txb_avance.Text + ",getdate() ,'" + comboBox1.SelectedItem + "' , '"+CmbType.Text+"')";
                        cmd1.ExecuteNonQuery();
                        MessageBoxManager.OK = "حسنا";
                        MessageBoxManager.Register();
                        DialogResult d = MessageBox.Show("لقد ثمث الاضافة ...  ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBoxManager.Unregister();
                        if (montantTotal == totalAvance + double.Parse(txb_avance.Text))
                        {
                            cmd1.CommandText = "update cause set paeiment_fini = 'True' where id_cause = @i";
                            cmd1.Parameters.Add("@i", comboBox1.SelectedItem);
                            cmd1.ExecuteNonQuery();
                            history.AddHistory(" المصاريف", "الاضافة", comboBox1.Text);
                        }
                    }
                }
                else
                {
                    //paiment is finished
                    MessageBox.Show("الاداء ثم بنجاح ");
                }
                cnx.Close();
                comboBox1.Text = "";
                txb_montant.Clear();
                txb_avance.Clear();
                CmbType.Text = "";
            }
            else
            {
                this.Close();
            }
            }
            else
	{
        MessageBox.Show("يجب ملئ الخانات");
	}
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                
                cmd.CommandText = "select total_paiement from cause where id_cause='" + comboBox1.SelectedItem.ToString() + "'";
                cmd.Connection = cnx;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txb_montant.Text = dr[0].ToString();
                }
                dr.Close();
                cnx.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void معاينةالمصاريفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MassarifListe m = new MassarifListe();
            m.ShowDialog();
        }
        
        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            //mouseDown = true;
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void menuStrip1_MouseUp(object sender, MouseEventArgs e)
        {
            //mouseDown = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

