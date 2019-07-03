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
    public partial class Tablirat : Form
    {
        public Tablirat()
        {
            InitializeComponent();
        }

        private void refresh()
        {
            SqlConnection cn = connection.getConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            DataTable dt = new System.Data.DataTable();
            cmd.CommandText = "select * from notification ";
            cmd.Connection = cn;
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            dr.Dispose();
            cn.Close();
        }

        private void TanfiD_Load(object sender, EventArgs e)
        {
            SqlConnection cn = connection.getConnection();
            string query;
            query = "select * from tribunal";
            SqlDataAdapter da = new SqlDataAdapter(query, cn);
            DataSet ds = new System.Data.DataSet();
            da.Fill(ds, "tribunal");
            comboBox3.DataSource = ds.Tables["tribunal"];
            comboBox3.DisplayMember = "tribunal";
            comboBox3.ValueMember = "tribunal";

            query = "select * from ville";
            SqlDataAdapter da1 = new SqlDataAdapter(query, cn);
            DataSet ds1 = new System.Data.DataSet();
            da1.Fill(ds1, "ville");
            comboBox5.DataSource = ds1.Tables["ville"];
            comboBox5.DisplayMember = "ville";
            comboBox5.ValueMember = "ville";

            refresh();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            SqlConnection cn = connection.getConnection();
            string query;
            switch ((string)comboBox1.Text)
            {
                case "أمر":
                    query = "select id_order from orderr";
                    SqlDataAdapter da = new SqlDataAdapter(query, cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "orderr");
                    comboBox2.DataSource = ds.Tables["orderr"];
                    comboBox2.DisplayMember = "id_order";
                    comboBox2.ValueMember = "id_order";
                    break;
                case "موضوع":
                    query = "select id_cause from cause";
                    SqlDataAdapter da1 = new SqlDataAdapter(query, cn);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1, "cause");
                    comboBox2.DataSource = ds1.Tables["cause"];
                    comboBox2.ValueMember = "id_cause";
                    comboBox2.DisplayMember = "id_cause";
                    break;
                default:
                    break;
            }
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            string idFile = comboBox2.SelectedValue.ToString();
            SqlConnection cn = connection.getConnection();
            switch (comboBox1.Text)
            {
                case "أمر":
                    {
                        SqlCommand cmd = new SqlCommand();
                        SqlDataReader dr;
                        cmd.CommandText = "select distinct o.id_order,cl.nom,ad.nom,o.commissaire_judiciaire,o.type from orderr o,client_order cl,adv_order ad where o.id_client_order=cl.id_client_order and o.id_adversaire_order=ad.id_adv_order and o.id_order=@id";
                        cmd.Parameters.Add("@id", idFile);
                        cmd.Connection = cn;
                        if (cn.State == ConnectionState.Closed) { cn.Open(); }
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        textBox4.Text = dr[1].ToString();
                        textBox5.Text = dr[2].ToString();
                        textBox6.Text = dr[3].ToString();
                        textBox9.Text = dr[4].ToString();
                        dr.Close(); dr.Dispose(); cn.Close();
                        cmd.Parameters.Clear();

                        break;
                    }

                case "موضوع":
                    {
                        SqlCommand cmd = new SqlCommand();
                        SqlDataReader dr;
                        cmd.CommandText = "select c.id_cause,cl.nom,ad.nom_adv,c.commisaire_judiciaire,c.type_cause from cause c,client_cause cl,adversaire_cause ad where c.id_client=cl.id_client_cause and c.id_adv=ad.id_adversaire_cause and c.id_cause=@id";
                        cmd.Parameters.Add("@id", idFile);
                        cmd.Connection = cn;
                        if (cn.State == ConnectionState.Closed) { cn.Open(); }
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        textBox4.Text = dr[1].ToString();
                        textBox5.Text = dr[2].ToString();
                        textBox6.Text = dr[3].ToString();
                        textBox9.Text = dr[4].ToString();
                        dr.Close(); dr.Dispose(); cn.Close();
                        cmd.Parameters.Clear();
                        break;
                    }
                default:
                    break;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //try
            //{
                notification n = new notification();
                n.id = textBox1.Text;
                n.idCause = (string)comboBox2.SelectedValue;
                n.date = dateTimePicker1.Value;
                n.numdecision = textBox2.Text;
                n.decisionFinal = textBox3.Text;
                n.dateDecision = dateTimePicker2.Value;
                n.idClient = textBox4.Text;
                n.idAdv = "";
                n.tribunal = comboBox3.SelectedValue.ToString();
                n.typeCause = textBox9.Text;
                n.ville = comboBox5.SelectedValue.ToString();
                n.commisaireJudiciaire = textBox6.Text;
                n.note = textBox7.Text;
                n.typeFile = comboBox1.SelectedItem.ToString();
                string t = n.save();
                if (t != "")
                {
                    MessageBox.Show("تمت الإضافة بنجاح");
                    history.AddHistory("تبليغ", "إضافة", t);
                }
                refresh();
            //}
            //catch (Exception nn)
            //{
            //    MessageBox.Show("المرجو إعادة ملئ البيانات" + nn.Message);
            //}
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text != "")
            {
                string word = textBox8.Text;
                List<notification> l = new List<notification>();
                l = notification.find(word);
                dataGridView1.DataSource = l;
            }
            else
            {
                refresh();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("please select a row to delete");
            }
            else
            {
                string word = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                MessageBoxManager.Yes = "نعم";
                MessageBoxManager.No = "لا";
                MessageBoxManager.Register();
                DialogResult dr = MessageBox.Show("هل أنت متأكد من الحدف ؟", "تنبيه", MessageBoxButtons.YesNo);
                MessageBoxManager.Unregister();
                if (dr == DialogResult.Yes)
                {
                    notification.delete(word);
                    history.AddHistory("تبليغ", "حذف", word);
                    refresh();
                }
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                dateTimePicker1.Value = (DateTime)dataGridView1.SelectedRows[0].Cells[2].Value;
                dateTimePicker2.Value = (DateTime)dataGridView1.SelectedRows[0].Cells[5].Value;
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                textBox9.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                textBox7.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                comboBox1.SelectedItem = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
                comboBox3.SelectedItem = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                comboBox5.SelectedItem = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                comboBox2.SelectedItem = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                simpleButton7.Visible = true;
                xtraTabPage1.Show();
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            try
            {
                notification n = notification.findById(textBox1.Text);
                n.idCause = comboBox2.SelectedItem.ToString();
                n.typeFile = comboBox1.SelectedItem.ToString();
                n.date = dateTimePicker1.Value;
                n.numdecision = textBox2.Text;
                n.decisionFinal = textBox3.Text;
                n.dateDecision = dateTimePicker2.Value;
                n.idClient = textBox4.Text;
                n.idAdv = textBox5.Text;
                n.tribunal = comboBox3.SelectedItem.ToString();
                n.typeCause = textBox9.Text;
                n.ville = comboBox5.SelectedItem.ToString();
                n.commisaireJudiciaire = textBox6.Text;
                n.note = textBox7.Text;
                n.update();
                simpleButton7.Visible = false;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox9.Text = "";
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox5.SelectedIndex = -1;
                refresh();
                MessageBox.Show("تمت التعديل بنجاح");
            }
            catch (Exception ee)
            {
                MessageBox.Show("   المرجو إعادة ملئ البيانات" + ee.Message);
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            PrintAllNotificationsForm f = new PrintAllNotificationsForm();
            f.Show();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            PrintOneNotificationForm f = new PrintOneNotificationForm(); 
            f.id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            f.Show();
        }

        private void XtraTabControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
