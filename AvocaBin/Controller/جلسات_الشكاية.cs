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
using AvocaBin.Operation;
using AvocaBin.Models.cause;
using AvocaBin.Models;
using AvocaBin.Models.Plaintes;

namespace AvocaBin.Controller
{
    public partial class جلسات_الشكاية : Form
    {
        SqlConnection cn = connection.getConnection();
        PlaintesOperations po = new PlaintesOperations();
        DataSet ds = new DataSet();
        SqlDataAdapter ad;
        SqlCommand cmd;
        public جلسات_الشكاية()
        {
            InitializeComponent();
        }
        public void videz_champs()
        {
            txt_decision.Clear();
        }

        public void getdata()
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            cmd = new SqlCommand("select s.id_session as[مرجع الجلسة] ,s.id_plainte as[مرجع الشكاية],s.date_session as[تاريخ الجلسة],s.decision as[الاجراء] from session_plainte s order by s.date_session DESC", cn);
            ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "a");

            dataGridView1.DataSource = ds.Tables["a"];

            cn.Close();
        }
        public void getDataTable_plainte()
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            cmd = new SqlCommand("select id_plainte from session_plainte", cn);
            ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "sp");
            cb_id_plainte.DataSource = ds.Tables["sp"];
            cb_id_plainte.DisplayMember = "id_plainte";

            cn.Close();
        }
        private void btn_nouveau_Click(object sender, EventArgs e)
        {
            txt_decision.Clear();
            cb_id_plainte.Text = "";
        }

        private void btn_ajouter_Click(object sender, EventArgs e)
        {
            if (txt_decision.Text == "" || cb_id_plainte.Text == "")
            {
                MessageBoxManager.OK = "حسنا";
                MessageBoxManager.Register();
                DialogResult dr = MessageBox.Show("المرجو ملئ جميع الحقول", "تنبيه", MessageBoxButtons.OK);
                MessageBoxManager.Unregister();

            }
            else
            {
                try
                {

                    //cn.Open();
                    Session_Plainte se = new Session_Plainte();
                    se.Date_session = dateTimePicker1.Value;
                    se.Decision = txt_decision.Text;
                    se.Id_plainte = cb_id_plainte.Text;
                    po.add_session(se);
                    getdata();
                    history.AddHistory("الجلسات", "الاضافة", cb_id_plainte.Text);
                    //cn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void simpleButtonModification_Click(object sender, EventArgs e)
        {

            PlaintesOperations op = new PlaintesOperations();
            Session_Plainte p = new Session_Plainte();
            p.Id_plainte = cb_id_plainte.Text;
            p.Date_session = dateTimePicker1.Value;
            p.Decision = txt_decision.Text;
            p.Id_session = Convert.ToInt32(label4.Text);
            op.update_session(p);
            getdata();
            history.AddHistory("شكاية", "تعديل", p.Id_session.ToString());
        }

        private void simpleButtonSupprimer_Click(object sender, EventArgs e)
        {
            PlaintesOperations po = new PlaintesOperations();
            MessageBoxManager.Yes = "نعم";
            MessageBoxManager.No = "لا";
            MessageBoxManager.Register();
            DialogResult dr = MessageBox.Show("هل أنت متأكد من الحذف ؟؟", "تنبيه", MessageBoxButtons.YesNo);
            MessageBoxManager.Unregister();
            if (dr == DialogResult.Yes)
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                int id;
                id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                po.deleteSessionPlainte(id);
                getdata();
                //getDataTable();
                //ma.getDataTable();
                videz_champs();
                //textBox1.Clear();
                //history.AddHistory(" ادارة ", "الحدف" );
                cn.Close();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                //cb_id_plainte.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                //dateTimePicker1.Value = (DateTime)dataGridView1.SelectedRows[0].Cells[2].Value;
                //txt_decision.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString().Trim();
                label4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cb_id_plainte.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[2].Value;
                txt_decision.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            }
            else
            {

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
        private void جلسات_الشكاية_Load(object sender, EventArgs e)
        {
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Sultan Nahia", 12));
            getdata();
            getDataTable_plainte();
           
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
