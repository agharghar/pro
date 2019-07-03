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
using AvocaBin.Models.Plaintes;
using AvocaBin.Operation;
using System.IO;
using System.Data.SqlClient;
using AvocaBin.Controller;
using AvocaBin.Models;
namespace AvocaBin
{
    public partial class شكاية : DevExpress.XtraEditors.XtraForm
    {

        PlaintesOperations op;
        SqlConnection cn = connection.getConnection();
        string path;
        int u = 0;
        OpenFileDialog of;
        String idplainte;
        List<Par_plaignant> listpar;

        public شكاية()
        {
            of = new OpenFileDialog();
            op = new PlaintesOperations();
           listpar = new List<Par_plaignant>();
            InitializeComponent();
        }
        public شكاية(String idplainte)
        {
            
            of = new OpenFileDialog();
            op = new PlaintesOperations();
            listpar = new List<Par_plaignant>();
             this.idplainte=idplainte;
            Plainte p = op.getPlanteById(this.idplainte).First();
            Plaignant plaignant = op.getPlaignantByCinAndId(p.IdPlaignant.ToString()).First();
            List<PlainteParPlaignant> ppp = op.getPlainteParPlaintes(p.IdPlainte);
           
            InitializeComponent();
           // dataGridParPlaignant.Rows.Clear();
            foreach (var pp in getParplaintes(ppp))
            {
                //dataGridParPlaignant.Rows.Add(pp.TypeParPlaignant, pp.IdParPlaignant, pp.Nom, pp.RegistreDeCommerce1, pp.Cin, pp.Adresse);
                listBox1.Items.Add(pp);
            }
            setDataListbox(p.IdPlainte);
            comboBoxTypeClient.Text = plaignant.TypePlaignant;
            textBoxNumClient.Text = plaignant.IdPlaignant.ToString();
            textBoxNomClient.Text = plaignant.Nom;
            textBoxCINClient.Text = plaignant.Cin;
            textBoxTelClient.Text = plaignant.Telephone;
            textBoxMoumatilQanouniClient.Text = plaignant.RepresentantLegal;
            textBoxSijilTijariClient.Text = plaignant.RegistreDeCommerce1;
            textBoxAdresseClient.Text = plaignant.Adresse;

            txb_num_pl.Text=p.IdPlainte;
            date_plai.Text=p.DateCreation.ToString();
            //p.Decision = txtdecision.Text;
           textBoxNumClient.Text=p.IdPlaignant.ToString();
            cb_ville.Text=p.Ville;
            txb_symbole.Text=p.SignePlainte;
            btn_tribunal.Text=p.TypeTribunal;
           txb_genre_pl.Text=p.TypePlaint;
        }

        private void btn_ajouter_Click(object sender, EventArgs e)
        {
            if (isvalidate())
            {
                PlaintesOperations op = new PlaintesOperations();
                Plainte p = new Plainte();
                p.IdPlainte = txb_num_pl.Text;
                p.DateCreation = date_plai.Value;
                //p.Decision = txtdecision.Text;
                p.IdPlaignant = int.Parse(textBoxNumClient.Text);
                p.Ville = cb_ville.Text ;
                p.SignePlainte = txb_symbole.Text;
                p.TypeTribunal = btn_tribunal.Text;
                p.TypePlaint = txb_genre_pl.Text;
                p.DateDepotPlainte = date_depot_plainte.Value;
                //Console.WriteLine("Test1: "+p.DateCreation+" "+p.TypeTribunal);
                // MessageBox.Show("Test1: " + p.DateCreation + " " + p.TypeTribunal);
                op.addPlainte(p);
                Decision d = new Decision();
                d.Decision1 = "فتح الملف";
                d.Id_plainte = p.IdPlainte;
       
                op.addDecisionPlainte(d);
                foreach (Par_plaignant item in listBox1.Items)
                {
                    PlainteParPlaignant ppp = new PlainteParPlaignant();
                    ppp.IdParPlaignant = item.IdParPlaignant;
                    ppp.IdPlainte = p.IdPlainte;
                    op.addPlainteParPlaignant(ppp);
                }
                
                //save PJ setup
                if (u == 1)
                {
                    foreach (string fileName in of.FileNames)
                    {
                        try
                        {
                            FileInfo fi = new FileInfo(fileName);
                            PjPlainte pjplaint = new PjPlainte();
                            byte[] img = null;
                            FileStream f = new FileStream(of.FileName, FileMode.Open);
                            BinaryReader br = new BinaryReader(f);
                            img = br.ReadBytes((int)f.Length);
                            f.Close();
                            pjplaint.Id_plainte = p.IdPlainte;
                            pjplaint.Photo = img;

                            pjplaint.Titre = Path.GetFileName(of.FileName);
                            pjplaint.Date_enregistrement = date_plai.Value;
                            //  pjOrder1.id_order = ord.id_order;
                            op.addPjPalainte(pjplaint);
                            history.AddHistory("شكاية", "اضافة", txb_num_pl.Text);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                        }
                    }
                    u = 0;
                }
                btn_ajouter.Enabled = false;

            }
            else
            {
                MessageBox.Show("أحد الحقول فارغة أو المعلومات خاطئة");
            }




        }
        
        private void شكاية_Load(object sender, EventArgs e)
        {
            //this.TopMost = false;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            if (!isvalidate())
            {
                //btnadddecision.Enabled = false;
            }
            if (idplainte!=null)
            {
                btn_ajouter.Enabled = false;
                btn_nouveau.Enabled = false;
            }

            getDataTablePlaignant();
            getDataTableParPlaignant();

           cb_ville.DataSource = getVilles().Tables["ville"];
           cb_ville.DisplayMember = "ville";
           btn_tribunal.DataSource = GetData_type_tribunal().Tables["tribunal"];
           btn_tribunal.DisplayMember = "tribunal";


            comboBoxTypeClient.Items.Add("طبيعي");
            comboBoxTypeClient.Items.Add("معنوي");
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void getDataTablePlaignant()
        {
            dataGridPlaignant.Rows.Clear();

            List<Plaignant> pps = op.getAllPlaignant();
            foreach (Plaignant pp in pps)
            {
                try
                {
                    dataGridPlaignant.Rows.Add(pp.TypePlaignant, pp.IdPlaignant, pp.Nom, pp.Telephone, pp.RegistreDeCommerce1, pp.Cin);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void getDataTableParPlaignant()
        {
            dataGridParPlaignant.Rows.Clear();

            List<Par_plaignant> pps = op.getAllParPlaignant();

            foreach (Par_plaignant pp in pps)
            {
                try
                {
                    dataGridParPlaignant.Rows.Add(pp.TypeParPlaignant, pp.IdParPlaignant, pp.Nom, pp.RegistreDeCommerce1, pp.Cin, pp.Adresse);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridPlaignant_Click(object sender, EventArgs e)
        {
            String idplaignant = dataGridPlaignant.SelectedRows[0].Cells[1].Value.ToString();
            Plaignant p = op.getPlaignantByCinAndId(idplaignant).First();
            comboBoxTypeClient.Text = p.TypePlaignant;
            textBoxNumClient.Text = p.IdPlaignant.ToString();
            textBoxNomClient.Text = p.Nom;
            textBoxCINClient.Text = p.Cin;
            textBoxTelClient.Text = p.Telephone;
            textBoxMoumatilQanouniClient.Text = p.RepresentantLegal;
            textBoxSijilTijariClient.Text = p.RegistreDeCommerce1;
            textBoxAdresseClient.Text = p.Adresse;


        }

        private void dataGridParPlaignant_Click(object sender, EventArgs e)
        {

            String idparplaignant = dataGridParPlaignant.SelectedRows[0].Cells[1].Value.ToString();
            Par_plaignant p = op.getParPlaignantByIdAndCIN(idparplaignant).First();
        }


        private void btn_telecharger_Click(object sender, EventArgs e)
        {
            of.Filter = "Images (*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG)|*.BMP;*.JPG;*.PNG;*.JPEG;*.GIF|" + "All files (*.*)|*.*";
            of.Title = "تحميل الصور :";
            of.Multiselect = true;
            if (of.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("تم تحميل الصورة");
                u = 1;
            }
            else
            {
                MessageBox.Show("لم تحميل الصورة");
            }
        }

        private void btn_ajouter_plai_Click(object sender, EventArgs e)
        {
            //  this.Close();
            المشتكون plainant = new المشتكون(this);
            plainant.ShowDialog();
        }

        private void btn_ajouter_ply_Click(object sender, EventArgs e)
        {
            المشتكون_بهم parplaintes = new المشتكون_بهم(this);
            parplaintes.ShowDialog();
        }


        public Boolean isvalidate()
        {
            //Boolean b = false; 
            if ( txb_num_pl.Text == "" ||  btn_tribunal.Text == "" || listBox1.Items.Count==0)
                return false;
            else return true;

        }

        private void btn_nouveau_Click(object sender, EventArgs e)
        {

            txb_symbole.Clear();
            txb_num_pl.Clear();
            txb_genre_pl.Clear();
            textBoxNomClient.Clear();
            textBoxTelClient.Clear();
            textBoxNumClient.Clear();
            textBoxCINClient.Clear();
            cb_ville.Text = "";
            btn_tribunal.Text = "";
            comboBoxTypeClient.Text = "";
            textBoxSijilTijariClient.Clear();
            textBoxAdresseClient.Clear();
            listBox1.Items.Clear();
            textBoxMoumatilQanouniClient.Clear();
            
            btn_ajouter.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int i = 0;
            List<DataGridViewRow> rows_with_checked_column = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dataGridParPlaignant.Rows)
            {
                // MessageBox.Show(row.Cells[Column11.Name].Value.ToString());
                if (row.Cells[Column11.Name].Value == null)
                {
                }
                else
                {
                    if (row.Cells[Column11.Name].Value.ToString() == "True")
                    {
                        Par_plaignant pp = new Par_plaignant();
                        pp.IdParPlaignant = int.Parse(row.Cells[Column6.Name].Value.ToString());
                        pp.Nom = row.Cells[Column7.Name].Value.ToString();
                       
                        if (isexist(pp))
                        {
                        }
                        else
                        {
                            listBox1.Items.Add(pp);
                        }
                       
                        i++;
    
                    }
                }

            }
        }

        private Boolean isexist(Par_plaignant pp)
        {
            Boolean b = false;
            foreach (Par_plaignant item in listBox1.Items)
            {
                if (item.IdParPlaignant == pp.IdParPlaignant)
                {
                    b = true;
                    break;
                }
                else
                {

                    b = false;
                    
                }    
                
            }
            return b;
        }
        private DataSet getVilles()
        {

            SqlCommand cmd = new SqlCommand("select * from ville", cn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds, "ville");
            cn.Close();
            return ds;
        }

        private DataSet GetData_type_tribunal()
        {
            SqlCommand cmd = new SqlCommand("select * from tribunal", cn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds, "tribunal");
            cn.Close();
            return ds;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("يجب إختيار الإسم المراد حذفه");
            }
            
        }

        private void btnadddecision_Click(object sender, EventArgs e)
        {
            //DecisionForm dform = new DecisionForm(txb_num_pl.Text,this);
            //dform.ShowDialog();
        }

        private List<Par_plaignant> getParplaintes(List<PlainteParPlaignant> ppp)
        {
            List<Par_plaignant> parplains = new List<Par_plaignant>();
            foreach (PlainteParPlaignant item in ppp)
            {
                Par_plaignant pp = op.getParPlaignantByIdAndCIN(item.IdParPlaignant.ToString()).First();
                parplains.Add(pp);

            }
            return parplains;

        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            if (isvalidate())
            {
                PlaintesOperations op = new PlaintesOperations();
                Plainte p = new Plainte();
                p.IdPlainte = txb_num_pl.Text;
                p.DateCreation = date_plai.Value;
                //p.Decision = txtdecision.Text;
                p.IdPlaignant = int.Parse(textBoxNumClient.Text);
                p.Ville = cb_ville.Text;
                p.SignePlainte = txb_symbole.Text;
                p.TypeTribunal = btn_tribunal.Text;
                p.TypePlaint = txb_genre_pl.Text;
                p.DateDepotPlainte = date_depot_plainte.Value;
                //Console.WriteLine("Test1: "+p.DateCreation+" "+p.TypeTribunal);
                // MessageBox.Show("Test1: " + p.DateCreation + " " + p.TypeTribunal);
                op.updatePlainte(p);
                op.deleteplainteParpLainte(p.IdPlainte);
                foreach (Par_plaignant item in listBox1.Items)
                {
                    PlainteParPlaignant ppp = new PlainteParPlaignant();
                    ppp.IdParPlaignant = item.IdParPlaignant;
                    ppp.IdPlainte = p.IdPlainte;
                    op.addPlainteParPlaignant(ppp);
                }
                history.AddHistory("شكاية", "تعديل", txb_num_pl.Text);
        }
    }

        public void setDataListbox(String idPlainte)
        {
           
        }

        private void btn_imprimer_Click(object sender, EventArgs e)
        {
            //Form2 f = new Form2(txb_num_pl.Text);
            //f.Show();
        }

        private void btn_look_Click(object sender, EventArgs e)
        {

        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            
        }

        private void label11_Click(object sender, EventArgs e)
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

   
       
    }
    }