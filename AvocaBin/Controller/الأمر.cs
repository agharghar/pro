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
using System.IO;
using AvocaBin.Models;

namespace AvocaBin
{
    public partial class الأمر : DevExpress.XtraEditors.XtraForm
    {
        adv_order advOrd = new adv_order();
        client_order clientOrd = new client_order();
        order ord = new order();
        PjOrder pjOrder = new PjOrder();
        int u = 0;
        OpenFileDialog of = new OpenFileDialog();

        public الأمر()
        {
            InitializeComponent();
        }
        public string txb_num_orderValue
        {
            get { return txb_num_order.Text; }
            set { txb_num_order.Text = value; }
        }
        public string combobox1Value
        {
            get { return (string)comboBox1.SelectedItem; }
            set { comboBox1.SelectedItem = value; }
        }
        public string cb_genre_trubinalValue
        {
            get { return (string)cb_genre_trubinal.SelectedItem; }
            set { cb_genre_trubinal.SelectedItem = value; }
        }
        public string signeOrderValue
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public string cbVilleValue
        {
            get { return (string)cb_ville.SelectedItem; }
            set { cb_ville.SelectedItem = value; }
        }
        public string txtMofawadValue
        {
            get { return txb_mofawed.Text; }
            set { txb_mofawed.Text = value; }
        }
        public string decisionValue
        {
            get { return txb_disesion.Text; }
            set { txb_disesion.Text = value; }
        }
        public string cbGenreClientValue
        {
            get { return (string)cb_genre_client.SelectedItem; }
            set { cb_genre_client.SelectedItem = value; }
        }
        public string txbCinClientValue
        {
            get { return txb_cin_clie.Text; }
            set { txb_cin_clie.Text = value; }
        }
        public string txbNomClientValue
        {
            get { return txb_name_clie.Text; }
            set { txb_name_clie.Text = value; }
        }
        public string txbJuridiqueValue
        {
            get { return txb_juridique.Text; }
            set { txb_juridique.Text = value; }
        }
        public string txbTelValue
        {
            get { return txb_tele.Text; }
            set { txb_tele.Text = value; }
        }
        public string txbNumSocieteValue
        {
            get { return txb_num_societe.Text; }
            set { txb_num_societe.Text = value; }
        }
        public string txbAdresseClientValue
        {
            get { return txb_adresse.Text; }
            set { txb_adresse.Text = value; }
        }
        public string txbGenreAdvValue
        {
            get { return (string)cb_genre_adv.SelectedItem; }
            set { cb_genre_adv.SelectedItem = value; }
        }
        public string txbIdAdvValue
        {
            get { return txb_ide_adv.Text; }
            set { txb_ide_adv.Text = value; }
        }
        public string txbNameAdvValue
        {
            get { return txb_name_adv.Text; }
            set { txb_name_adv.Text = value; }
        }
        public string txbCinAdvValue
        {
            get { return txb_cin_adv.Text; }
            set { txb_cin_adv.Text = value; }
        }
        public string txbNumSocieteAdvValue
        {
            get { return txb_num_sosiete.Text; }
            set { txb_num_sosiete.Text = value; }
        }
        public string txbJuridiqueAdvValue
        {
            get { return txb_juridique_adv.Text; }
            set { txb_juridique_adv.Text = value; }
        }
        public string txbAdresseAdvValue
        {
            get { return txb_adresse_adv.Text; }
            set { txb_adresse_adv.Text = value; }
        }
        public bool showEditButton { get; set; }
        public string idclient
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        private void btn_ajouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "" || txb_ide_adv.Text == "" || comboBox1.Text=="")
                {
                    MessageBox.Show("المرجو إعادة ملئ البيانات");
                }
                else
                {
                //order setup
                ord.id_order = txb_num_order.Text;
                ord.type = (string)comboBox1.SelectedItem;
                ord.type_tribuna = (string)cb_genre_trubinal.SelectedValue;
                ord.signe_order = textBox1.Text;
                ord.id_ville = (string)cb_ville.SelectedValue;
                ord.commissaire_judicaire = txb_mofawed.Text;
                ord.decision = txb_disesion.Text;
                ord.date_order = DateTime.Parse(DateTime.Now.ToShortDateString());
                
                    ord.id_client_order = int.Parse(textBox2.Text.ToString());
                    ord.id_adversaire_order = int.Parse(txb_ide_adv.Text.ToString());
                    ord.save();
                

                //save PJ setup
                if (u == 1)
                {
                    foreach (string fileName in of.FileNames)
                    {
                        try
                        {
                            FileInfo fi = new FileInfo(fileName);
                            PjOrder pjOrder1 = new PjOrder();
                            byte[] img = null;
                            FileStream f = new FileStream(of.FileName, FileMode.Open);
                            BinaryReader br = new BinaryReader(f);
                            img = br.ReadBytes((int)f.Length);
                            f.Close();
                            pjOrder1.photo = img;
                            pjOrder1.titre = Path.GetFileName(of.FileName);
                            pjOrder1.date_enregistrement = DateTime.Now.ToShortDateString();
                            pjOrder1.id_order = ord.id_order;
                            pjOrder1.save();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                        }
                    }
                    u = 0;
                }
                history.AddHistory("الأمر", "إضافة", ord.id_order);
                MessageBox.Show("تمت الإضافة بنجاح");
                btn_ajouter.Enabled = false;
                }
            }
            catch (Exception nn)
            {
                MessageBox.Show("المرجو إعادة ملئ البيانات"+nn.Message);
            }
        }

        private void الأمر_Load(object sender, EventArgs e)
        {

            //vScrollBar1.Maximum = 100;
            //vScrollBar1.Minimum = -100;
            //vScrollBar1.Value = 0;

            if (showEditButton == true) { simpleButton3.Show(); btn_ajouter.Hide(); }
            else
                simpleButton3.Hide();
            SqlConnection cn = connection.getConnection();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            SqlDataReader dr, dr1;
            string query;

            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;

            cmd.CommandText = "select * from client_order";
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            dr.Dispose();
            dt.Dispose();

            cmd.CommandText = "select * from adv_order";
            dr1 = cmd.ExecuteReader();
            dt1.Load(dr1);
            dataGridView2.DataSource = dt1;
            dr1.Dispose();
            dt1.Dispose();

            query = "select * from ville";
            SqlDataAdapter da = new SqlDataAdapter(query, cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "ville");
            cb_ville.DisplayMember = "ville";
            cb_ville.ValueMember = "ville";
            cb_ville.DataSource = ds.Tables["ville"];

            query = "select * from tribunal";
            SqlDataAdapter da1 = new SqlDataAdapter(query, cn);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "tribunal");
            cb_genre_trubinal.DisplayMember = "tribunal";
            cb_genre_trubinal.ValueMember = "tribunal";
            cb_genre_trubinal.DataSource = ds1.Tables["tribunal"];

            cn.Close();

            cb_ville.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_genre_trubinal.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_genre_client.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_genre_adv.DropDownStyle = ComboBoxStyle.DropDownList;
            txb_adresse.ReadOnly = true;
            txb_adresse_adv.ReadOnly = true;
            txb_cin_adv.ReadOnly = true;
            txb_cin_clie.ReadOnly = true;
            txb_ide_adv.ReadOnly = true;
            txb_juridique.ReadOnly = true;
            txb_juridique_adv.ReadOnly = true;
            txb_name_adv.ReadOnly = true;
            txb_name_clie.ReadOnly = true;
            txb_num_societe.ReadOnly = true;
            txb_num_sosiete.ReadOnly = true;
            txb_tele.ReadOnly = true;
        }

        private void telecharger_piece_Click(object sender, EventArgs e)
        {
            of.Filter = "Images (*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG)|*.BMP;*.JPG;*.PNG;*.JPEG;*.GIF|" + "All files (*.*)|*.*";
            of.Title = "تحميل الصور :";
            of.Multiselect = true;
            if (of.ShowDialog() == DialogResult.OK)
            {
                u = 1;
            }
        }

        private void btn_nouveau_Click(object sender, EventArgs e)
        {
            الجلسات f1 = new الجلسات();
            f1.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ادارة_موكلي_الامر f1 = new ادارة_موكلي_الامر();
            f1.ShowDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ادارة_خصوم_الامر f2 = new ادارة_خصوم_الامر();
            f2.ShowDialog();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txb_ide_adv.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            cb_genre_adv.SelectedItem = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txb_cin_adv.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txb_name_adv.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            txb_juridique_adv.Text= dataGridView2.CurrentRow.Cells[4].Value.ToString();
            txb_num_sosiete.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            txb_adresse_adv.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cb_genre_client.SelectedItem = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txb_cin_clie.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txb_name_clie.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txb_tele.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txb_juridique.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txb_num_societe.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txb_adresse.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void btn_nouveau_Click_1(object sender, EventArgs e)
        {
            cb_genre_client.SelectedIndex = -1;
            txb_cin_clie.Clear();
            txb_name_clie.Clear();
            txb_juridique.Clear();
            txb_tele.Clear();
            txb_num_societe.Clear();
            txb_adresse.Clear();
            cb_genre_adv.SelectedIndex = -1;
            txb_ide_adv.Clear();
            txb_name_adv.Clear();
            txb_cin_adv.Clear();
            txb_num_sosiete.Clear();
            txb_juridique_adv.Clear();
            txb_adresse_adv.Clear();
            txb_num_order.Clear();
            cb_ville.SelectedIndex = -1;
            comboBox1.SelectedIndex = -1;
            txb_mofawed.Clear();
            cb_genre_trubinal.SelectedIndex = -1;
            textBox1.Clear();
            txb_disesion.Clear();
            btn_ajouter.Enabled = true;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                order ord = new order();
                ord.id_order = txb_num_order.Text;
                ord.signe_order = textBox1.Text;
                ord.commissaire_judicaire = txb_mofawed.Text;
                ord.id_ville = (string)cb_ville.SelectedValue;
                ord.type_tribuna = (string)cb_genre_trubinal.SelectedValue;
                ord.id_client_order = int.Parse(textBox2.Text);
                ord.id_adversaire_order = int.Parse(txb_ide_adv.Text);
                ord.decision = txb_disesion.Text;
                ord.type = (string)comboBox1.SelectedItem;
                ord.update();
                history.AddHistory("الأمر", "تحديث", txb_num_order.Text);
                MessageBox.Show("تم تحديث الملومات");
            }
            catch (Exception ee)
            {
                MessageBox.Show("المرجو إعادة ملئ البيانات");
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            SqlConnection cn = connection.getConnection();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            SqlDataReader dr;

            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "select * from client_order";
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            dr.Dispose();
            dt.Dispose();
            cn.Close();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            SqlConnection cn = connection.getConnection();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            SqlDataReader dr;

            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;

            cmd.CommandText = "select * from adv_order";
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView2.DataSource = dt;
            dr.Dispose();
            dt.Dispose();
            cn.Close();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            VilleAjoute v = new VilleAjoute();
            v.Show();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            SqlConnection cn = connection.getConnection();
            string query = "select * from ville";
            SqlDataAdapter da = new SqlDataAdapter(query, cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "ville");
            cb_ville.DisplayMember = "ville";
            cb_ville.ValueMember = "ville";
            cb_ville.DataSource = ds.Tables["ville"];
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            tribunalAjouter t = new tribunalAjouter();
            t.Show();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            SqlConnection cn = connection.getConnection();
            string query = "select * from tribunal";
            SqlDataAdapter da1 = new SqlDataAdapter(query, cn);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "tribunal");
            cb_genre_trubinal.DisplayMember = "tribunal";
            cb_genre_trubinal.ValueMember = "tribunal";
            cb_genre_trubinal.DataSource = ds1.Tables["tribunal"];
        }

        private void simpleButton10_Click(object sender, EventArgs e)
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

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}