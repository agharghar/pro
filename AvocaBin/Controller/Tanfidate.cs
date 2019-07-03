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
    public partial class Tanfidate : Form
    {
        SqlConnection cn = connection.getConnection();
        SqlDataAdapter da;
        SqlDataAdapter da1;
        DataSet ds = new DataSet();
        SqlCommand cmd;
        SqlCommand cmd1;
         SqlCommand cmd2;
        public Tanfidate()
        {
            InitializeComponent();
        }
        public void clear() 
        {
            textBox1.Clear();
            textBox2.Clear();
            //textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
           // t.Items.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox2.Enabled = false;
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
        }
        public void getda_info(int id_client,int id_adv,string type)
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                if (type == "الموضوع")
                {
                    cmd = new SqlCommand("select nom from client_cause where id_client_cause=" + id_client, cn);
                    textBox4.Text = (string)cmd.ExecuteScalar();
                    cmd = new SqlCommand("select nom_adv from adversaire_cause where id_adversaire_cause=" + id_adv, cn);
                    textBox5.Text=(string)cmd.ExecuteScalar();
                }
                if (type == "الامر")
                {
                    cmd1 = new SqlCommand("select nom from client_order where id_client_order=" + id_client, cn);
                    textBox4.Text = (string)cmd1.ExecuteScalar();
                    cmd1 = new SqlCommand("select nom from adv_order where id_adv_order=" + id_adv, cn);
                    textBox5.Text=(string)cmd1.ExecuteScalar();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }

        }
        public void getdatacause()
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                comboBox2.Items.Clear();
                clear();
                cmd = new SqlCommand("select idCause from notification where typeFile like '%موضوع' and idCause not in(select idCause from tanfid)", cn);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "id_cause");
                cn.Close();
                for (int i = 0; i < ds.Tables["id_cause"].Rows.Count; i++)
                {
                    
                            comboBox2.Items.Add(ds.Tables["id_cause"].Rows[i][0].ToString()); 
                }
                ds.Tables["id_cause"].Rows.Clear();
                comboBox2.Text = "";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                
            }
          
        }
        public void getdata_order()
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                clear();
                comboBox2.Items.Clear();
                cmd = new SqlCommand("select idCause from notification where typeFile like '%امر' and idCause not in(select idCause from tanfid)", cn);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "id_order");

                cn.Close();
                for (int i = 0; i < ds.Tables["id_order"].Rows.Count; i++)
                {
                   
                            comboBox2.Items.Add(ds.Tables["id_order"].Rows[i][0].ToString());
                }
                ds.Tables["id_order"].Rows.Clear();
                comboBox2.Text = "";
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }

        }
        public void getdata_plainte()
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                clear();
                comboBox2.Items.Clear();
                cmd = new SqlCommand("select idCause from notification where typeFile like '%شكاية' and idCause not in(select idCause from tanfid)", cn);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "id_plainte");

                cn.Close();
                for (int i = 0; i < ds.Tables["id_plainte"].Rows.Count; i++)
                {
                
                            comboBox2.Items.Add(ds.Tables["id_plainte"].Rows[i][0].ToString());
                }
                ds.Tables["id_plainte"].Rows.Clear();
                comboBox2.Text = "";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }

        }
        public void getdata_tribunal()
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                comboBox3.Items.Clear();
                cmd = new SqlCommand("select tribunal from tribunal", cn);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "tribunal");
                cn.Close();
                for (int i = 0; i < ds.Tables["tribunal"].Rows.Count; i++)
                {
                    comboBox3.Items.Add(ds.Tables["tribunal"].Rows[i][0].ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
            ds.Tables["tribunal"].Clear();

        }
        
        public void getdata_ville()
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                comboBox5.Items.Clear();
                cmd = new SqlCommand("select ville from ville", cn);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "ville");
                cn.Close();
                 for (int i = 0; i < ds.Tables["ville"].Rows.Count; i++)
			    {
			         comboBox5.Items.Add(ds.Tables["ville"].Rows[i][0].ToString());
			    }
                 ds.Tables["ville"].Clear();
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }

        }
        public void getdatatable() 
        {
            dataGridView1.Rows.Clear();
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            cmd = new SqlCommand("select t.nomClient as[الموكل], t.idCause as[رقم القضية],n.typeCause as[نوعها],t.tribunal as[المحكمة],t.ville as [المدينة],t.num_notif as[رقم التبليغ],t.num_tanfid as[رقم التنفيد],t.nomAdv as[المنفد عليه],t.date_tanfide as[تاريخ التنفيد],t.type_tanfid as[نوع التنفيد],t.commisaireJudiciaire as[المفوض القضائي],t.note as[الملاحظة] from tanfid t,notification n where t.num_notif=n.id", cn);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "table");
            //ds.Tables["table"].Rows.Clear();
           // dataGridView1.DataSource = ds.Tables["table"];

            for (int i = 0; i < ds.Tables["table"].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(ds.Tables["table"].Rows[i][0].ToString(), ds.Tables["table"].Rows[i][1].ToString(), ds.Tables["table"].Rows[i][2].ToString(), ds.Tables["table"].Rows[i][3].ToString(), ds.Tables["table"].Rows[i][4].ToString(), ds.Tables["table"].Rows[i][5].ToString(), ds.Tables["table"].Rows[i][6].ToString(), ds.Tables["table"].Rows[i][7].ToString(),DateTime.Parse( ds.Tables["table"].Rows[i][8].ToString()).ToShortDateString(), ds.Tables["table"].Rows[i][9].ToString(), ds.Tables["table"].Rows[i][10].ToString(), ds.Tables["table"].Rows[i][11].ToString());
            }
            ds.Tables["table"].Rows.Clear();

            
        }
        public void search(string text) {

            if (text=="")
            {
                dataGridView1.Rows.Clear();
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                cmd = new SqlCommand("select t.nomClient as[الموكل], t.idCause as[رقم القضية],n.typeCause as[نوعها],t.tribunal as[المحكمة],t.ville as [المدينة],t.num_notif as[رقم التبليغ],t.num_tanfid as[رقم التنفيد],t.nomAdv as[المنفد عليه],t.date_tanfide as[تاريخ التنفيد],t.type_tanfid as[نوع التنفيد],t.commisaireJudiciaire as[المفوض القضائي],t.note as[الملاحظة] from tanfid t,notification n where t.num_notif=n.id", cn);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "table");
                //ds.Tables["table"].Rows.Clear();
                // dataGridView1.DataSource = ds.Tables["table"];

                for (int i = 0; i < ds.Tables["table"].Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(ds.Tables["table"].Rows[i][0].ToString(), ds.Tables["table"].Rows[i][1].ToString(), ds.Tables["table"].Rows[i][2].ToString(), ds.Tables["table"].Rows[i][3].ToString(), ds.Tables["table"].Rows[i][4].ToString(), ds.Tables["table"].Rows[i][5].ToString(), ds.Tables["table"].Rows[i][6].ToString(), ds.Tables["table"].Rows[i][7].ToString(), DateTime.Parse(ds.Tables["table"].Rows[i][8].ToString()).ToShortDateString(), ds.Tables["table"].Rows[i][9].ToString(), ds.Tables["table"].Rows[i][10].ToString(), ds.Tables["table"].Rows[i][11].ToString());
                }
                ds.Tables["table"].Rows.Clear();

            }
            else
            {
                dataGridView1.Rows.Clear();
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                cmd = new SqlCommand("select t.nomClient as[الموكل], t.idCause as[رقم القضية],n.typeCause as[نوعها],t.tribunal as[المحكمة],t.ville as [المدينة],t.num_notif as[رقم التبليغ],t.num_tanfid as[رقم التنفيد],t.nomAdv as[المنفد عليه],t.date_tanfide as[تاريخ التنفيد],t.type_tanfid as[نوع التنفيد],t.commisaireJudiciaire as[المفوض القضائي],t.note as[الملاحظة] from tanfid t,notification n where t.num_notif=n.id and (t.nomClient like '%" + text + "%' or t.idCause like '%" + text + "%' or t.num_tanfid like '%" + text + "%')", cn);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "table");
                for (int i = 0; i < ds.Tables["table"].Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(ds.Tables["table"].Rows[i][0].ToString(), ds.Tables["table"].Rows[i][1].ToString(), ds.Tables["table"].Rows[i][2].ToString(), ds.Tables["table"].Rows[i][3].ToString(), ds.Tables["table"].Rows[i][4].ToString(), ds.Tables["table"].Rows[i][5].ToString(), ds.Tables["table"].Rows[i][6].ToString(), ds.Tables["table"].Rows[i][7].ToString(), DateTime.Parse(ds.Tables["table"].Rows[i][8].ToString()).ToShortDateString(), ds.Tables["table"].Rows[i][9].ToString(), ds.Tables["table"].Rows[i][10].ToString(), ds.Tables["table"].Rows[i][11].ToString());
                }
                ds.Tables["table"].Rows.Clear();
                
            }
        
        
        }
        private void Tanfidate_Load(object sender, EventArgs e)
        {
            getdata_tribunal();
            getdata_ville();
            getdatatable();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "الموضوع")
            {
                getdatacause();
                comboBox2.Enabled = true;
            }
            
            if (comboBox1.Text == "الامر")
            {
                getdata_order();
                comboBox2.Enabled = true;
            }
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
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id_adv;
                int id_client;
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                cmd = new SqlCommand("select * from notification where idCause='" + comboBox2.Text + "'", cn);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "info");
                cn.Close();
                //MessageBox.Show(ds.Tables["info"].Rows.Count.ToString());
                textBox1.Text=ds.Tables["info"].Rows[0][0].ToString();
                textBox2.Text = ds.Tables["info"].Rows[0][3].ToString();
                dateTimePicker1.Text = ds.Tables["info"].Rows[0][5].ToString();
                textBox6.Text = ds.Tables["info"].Rows[0][11].ToString();
                id_client = int.Parse(ds.Tables["info"].Rows[0][6].ToString());
                if (comboBox1.Text == "الشكاية")
                {
                    id_adv = 0;
                }
                else
                {
                     id_adv = int.Parse(ds.Tables["info"].Rows[0][7].ToString());
                }
                getda_info(id_client, id_adv, comboBox1.Text);
                ds.Tables["info"].Clear();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            tribunalAjouter frm = new tribunalAjouter();
            frm.ShowDialog();
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            VilleAjoute frm = new VilleAjoute();
            frm.ShowDialog();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            getdata_tribunal();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            getdata_ville();
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
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            clear();
            simpleButton1.Enabled = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                if (comboBox1.Text == "" || comboBox3.Text == "" || comboBox5.Text == "" || comboBox2.Text == ""|| textBox9.Text=="")
                {
                    MessageBox.Show("المرجو ملا الحقول");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("insert into tanfid(num_tanfid,idCause,tribunal,ville,num_notif,numDecision,date_tanfide,type_tanfid,commisaireJudiciaire,note,nomClient,nomAdv,typeCause)values('" + textBox9.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox5.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker2.Value.ToShortDateString() + "','" + textBox10.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox11.Text + "')", cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تمت الاضافة بنجاح");
                    simpleButton1.Enabled = false;
                    getdatatable();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
           // getdata_adv();
        }

        private void XtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            getdatatable();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count>0)
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                cmd = new SqlCommand("select t.idCause,t.num_tanfid,t.date_tanfide,t.type_tanfid,t.tribunal,t.typeCause,t.ville,t.note from tanfid t where t.num_tanfid='" + dataGridView1.SelectedRows[0].Cells[6].Value.ToString() + "'", cn);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "up");
                Update_tanfid ut = new Update_tanfid(dataGridView1.SelectedRows[0].Cells[6].Value.ToString());
                ut.textBox1.Text = ds.Tables["up"].Rows[0][0].ToString();
                ut.textBox9.Text = ds.Tables["up"].Rows[0][1].ToString();
                ut.textBox10.Text = ds.Tables["up"].Rows[0][3].ToString();
                ut.textBox11.Text = ds.Tables["up"].Rows[0][5].ToString();
                ut.textBox7.Text = ds.Tables["up"].Rows[0][7].ToString();
                //ut.textBox3.Text = "";
                ut.dateTimePicker2.Text = ds.Tables["up"].Rows[0][2].ToString();
                ut.comboBox3.Text = ds.Tables["up"].Rows[0][4].ToString();
                ut.comboBox5.Text = ds.Tables["up"].Rows[0][6].ToString();
                ds.Tables["up"].Rows.Clear();
                ut.ShowDialog();
            }
            else
            {
                MessageBox.Show("المرجو تحديد الحقل");
            }
        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                cmd = new SqlCommand("delete from tanfid where num_tanfid='" + dataGridView1.SelectedRows[0].Cells[6].Value.ToString() + "'", cn);
                cmd.ExecuteNonQuery();
                getdatatable();
            }
        }

        private void xtraTabPage2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            search(textBox8.Text);
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            if (dataGridView1.Rows.Count>0)
            {
                string numTanfid = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                string numNot = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                cmd = new SqlCommand("select typeFile from notification where id='" + numNot + "'", cn);
                string typeFile = (string)cmd.ExecuteScalar();
                cn.Close();
                PrintOneTanfid pt = new PrintOneTanfid(typeFile, numTanfid);
                pt.Show();
            }
            else
            {
                MessageBox.Show("الجدول فارغ");
            }
            

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            string text = textBox8.Text;
            PrintAllTanfid o = new PrintAllTanfid(text);
            o.Show();
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            
        }

        private void label17_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
