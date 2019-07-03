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
using AvocaBin.Operation;
using AvocaBin.Models.cause;
using AvocaBin.Controller;
using System.IO;
using AvocaBin.Models;
using System.Reflection;

namespace AvocaBin
{
    public partial class الموضوع : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection cn = connection.getConnection();
        DataSet ds = new DataSet();
        Cause_Operations co;
        SqlDataReader dr;
        client_cause cc;
        OpenFileDialog of;
        public delegate void DoEvent();
        public event DoEvent abc;
        جدول_القضايا ja = new جدول_القضايا();
        string path;
        int u;
        public void getDataTable()
        {
            co = new Cause_Operations();
            dataGridView1.Rows.Clear();

            List<client_cause> pps = co.getAllClients_cause();
            foreach (client_cause pp in pps)
            {
                try
                {
                    dataGridView1.Rows.Add(pp.Id_client_cause,pp.Nom, pp.Type_client, pp.Cin, pp.Representant_legal, pp.Registre_commerce, pp.Telephone, pp.Adresse);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void getville()
        {
            if (cn.State==ConnectionState.Closed)
            {
                cn.Open();
            }
            
            co = new Cause_Operations();
            comboBoxVilleCause.Items.Clear();

            List<string> pps = co.getAllville();
            foreach(string values in pps )
            {
                try
                {
                    comboBoxVilleCause.Items.Add(values.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            comboBoxVilleCause.Refresh();
            cn.Close();
        }

        public void gettribunal()
        {
            co = new Cause_Operations();
            comboBoxTypeTribunal.Items.Clear();

            List<string> pps = co.gettribunal();
            for (int i = 0; i < pps.Count; i++)
            {
                try
                {
                    comboBoxTypeTribunal.Items.Add(pps[i].Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void getDataTable1()
        {
            co = new Cause_Operations();
            dataGridView2.Rows.Clear();

            List<adversaire_cause> pps = co.getAllAdversaire_cause();
            foreach (adversaire_cause pp in pps)
            {
                try
                {
                    dataGridView2.Rows.Add(pp.Id_adv_cause,pp.Nom,pp.Adjoint, pp.Type_adversaire, pp.Cin, pp.Representant_legal, pp.Registre_commerce, pp.Adresse);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void vider_les_champ()
        {
            textBoxAdresseAdv.Clear();
            textBoxAdresseClient.Clear();
            textBoxCauseProfMoukalaf.Clear();
            textBoxCINAdv.Clear();
            textBoxCINClient.Clear();
            textBoxMoumatilQanouniAdv.Clear();
            textBoxMoumatilQanouniClient.Clear();
            textBoxNomAdv.Clear();
            textBoxNomClient.Clear();
            textBoxSijilTijariAdv.Clear();
            textBoxSijilTijariClient.Clear();
            textBoxTelClient.Clear();
            textBoxTypeAdver.Clear();
            textBoxTypeClient.Clear();
            txtMarjiaCause1.Clear();
            txtNumCause.Clear();
            txt_avocat_adversaire.Clear();
            txt_commisaire_judiciaire.Clear();
            txt_juge.Clear();
            txt_signe_cause.Clear();
            txt_type_cause.Clear();
            txt_duree.Value = 0;
            txt_montant.Clear();
        }
        public void getDataTable2()
        {
            co = new Cause_Operations();
            dataGridView1.Rows.Clear();

            List<client_cause> pps = co.searchclient_cause(txt_search_client.Text);
            foreach (client_cause pp in pps)
            {
                try
                {
                    dataGridView1.Rows.Add(pp.Id_client_cause,pp.Nom, pp.Type_client, pp.Cin, pp.Representant_legal, pp.Registre_commerce, pp.Telephone, pp.Adresse);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void getDataTable3()
        {
            co = new Cause_Operations();
            dataGridView2.Rows.Clear();

            List<adversaire_cause> pps = co.searchAdversaire_cause(txt_search_adv.Text);
            foreach (adversaire_cause pp in pps)
            {
                try
                {
                    dataGridView2.Rows.Add(pp.Id_adv_cause,pp.Nom, pp.Adjoint, pp.Type_adversaire, pp.Cin, pp.Representant_legal, pp.Registre_commerce,  pp.Adresse);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public الموضوع()
        {
            of = new OpenFileDialog();
            InitializeComponent();

        }
        public الموضوع(الموضوع ma)
        {

            InitializeComponent();

        }



        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        
        
        private void الموضوع_Load(object sender, EventArgs e)
        {

            //this.TopMost = false;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;

            //vScrollBar1.Maximum = 100;
            //vScrollBar1.Minimum = -100;
            //vScrollBar1.Value = 0;
            cb_porsuit.Text = "عادية";
            getDataTable();
            getDataTable1();
            getville();
            gettribunal();
            
            
        }

        

        public void RemoveText(object sender, EventArgs e)
        {
            txtMarjiaCause1.Text = "";
        }

        public void AddText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtMarjiaCause1.Text))
                txtMarjiaCause1.Text = "Enter text here...";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void rbtn_ibtida_CheckedChanged(object sender, EventArgs e)
        {
        }


        private void simpleButtonNouveauCause_Click(object sender, EventArgs e)
        {
            vider_les_champ();
        }

        private void comboBoxTypeClient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxTypeAdv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {
                ادارة_الموكلين a = new ادارة_الموكلين(this);
            a.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxNumClient_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxVilleCause_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxVilleCause.Refresh();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxTypeClient.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBoxCINClient.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBoxNomClient.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBoxTelClient.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBoxMoumatilQanouniClient.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBoxSijilTijariClient.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBoxAdresseClient.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ادارة_الخصوم a = new ادارة_الخصوم(this);
            a.ShowDialog();
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxTypeAdver.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
            txt_adjoint.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            textBoxCINAdv.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
            textBoxNomAdv.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            textBoxMoumatilQanouniAdv.Text = dataGridView2.SelectedRows[0].Cells[5].Value.ToString();
            textBoxSijilTijariAdv.Text = dataGridView2.SelectedRows[0].Cells[6].Value.ToString();
            textBoxAdresseAdv.Text = dataGridView2.SelectedRows[0].Cells[7].Value.ToString();


        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            VilleAjoute frm = new VilleAjoute();
           
            frm.ShowDialog();
        }
        private void textBoxDecision_TextChanged(object sender, EventArgs e)
        {

        }
        public bool IsNumeric(string Nombre)
        {
            try
            {
                int.Parse(Nombre);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void simpleButtonAjouterCause_Click(object sender, EventArgs e)
        {
            bool x = IsNumeric(txt_duree.Text);
            co = new Cause_Operations();
            if (txtMarjiaCause1.Text == "" || comboBoxTypeTribunal.Text == "" || comboBoxVilleCause.Text == "" || textBoxNomClient.Text == "" || textBoxNomAdv.Text=="")
            {
                MessageBoxManager.OK = "حسنا";
                MessageBoxManager.Register();
                DialogResult dr = MessageBox.Show("يجب ادخال المعلومات الضرورية", "", MessageBoxButtons.OK);
                MessageBoxManager.Unregister();
            }
            else
            {


                try
                {
                  //MessageBox.Show(  txt_duree.Value.ToString());
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                
                    cause ca = new cause();
                    Session se = new Session();
                    ca.Id_client = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    ca.Id_adv = int.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                    ca.Id_cause = txtMarjiaCause1.Text;
                    ca.Date_session = dateTimePickeDateCause.Value;
                    ca.Nom_avocat = textBoxCauseProfMoukalaf.Text;
                    ca.Signe_cause = txt_signe_cause.Text;
                    ca.Type_cause = txt_type_cause.Text;
                    ca.Juge = txt_juge.Text;
                    ca.Avocat_adversaire = txt_avocat_adversaire.Text;
                    ca.Type_tribunal = comboBoxTypeTribunal.Text;
                    ca.Ville = comboBoxVilleCause.Text;
                    ca.Num_cause_tribunal = txtNumCause.Text;
                    ca.Poursuite = cb_porsuit.Text;
                    ca.Commisaire_judiciaire = txt_commisaire_judiciaire.Text;
                    ca.Appel = cb_appel.Text;
                    ca.Duree = int.Parse(txt_duree.Text);


                    if (txt_montant.Text != "")
                    {
                        ca.Montant = float.Parse(txt_montant.Text);
                    }
                    else
                    {
                       
                    }
                    se.Date_session = dateTimePickeDateCause.Value;
                    se.Id_cause = txtMarjiaCause1.Text;
                    se.Decision = "اول جلسة";

                    co.add_cause(ca, se);


                    if (u == 1)
                    {
                        foreach (string fileName in of.FileNames)
                        {
                            try
                            {
                                FileInfo fi = new FileInfo(fileName);
                                PJ_cause pjCause = new PJ_cause();
                                byte[] img = null;
                                FileStream f = new FileStream(of.FileName, FileMode.Open);
                                BinaryReader br = new BinaryReader(f);
                                img = br.ReadBytes((int)f.Length);
                                f.Close();
                                pjCause.Id_cause = ca.Id_cause;
                                pjCause.Photo = img;

                                pjCause.Titre = Path.GetFileName(of.FileName);
                                pjCause.Date_enregistrement = dateTimePickeDateCause.Value;
                               // listBox1.Items.Add(pjCause.Titre);
                                co.add_piece_jointe_cause(pjCause);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                            }
                        }
                        u = 0;
                    }
                    history.AddHistory(" الموضوع", "الاضافة", txtMarjiaCause1.Text);
                    //
                    cn.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }


        }

        private void simpleButtonOuvrirPieceJoinCause_Click(object sender, EventArgs e)
        {
            of.Filter = "Images (*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG)|*.BMP;*.JPG;*.PNG;*.JPEG;*.GIF|" + "All files (*.*)|*.*";
            of.Title = "تحميل الصور :";
            of.Multiselect = true;
            if (of.ShowDialog() == DialogResult.OK)
            {
               // MessageBox.Show("تم تحميل الصورة");
                MessageBoxManager.OK = "حسنا";
                MessageBoxManager.Register();
                DialogResult dr = MessageBox.Show("تم تحميل صورة بنجاح", "", MessageBoxButtons.OK);
                MessageBoxManager.Unregister();
                u = 1;
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            tribunalAjouter frm = new tribunalAjouter();
           // frm.fm_Refresh_typeTribunal += new tribunalAjouter.DoEvent(fm_Refresh_typeTribunal);
            frm.ShowDialog();
        }

        private void edit_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                
                cause ca = new cause();
                Session se = new Session();
                ca.Id_client = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                ca.Id_adv = int.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                ca.Id_cause = txtMarjiaCause1.Text;
                ca.Date_session = dateTimePickeDateCause.Value;
                ca.Nom_avocat = textBoxCauseProfMoukalaf.Text;
                ca.Signe_cause = txt_signe_cause.Text;
                ca.Type_cause = txt_type_cause.Text;
                ca.Juge = txt_juge.Text;
                ca.Avocat_adversaire = txt_avocat_adversaire.Text;
                ca.Type_tribunal = comboBoxTypeTribunal.Text;
                ca.Ville = comboBoxVilleCause.Text;
                ca.Num_cause_tribunal = txtNumCause.Text;
                ca.Poursuite = cb_porsuit.Text;
                ca.Commisaire_judiciaire = txt_commisaire_judiciaire.Text;
                ca.Appel = cb_appel.Text;
                ca.Duree = (int)txt_duree.Value;
                co.updateCause(ca);
                this.abc();
                //this.fm_Refresh_gv();
                history.AddHistory(" الموضوع", "التعديل", txtMarjiaCause1.Text);
                this.Close();
                

                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_search_client_TextChanged(object sender, EventArgs e)
        {
            if (txt_search_client.Text=="")
            {
                getDataTable();
            }
            else
            {
                getDataTable2();
            }
        }

        private void txt_search_adv_TextChanged(object sender, EventArgs e)
        {
            if (txt_search_adv.Text == "")
            {
                getDataTable1();
            }
            else
            {
                getDataTable3();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //comboBoxVilleCause.Refresh();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            getville();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            gettribunal();
        }

        private void txt_duree_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (Char.IsControl(e.KeyChar) || !Char.IsNumber(e.KeyChar))
            //{
            //    e.Handled = true; // Set l'evenement comme etant completement fini
            //    return;
                
            //}
        }

        private void dropDownButton1_Click(object sender, EventArgs e)
        {
           // txt_duree.Clear();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
           
        }


        Color maincolor;
        private void simpleButtonNouveauCause_MouseHover(object sender, EventArgs e)
        {
            maincolor = simpleButtonNouveauCause.BackColor;
            simpleButtonNouveauCause.BackColor = Color.RosyBrown;

        }

        private void simpleButtonNouveauCause_MouseLeave(object sender, EventArgs e)
        {
            simpleButtonNouveauCause.BackColor = maincolor;
        }

        private void simpleButton7_Click_1(object sender, EventArgs e)
        {
            
        }

        private void dropDownButton2_Click(object sender, EventArgs e)
        {
            txt_search_client.Clear();
        }

        private void dropDownButton1_Click_1(object sender, EventArgs e)
        {
            txt_search_adv.Clear();
        }

        private void label18_Click(object sender, EventArgs e)
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
            //panel2.Location = new Point(0,vScrollBar1.Value);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
          //  panel2.Location = new Point(vScrollBar1.Value);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
            
            
            
    
