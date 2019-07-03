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
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Design;
using AvocaBin.Controller;
using AvocaBin.Operation;
using AvocaBin.Models.cause;
using AvocaBin.Models.Plaintes;
using AvocaBin.Models;
using AvocaBin.Controller;
using Microsoft.Office.Interop.Excel;
using AvocaBin.Report;


namespace AvocaBin.Controller
{
    public partial class Wadiaa : Form
    {
        
        SqlConnection cnx = connection.getConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        Cause_Operations co;
        PlaintesOperations po;
        order_operation oo;
        
        public Wadiaa()
        {
            InitializeComponent();
            
        }
        public void getData1()
        {
            dataGridView1.Rows.Clear();

            co = new Cause_Operations();
            List<depot_cause> depot_cause = co.getDepot_Cause();
            foreach (depot_cause cc in depot_cause)
            {
                try
                {
                    dataGridView1.Rows.Add(cc.Id_depot,cc.Id_cause, cc.Nom, cc.Nom_adv, cc.Num_check, cc.Montant);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //testdata();

        }
        public void searchDep_cause() 
        {
            dataGridView1.Rows.Clear();

            co = new Cause_Operations();
            List<depot_cause> depot_cause = co.seardepot_caause(textBox2.Text);
            foreach (depot_cause cc in depot_cause)
            {
                try
                {
                    dataGridView1.Rows.Add(cc.Id_depot, cc.Id_cause, cc.Nom, cc.Nom_adv, cc.Num_check, cc.Montant);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void getData2()
        {
            dataGridView2.Rows.Clear();

            po = new PlaintesOperations();
            List<depot_plaint> depot_plaint = po.get_depot_plainte();
            foreach (depot_plaint cc in depot_plaint)
            {
                try
                {
                    dataGridView2.Rows.Add(cc.Id_depot, cc.Id_plainte, cc.Nom, cc.Nom_adv, cc.Num_check, cc.Montant);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //testdata();

        }
        public void searchDep_plainte()
        {
            dataGridView2.Rows.Clear();

            po = new PlaintesOperations();
            List<depot_plaint> depot_plaint = po.seardepot_plainte(textBox1.Text);
            foreach (depot_plaint cc in depot_plaint)
            {
                try
                {
                    dataGridView2.Rows.Add(cc.Id_depot, cc.Id_plainte, cc.Nom, cc.Nom_adv, cc.Num_check, cc.Montant);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void getData3()
        {
            dataGridView3.Rows.Clear();

            oo = new order_operation();
            List<depot_order> depot_order = oo.detDepotOrder();
            foreach (depot_order cc in depot_order)
            {
                try
                {
                    dataGridView3.Rows.Add(cc.Id_depot, cc.Id_order, cc.Nom, cc.Nom_adv, cc.Num_check, cc.Montant);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //testdata();

        }
        public void searchdep_order()
        {
            dataGridView3.Rows.Clear();

            oo = new order_operation();
            List<depot_order> depot_order = oo.seardepot_order(textBox3.Text);
            foreach (depot_order cc in depot_order)
            {
                try
                {
                    dataGridView3.Rows.Add(cc.Id_depot, cc.Id_order, cc.Nom, cc.Nom_adv, cc.Num_check, cc.Montant);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
        private void Wadiaa_Load(object sender, EventArgs e)
        {
            // Remplisage du DataGrid des Piece Joint Cause :
            GetDataInPieceJointCause();
            GetDataInPieceJointOrder();
            GetDataInPieceJointPlgnt();

            //combobox rempliser par l'ID du cause  : 
            try
            {
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                
                cmd.Connection = cnx;
                cmd.CommandText = "SELECT id_cause FROM cause ";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cmbNumMawdoua.Items.Add(dr["id_cause"].ToString());
                    comboBoxNumCause.Items.Add(dr["id_cause"].ToString());
                }
                dr.Close();
                cnx.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //combobox rempliser par l'ID d'order  : 
            try
            {
                SqlCommand cmdIDOrder = new SqlCommand();
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                
                cmdIDOrder.Connection = cnx;
                cmdIDOrder.CommandText = "SELECT o2.id_order FROM dbo.orderr o2";
                dr = cmdIDOrder.ExecuteReader();
                while (dr.Read())
                {
                    cmbNumOrder.Items.Add(dr[0].ToString());
                    comboBoxNumOrder.Items.Add(dr[0].ToString());
                }
                dr.Close();
                cnx.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            // comboBox remplisage ID == Plagnt : 
            try
            {
                SqlCommand cmdPlagnt = new SqlCommand();
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                
                cmdPlagnt.Connection = cnx;
                cmdPlagnt.CommandText = "SELECT p.id_plainte from dbo.plainte p";
                dr = cmdPlagnt.ExecuteReader();
                while (dr.Read())
                {
                    cmbTypeFileChikaya.Items.Add(dr[0].ToString());
                    comboBoxNumPlagnt.Items.Add(dr[0].ToString());
                }
                dr.Close();
                cnx.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //remplire datagridview
            try
            {
                getData1();
                getData2();
                getData3();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void معلوماتعتاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProposNous p = new ProposNous();
            p.Show();
        }

        private void cmbTypeFileMawdoua_TextChanged(object sender, EventArgs e)
        {


            try
            {
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                
                cmd.Connection = cnx;
                cmd.CommandText = "SELECT cc.id_client_cause, cc.nom , ac.id_adversaire_cause ,ac.nom_adv  from dbo.cause c, dbo.client_cause cc, dbo.adversaire_cause ac WHERE c.id_cause='" + cmbNumMawdoua.SelectedItem + "' AND c.id_client=cc.id_client_cause AND c.id_adv=ac.id_adversaire_cause ";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtClientMawdoua.Clear();
                    txtAdvMawdoua.Clear();
                    txtClientMawdoua.Text = dr[1].ToString().Trim() + " - " + dr[0].ToString().Trim();
                    txtAdvMawdoua.Text = dr[3].ToString().Trim() +" - "+ dr[2].ToString().Trim();
                }
               
                cnx.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

          
            

            
        }
        OpenFileDialog dlg = new OpenFileDialog();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            dlgPieceJointCause.Filter = "Images (*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG)|*.BMP;*.JPG;*.PNG;*.JPEG;*.GIF|" + "All files (*.*)|*.*";
            if (dlgPieceJointCause.ShowDialog() == DialogResult.OK)
            {
                imagLocation = dlgPieceJointCause.FileName.ToString();
                //pictureBoxPieceJointWadiaaMawdoua.ImageLocation = imagLocation;
            }
            
        }


        string imagLocation = "";
        private void btn_ajouter_Click(object sender, EventArgs e)
        {
            if(cnx.State==ConnectionState.Closed)
            {
                cnx.Open();
            }
            
            if (txtAdvMawdoua.Text != "" && txtClientMawdoua.Text != "" && txtMontantMawdoua.Text != "" && txtNumCheckMawdoua.Text != "")
                {
                //byte[] imageCause = null;
                //FileStream stream = new FileStream(imagLocation, FileMode.Open, FileAccess.Read);
                //BinaryReader br = new BinaryReader(stream);
                //imageCause = br.ReadBytes((int)stream.Length);
                    
                


                SqlCommand cmdAjoutCause = new SqlCommand();
                cmd.Connection = cnx;
                cmdAjoutCause.Connection = cnx;
                cmd.CommandText = "SELECT cc.id_client_cause, cc.nom , ac.id_adversaire_cause ,ac.nom_adv  from dbo.cause c, dbo.client_cause cc, dbo.adversaire_cause ac WHERE c.id_cause='" + cmbNumMawdoua.SelectedItem + "' AND c.id_client=cc.id_client_cause AND c.id_adv=ac.id_adversaire_cause ";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //cmdAjoutCause.Parameters.Add(new SqlParameter("@logo", imageCause));
                    cmdAjoutCause.CommandText = "insert into depot_cause values('" + cmbNumMawdoua.Text + "'," + int.Parse(dr[0].ToString()) + "," + int.Parse(dr[2].ToString()) + ", " + txtNumCheckMawdoua.Text.ToString() + "," + float.Parse(txtMontantMawdoua.Text) + ")";
                }
                dr.Close();
                cmdAjoutCause.ExecuteNonQuery();
                MessageBox.Show("لقد ثمت الاضافة بنجاح ... ");
                getData1();
                history.AddHistory(" الوديعة", "الاضافة", cmbNumMawdoua.Text);
                cnx.Close();
                }
                else
                {
                    MessageBoxManager.OK = "حسنا";
                    MessageBoxManager.Register();
                    MessageBox.Show("يجب ملئ الخانات ", "تنبيه", MessageBoxButtons.OK);
                }
        }
            
        private void xtraTabPage4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Images (*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG)|*.BMP;*.JPG;*.PNG;*.JPEG;*.GIF|" + "All files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                imagLocation = dlg.FileName.ToString();
                //pictureBoxChikayaPieceJoin.ImageLocation = imagLocation;
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Images (*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG)|*.BMP;*.JPG;*.PNG;*.JPEG;*.GIF|" + "All files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                imagLocation = dlg.FileName.ToString();
               // pictureBoxChikayaPieceJoin.ImageLocation = imagLocation;
                //pictureBoxOrderPieceJoint.ImageLocation = imagLocation;
            }
        }

        private void xtraTabPage6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbNumMawdoua_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cnx.State==ConnectionState.Closed)
                {
                    cnx.Open();
                }
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT cc.id_client_cause, cc.nom , ac.id_adversaire_cause ,ac.nom_adv  from dbo.cause c, dbo.client_cause cc, dbo.adversaire_cause ac WHERE c.id_cause='"+cmbNumMawdoua.Text+"' AND c.id_client=cc.id_client_cause AND c.id_adv=ac.id_adversaire_cause";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnx;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtClientMawdoua.Clear();
                    txtAdvMawdoua.Clear();
                    txtClientMawdoua.Text = dr["id_client_cause"].ToString();
                    txtAdvMawdoua.Text = dr["id_adversaire_cause"].ToString();
                }
                dr.Close();
                cnx.Close();



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cmbTypeFileChikaya_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtClientChikaya.Clear();
                listeBoxParPlagnt.Items.Clear();
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                
                SqlCommand cmdNomIDcHikaya = new SqlCommand();
                cmdNomIDcHikaya.Connection = cnx;
                cmdNomIDcHikaya.CommandText = "SELECT p2.id_plaignant, p2.nom, ppp.id_par_plaignant ,pp.nom from dbo.plainte p,dbo.plaignant p2, dbo.plainte_par_plaignant ppp, dbo.par_plaignant pp WHERE p.id_plainte='"+cmbTypeFileChikaya.SelectedItem+"' AND p.id_plaignant=p2.id_plaignant AND pp.id_par_plaignant=ppp.id_par_plaignant AND pp.id_par_plaignant=ppp.id_par_plaignant AND ppp.id_plainte=p.id_plainte ";
                dr = cmdNomIDcHikaya.ExecuteReader();
                while (dr.Read())
                {
                    
                    //txtAdvChikaya.Clear();
                    txtClientChikaya.Text = dr[0].ToString() + " / " + dr[1].ToString();
                    listeBoxParPlagnt.Items.Add(dr[2].ToString() + " / " + dr[3].ToString());
                }
                dr.Close();
                cnx.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cmbNumOrder_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                
                SqlCommand cmdNomIDOrder = new SqlCommand();
                cmdNomIDOrder.Connection = cnx;
                cmdNomIDOrder.CommandText = "SELECT co.id_client_order,co.nom,ao.id_adv_order,ao.nom FROM dbo.orderr o, dbo.client_order co, dbo.adv_order ao WHERE o.id_order='"+cmbNumOrder.SelectedItem+"' AND o.id_client_order=co.id_client_order AND ao.id_adv_order=o.id_adversaire_order";
                dr = cmdNomIDOrder.ExecuteReader();
                while (dr.Read())
                {
                    txtClientOrder.Clear();
                    txtAdvOrder.Clear();
                    txtClientOrder.Text = dr[0].ToString() + " / " + dr[1].ToString();
                    txtAdvOrder.Text = dr[2].ToString() + " / " + dr[3].ToString();
                }
                dr.Close();
                cnx.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton4_Click_1(object sender, EventArgs e)
        {
            txtClientMawdoua.Clear();
            //pictureBoxPieceJointWadiaaMawdoua.Image = null;
            cmbNumMawdoua.Text = "";
            txtAdvMawdoua.Clear();
            txtNumCheckMawdoua.Clear();
            txtMontantMawdoua.Clear();
            txtClientMawdoua.Clear();

        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            txtClientChikaya.Clear();
            //pictureBoxChikayaPieceJoin.Image = null;
            //txtAdvChikaya.Clear();
            listeBoxParPlagnt.Items.Clear();
            txtNumCheckChikaya.Clear();
            txtMontantChikaya.Clear();


        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            txtClientOrder.Clear();
            txtAdvOrder.Clear();
            txtNumCheckOrder.Clear();
            txtMontantOrder.Clear();
            //pictureBoxOrderPieceJoint.Image = null;


        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_nouveau_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            
           try
           {
               int ID_Par_Plagnant=0;
               int ID_Plaignant;
               if(cnx.State==ConnectionState.Closed)
               {
                   cnx.Open();
               }
               if ( txtClientChikaya.Text != "" && listeBoxParPlagnt.SelectedItem != "" && txtNumCheckChikaya.Text != "" && txtMontantChikaya.Text != "")
               {
                   //byte[] image = null;
                   //FileStream stream = new FileStream(imagLocation, FileMode.Open, FileAccess.Read);
                   //BinaryReader br = new BinaryReader(stream);
                   //image = br.ReadBytes((int)stream.Length);

                   
                   SqlCommand CmdInfoPlgnt1 = new SqlCommand();
                   CmdInfoPlgnt1.Connection = cnx;
                   cmd.Connection = cnx;
                   CmdInfoPlgnt1.CommandText = "SELECT distinct p2.id_plaignant, ppp.id_par_plaignant, pp.nom from dbo.plainte p,dbo.plaignant p2, dbo.plainte_par_plaignant ppp, dbo.par_plaignant pp WHERE p.id_plainte='"+cmbTypeFileChikaya.SelectedItem+"' AND p.id_plaignant=p2.id_plaignant AND pp.id_par_plaignant=ppp.id_par_plaignant AND   ppp.id_plainte=p.id_plainte";
                   SqlDataReader DataReader1 = CmdInfoPlgnt1.ExecuteReader();
                   DataReader1.Read();
                   ID_Plaignant = (int)DataReader1["id_plaignant"];
                   
                   if (listeBoxParPlagnt.Text!=null)
                   {
                       ID_Par_Plagnant = (int)DataReader1["id_par_plaignant"];
                   }
                       

                       cmd.CommandText = "insert into  depot_plgn([id_plainte],[id_plaignant],[id_par_plaignant],[num_check],[montant])values('" + cmbTypeFileChikaya.Text + "'," + ID_Plaignant + "," + ID_Par_Plagnant + "," + txtNumCheckChikaya.Text.ToString() + "," + float.Parse(txtMontantChikaya.Text) + ")";
                       cmd.Parameters.Add("@ID_Par_Plagn", ID_Par_Plagnant);
                       //cmd.Parameters.Add(new SqlParameter("@logoo", image));
                       //cmd.CommandText = "insert into depot_plgn values('" + cmbTypeFileChikaya.Text + "'," + ID_Plaignant + ", " + ID_Par_Plagnant + " , " + int.Parse(txtNumCheckChikaya.Text) + "," + float.Parse(txtMontantChikaya.Text) + ",@logoo)";
                       DataReader1.Close();
                       dr.Close();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("لقد ثمت الاضافة بنجاح ... ", "الاضافة", MessageBoxButtons.OK);
                        history.AddHistory(" الوديعة", "الاضافة", cmbTypeFileChikaya.Text);
                        getData2();
                        cnx.Close();
                        cmd.Parameters.Clear();


               }
               else
               {
                   MessageBoxManager.OK = "حسنا";
                   MessageBoxManager.Register();
                   MessageBox.Show("يجب ملئ الخانات ", "تنبيه", MessageBoxButtons.OK);
               }
           }


           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }

                // requéte récuperation des ID d'order :

                SqlCommand cmdNomIDOrder = new SqlCommand();
                cmdNomIDOrder.Connection = cnx;
                cmdNomIDOrder.CommandText = "SELECT co.id_client_order,co.nom,ao.id_adv_order,ao.nom FROM dbo.orderr o, dbo.client_order co, dbo.adv_order ao WHERE o.id_order='" + cmbNumOrder.SelectedItem + "' AND o.id_client_order=co.id_client_order AND ao.id_adv_order=o.id_adversaire_order";
                dr = cmdNomIDOrder.ExecuteReader();
                while (dr.Read())
                {
                    txtClientOrder.Clear();
                    txtAdvOrder.Clear();
                    txtClientOrder.Text = dr[0].ToString() + " / " + dr[1].ToString();
                    txtAdvOrder.Text = dr[2].ToString() + " / " + dr[3].ToString();
                }
                dr.Close();



                //!string.IsNullOrEmpty(imagLocation)
                if ((txtClientOrder.Text != "" && txtAdvOrder.Text != "" && txtNumCheckOrder.Text != "" && txtMontantOrder.Text != ""))
                {

                    //byte[] imageCause = null;
                    //FileStream stream = new FileStream(imagLocation, FileMode.Open, FileAccess.Read);
                    //BinaryReader br = new BinaryReader(stream);
                    //imageCause = br.ReadBytes((int)stream.Length);


                    SqlCommand cmdInfoOrder = new SqlCommand();
                    cmd.Connection = cnx;
                    cmdInfoOrder.Connection = cnx;
                    cmdInfoOrder.CommandText = "SELECT co.id_client_order,ao.id_adv_order FROM dbo.orderr o, dbo.client_order co, dbo.adv_order ao WHERE o.id_order='" + cmbNumOrder.SelectedItem + "' AND o.id_client_order=co.id_client_order AND ao.id_adv_order=o.id_adversaire_order";
                    SqlDataReader DataReaderOrderInfo = cmdInfoOrder.ExecuteReader();
                    DataReaderOrderInfo.Read();
                    //cmd.Parameters.Add(new SqlParameter("@logo", imageCause));
                    cmd.CommandText = "insert into depot_order values('" + cmbNumOrder.Text.ToString() + "'," + (int)DataReaderOrderInfo["id_client_order"] + "," + int.Parse(DataReaderOrderInfo["id_adv_order"].ToString()) + ", " +  txtNumCheckOrder.Text.ToString() + "," + float.Parse(txtMontantOrder.Text) + ")";
                    DataReaderOrderInfo.Close();
                    dr.Close();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("لقد ثم اضافة الوديعة بنجاح ... ");
                    history.AddHistory(" الوديعة", "الاضافة", cmbNumOrder.Text.ToString());
                    getData3();
                    cnx.Close();
                    cmd.Parameters.Clear();
                }
                else
                {
                    MessageBoxManager.OK = "حسنا";
                    MessageBoxManager.Register();
                    MessageBox.Show("يجب ملئ الخانات ", "تنبيه", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbTypeFileChikaya_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT distinct p2.id_plaignant, ppp.id_par_plaignant, pp.nom from dbo.plainte p,dbo.plaignant p2, dbo.plainte_par_plaignant ppp, dbo.par_plaignant pp WHERE p.id_plainte='"+cmbTypeFileChikaya.Text+"' AND p.id_plaignant=p2.id_plaignant AND pp.id_par_plaignant=ppp.id_par_plaignant AND   ppp.id_plainte=p.id_plainte";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    listeBoxParPlagnt.Items.Clear();
                    txtClientChikaya.Clear();
                    listeBoxParPlagnt.Items.Add(dr["id_par_plaignant"].ToString()+"  /  "+dr["nom"].ToString());
                    txtClientChikaya.Text = dr["id_plaignant"].ToString();
                }
                dr.Close();
                cnx.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void xtraTabPage5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbNumOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cnx.State==ConnectionState.Closed)
                {
                    cnx.Open();
                }
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnx;
                cmd.CommandText = "SELECT co.id_client_order,co.nom,ao.id_adv_order,ao.nom FROM dbo.orderr o, dbo.client_order co, dbo.adv_order ao WHERE o.id_order='"+cmbNumOrder.Text+"' AND o.id_client_order=co.id_client_order AND ao.id_adv_order=o.id_adversaire_order";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtClientOrder.Clear();
                    txtAdvOrder.Clear();
                    txtClientOrder.Text = dr["id_client_order"].ToString() + "  /  " + dr["nom"].ToString();
                    txtAdvOrder.Text = dr["id_adv_order"].ToString() + "  /  " + dr["nom"].ToString();

                }
                dr.Close();
                cnx.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                Imprimer_Depot_Cause frm = new Imprimer_Depot_Cause(id);
                frm.Show();
            }
            else
            {

            }
        }

        private void simpleButton17_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count != 0)
            {
                int id = int.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                Imprimer_Depot_Plainte frm = new Imprimer_Depot_Plainte(id);
                frm.Show();
            }
            else
            {

            }
        }

        private void simpleButton23_Click(object sender, EventArgs e)
        {
            if (dataGridView3.Rows.Count!=0)
            {
                int id = int.Parse(dataGridView3.SelectedRows[0].Cells[0].Value.ToString());
                Imprimer_depot_order frm = new Imprimer_depot_order(id);
                frm.Show();
            }
            else
            {

            }
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                getData1();

            }
            else 
            {
                searchDep_cause();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                getData2();

            }
            else
            {
                searchDep_plainte();
            }
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
             if (textBox3.Text == "")
            {
                getData3();

            }
            else
            {
                searchdep_order();
            }
           
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            ImprimerAllDept_Cause frm = new ImprimerAllDept_Cause(textBox2.Text);
            frm.Show();
        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            ImprimerAllDepotPlainte frm = new ImprimerAllDepotPlainte(textBox1.Text);
            frm.Show();
        }

        private void simpleButton22_Click(object sender, EventArgs e)
        {
            ImprimerAllDepotOrder frm = new ImprimerAllDepotOrder(textBox3.Text);
            frm.Show();
        }

        private void dropDownButton3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void dropDownButton2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void dropDownButton1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }


        // Tableau Cause :
        private void copyAlltoClipboardTableauCause()
        {

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        // Export to Excel Tableau All Depot Cause :
        private void simpleButton11_Click(object sender, EventArgs e)
        {

            copyAlltoClipboardTableauCause();
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

        private void simpleButton10_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton21_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton27_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xtraTabPage8_Paint(object sender, PaintEventArgs e)
        {

        }

        // Tableau Plgnt :
        private void copyAlltoClipboardTableauPlgnt()
        {

            dataGridView2.RowHeadersVisible = false;
            dataGridView2.SelectAll();
            DataObject dataObj = dataGridView2.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        // Export to Excel Tableau All Depot Plgnt :
        private void simpleButton12_Click(object sender, EventArgs e)
        {

            copyAlltoClipboardTableauPlgnt();
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

        // Tableau Order :
        private void copyAlltoClipboardTableauOrder()
        {

            dataGridView3.RowHeadersVisible = false;
            dataGridView3.SelectAll();
            DataObject dataObj = dataGridView3.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        // Export to Excel Tableau All Depot Order :
        private void simpleButton13_Click(object sender, EventArgs e)
        {
            copyAlltoClipboardTableauOrder();
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

        private void xtraTabControl2_Click(object sender, EventArgs e)
        {

        }

        private void xtraTabPage3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        // Vider les champs de saisies Order :
        public void ClearSaisieOrder()
        {
            textBox8.Clear();
            comboBoxNumOrder.Text = "";
            pictureBoxOrder.Image = null;
        }


        // Vider les champs de saisies Plgnt :
        public void ClearSaisiePlgnt()
        {
            textBox10.Clear();
            comboBoxNumPlagnt.Text = "";
            pictureBoxPlagnt.Image = null;
        }


        // Vider les champs de saisies Cause :
        public void ClearSaisieCause()
        {
            textBox12.Clear();
            comboBoxNumCause.Text = "";
            pictureBoxCause.Image = null;
        }

        // Order :
        public void GetDataInPieceJointOrder()
        {
            try
            {
                dataGridView6.Rows.Clear();
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                SqlCommand CmdOrderDataPieceJoint = new SqlCommand();
                CmdOrderDataPieceJoint.Connection = cnx;
                CmdOrderDataPieceJoint.CommandText = "select Num_Depot_piece,Num_File,Titre,Image_depot_piece from Depot_piece dp , orderr o where dp.Num_File=o.id_order";
                dr = CmdOrderDataPieceJoint.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView6.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(),dr[3]);
                }
                dr.Close();
                cnx.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        // Plagnt :
        public void GetDataInPieceJointPlgnt()
        {
            try
            {
                dataGridView5.Rows.Clear();
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                SqlCommand CmdPlgntDataPieceJoint = new SqlCommand();
                CmdPlgntDataPieceJoint.Connection = cnx;
                CmdPlgntDataPieceJoint.CommandText = "select Num_Depot_piece,Num_File,Titre,Image_depot_piece from Depot_piece dp , plainte p where dp.Num_File=p.id_plainte";
                dr = CmdPlgntDataPieceJoint.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView5.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(),dr[3]);
                }
                dr.Close();
                cnx.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //Cause :
        public void GetDataInPieceJointCause()
        {
            try
            {

                dataGridView4.Rows.Clear();
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                SqlCommand CmdCauseDataPieceJoint = new SqlCommand();
                CmdCauseDataPieceJoint.Connection = cnx;
                CmdCauseDataPieceJoint.CommandText = "select Num_Depot_piece,Num_File,Titre,Image_depot_piece from Depot_piece dp , cause c where dp.Num_File=c.id_cause";
                dr = CmdCauseDataPieceJoint.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView4.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3]);
                }
                dr.Close();
                cnx.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        
        private void simpleButton32_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox12.Text != null && !string.IsNullOrEmpty(imagLocation))
                {
                    byte[] imageCause = null;
                    FileStream stream = new FileStream(imagLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(stream);
                    imageCause = br.ReadBytes((int)stream.Length);
                    
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                    SqlCommand CmdAjoutPieceJointCause = new SqlCommand();
                    SqlParameter ParamLogo = new SqlParameter("@ImagePieceCause", imageCause);
                    CmdAjoutPieceJointCause.Parameters.Add(ParamLogo);
                    CmdAjoutPieceJointCause.Connection = cnx;
                    CmdAjoutPieceJointCause.CommandText = "insert into Depot_piece values('" + comboBoxNumCause.Text + "' , '" + textBox12.Text + "' , @ImagePieceCause) ";
                    CmdAjoutPieceJointCause.CommandType = CommandType.Text;
                    CmdAjoutPieceJointCause.ExecuteNonQuery();
                    MessageBox.Show("ثم اظافة الوثيقة بنجاح ", "وثائق القضية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cnx.Close();
                    GetDataInPieceJointCause();
                }
                else
                {
                    MessageBox.Show("يجب ملئ البيانات , لا يمكن ادخال الوتيقة ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        //dialog Cause
        OpenFileDialog dlgPieceJointCause = new OpenFileDialog();
        private void simpleButton37_Click(object sender, EventArgs e)
        {
            dlgPieceJointCause.Filter = "Images (*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG)|*.BMP;*.JPG;*.PNG;*.JPEG;*.GIF|" + "All files (*.*)|*.*";
            if (dlgPieceJointCause.ShowDialog() == DialogResult.OK)
            {
                imagLocation = dlgPieceJointCause.FileName.ToString();
                pictureBoxCause.ImageLocation = imagLocation;
            }
        }

        // dialog Plagnt 
        OpenFileDialog dlgPieceJointPlgnt = new OpenFileDialog();
        private void simpleButton36_Click(object sender, EventArgs e)
        {
            dlgPieceJointCause.Filter = "Images (*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG)|*.BMP;*.JPG;*.PNG;*.JPEG;*.GIF|" + "All files (*.*)|*.*";
            if (dlgPieceJointCause.ShowDialog() == DialogResult.OK)
            {
                imagLocation = dlgPieceJointCause.FileName.ToString();
                pictureBoxPlagnt.ImageLocation = imagLocation;
            }
        }


        // dialog Order 
        OpenFileDialog dlgPieceJointOrder = new OpenFileDialog();
        private void simpleButton35_Click(object sender, EventArgs e)
        {
            dlgPieceJointCause.Filter = "Images (*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG)|*.BMP;*.JPG;*.PNG;*.JPEG;*.GIF|" + "All files (*.*)|*.*";
            if (dlgPieceJointCause.ShowDialog() == DialogResult.OK)
            {
                imagLocation = dlgPieceJointCause.FileName.ToString();
                pictureBoxOrder.ImageLocation = imagLocation;
            }
        }

        private void simpleButton33_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox10.Text != null && !string.IsNullOrEmpty(imagLocation))
                {
                    byte[] imagePlgnt = null;
                    FileStream stream = new FileStream(imagLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(stream);
                    imagePlgnt = br.ReadBytes((int)stream.Length);
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                    SqlCommand CmdAjoutPieceJointPlgnt = new SqlCommand();
                    SqlParameter ParamLogo = new SqlParameter("@ImagePiecePlgnt", imagePlgnt);
                    CmdAjoutPieceJointPlgnt.Parameters.Add(ParamLogo);
                    CmdAjoutPieceJointPlgnt.Connection = cnx;
                    CmdAjoutPieceJointPlgnt.CommandText = "insert into Depot_piece values('" + comboBoxNumPlagnt.Text + "' , '" + textBox10.Text + "' , @ImagePiecePlgnt)";
                    CmdAjoutPieceJointPlgnt.ExecuteNonQuery();
                    MessageBox.Show("ثم اظافة الوثيقة بنجاح ", "وثائق الشكاية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cnx.Close();
                    GetDataInPieceJointPlgnt();
                }
                else
                {
                    MessageBox.Show("يجب ملئ البيانات , لا يمكن ادخال الوتيقة ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxNumCause_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton25_Click(object sender, EventArgs e)
        {
            int id_PieceJointDepotOrder = int.Parse(dataGridView6.SelectedRows[0].Cells[0].Value.ToString());
            ImprimerOnePieceJointDepotOrder i = new ImprimerOnePieceJointDepotOrder(id_PieceJointDepotOrder);
            i.Show();


            
        }

        private void simpleButton34_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(imagLocation) && textBox12.Text != null)
                {
                    byte[] imageOrder = null;
                    FileStream stream = new FileStream(imagLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(stream);
                    imageOrder = br.ReadBytes((int)stream.Length);
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                    SqlCommand CmdAjoutPieceJointOrder = new SqlCommand();
                    SqlParameter ParamLogo = new SqlParameter("@ImagePieceOrder", imageOrder);
                    CmdAjoutPieceJointOrder.Parameters.Add(ParamLogo);
                    CmdAjoutPieceJointOrder.Connection = cnx;
                    CmdAjoutPieceJointOrder.CommandText = "insert into Depot_piece values('" + comboBoxNumOrder.Text + "' , '" + textBox8.Text + "' , @ImagePieceOrder)";
                    CmdAjoutPieceJointOrder.ExecuteNonQuery();
                    MessageBox.Show("ثم اظافة الوثيقة بنجاح ", "وثائق الامر", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cnx.Close();
                    GetDataInPieceJointOrder();
                }
                else
                {
                    MessageBox.Show("يجب ملئ البيانات , لا يمكن ادخال الوتيقة ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        private void dataGridView4_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void simpleButton27_Click_1(object sender, EventArgs e)
        {
            try
            {
                    byte[] imageCause = null;
                    if (cnx.State==ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                    SqlCommand CmdUpdatePieceJointCause = new SqlCommand();
                    if ((imagLocation != "" || textBox12.Modified != false))
                    {
                        if (imagLocation != "")
                        {
                            FileStream stream = new FileStream(imagLocation, FileMode.Open, FileAccess.Read);
                            BinaryReader br = new BinaryReader(stream);
                            imageCause = br.ReadBytes((int)stream.Length);
                            SqlParameter ParamLogo = new SqlParameter("@ImagePieceCause", imageCause);
                            CmdUpdatePieceJointCause.Connection = cnx;

                            CmdUpdatePieceJointCause.CommandText = "update Depot_piece set  Image_depot_piece=@ImagePieceCause  where Num_Depot_piece='" + dataGridView4.CurrentRow.Cells[0].Value + "' ";
                            CmdUpdatePieceJointCause.Parameters.Add(ParamLogo);
                            CmdUpdatePieceJointCause.ExecuteNonQuery();
                            cnx.Close();
                            MessageBox.Show("ثم تعديل الصورة بنجاح ", "وثائق الموضوع", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearSaisieCause();
                            GetDataInPieceJointCause();
                        }
                        if (textBox12.Modified != false)
                        {
                            if (cnx.State == ConnectionState.Closed)
                            {
                                cnx.Open();
                            }
                            CmdUpdatePieceJointCause.Connection = cnx;
                            CmdUpdatePieceJointCause.CommandText = "update Depot_piece set Titre = '" + textBox12.Text + "'  where Num_Depot_piece='" + dataGridView4.CurrentRow.Cells[0].Value + "' ";
                            CmdUpdatePieceJointCause.ExecuteNonQuery();
                            cnx.Close();
                            MessageBox.Show("ثم تعديل العنوان بنجاح ", "وثائق الموضوع", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearSaisieCause();
                            GetDataInPieceJointCause();
                        }
                    }
                    }
             catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
             }
                    
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBoxNumCause.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            textBox12.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
            Image img = byteArrayToImage((byte[])dataGridView4.CurrentRow.Cells[3].Value);
            pictureBoxCause.Image = img;
        }

        private void simpleButton26_Click(object sender, EventArgs e)
        {
            try
            {
                if (cnx.State==ConnectionState.Closed)
                {
                    cnx.Open();
                }
                if (dataGridView4.Rows.Count > 0)
                {
                    SqlCommand CmdDeletePieceJointCause = new SqlCommand();
                    CmdDeletePieceJointCause.Connection = cnx;
                    CmdDeletePieceJointCause.CommandText = "delete from Depot_piece where Num_Depot_piece=" + dataGridView4.CurrentRow.Cells[0].Value + "";
                    CmdDeletePieceJointCause.ExecuteNonQuery();
                    MessageBox.Show("ثم حدف الوثيقة بنجاح ", "وثائق الموضوع", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cnx.Close();
                    GetDataInPieceJointCause();
                }
                else
                {
                    MessageBox.Show("يجب اختيار الوثيقة المراد حدفها  ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            ClearSaisieCause();
        }

        private void simpleButton6_Click_1(object sender, EventArgs e)
        {
            ClearSaisiePlgnt();
        }

        private void simpleButton7_Click_1(object sender, EventArgs e)
        {
            ClearSaisieOrder();
        }

        private void simpleButton28_Click(object sender, EventArgs e)
        {
            try
            {
                    byte[] imagePlgnt = null;
                    if (cnx.State==ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                    SqlCommand CmdUpdatePieceJointPlgnt = new SqlCommand();
                    if ((imagLocation != "" || textBox10.Modified != false))
                    {
                        if (imagLocation != "")
                        {
                            FileStream stream = new FileStream(imagLocation, FileMode.Open, FileAccess.Read);
                            BinaryReader br = new BinaryReader(stream);
                            imagePlgnt = br.ReadBytes((int)stream.Length);
                            SqlParameter ParamLogo = new SqlParameter("@ImagePiecePlgnt", imagePlgnt);
                            CmdUpdatePieceJointPlgnt.Connection = cnx;
                            CmdUpdatePieceJointPlgnt.CommandText = "update Depot_piece set  Image_depot_piece=@ImagePiecePlgnt  where Num_Depot_piece='" + dataGridView5.CurrentRow.Cells[0].Value + "' ";
                            CmdUpdatePieceJointPlgnt.Parameters.Add(ParamLogo);
                            CmdUpdatePieceJointPlgnt.ExecuteNonQuery();
                            cnx.Close();
                            MessageBox.Show("ثم تعديل الصورة بنجاح ", "وثائق الشكاية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearSaisiePlgnt();
                            GetDataInPieceJointPlgnt();
                        }
                        if (textBox10.Modified != false)
                        {
                            if (cnx.State == ConnectionState.Closed)
                            {
                                cnx.Open();
                            }
                            CmdUpdatePieceJointPlgnt.Connection = cnx;
                            CmdUpdatePieceJointPlgnt.CommandText = "update Depot_piece set Titre = '" + textBox10.Text + "'  where Num_Depot_piece='" + dataGridView5.CurrentRow.Cells[0].Value + "' ";
                            CmdUpdatePieceJointPlgnt.ExecuteNonQuery();
                            cnx.Close();
                            MessageBox.Show("ثم تعديل العنوان بنجاح ", "وثائق الشكاية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearSaisiePlgnt();
                            GetDataInPieceJointPlgnt();
                        }
                    }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBoxNumPlagnt.Text = dataGridView5.CurrentRow.Cells[1].Value.ToString();
            textBox10.Text = dataGridView5.CurrentRow.Cells[2].Value.ToString();
            Image img = byteArrayToImage((byte[])dataGridView5.CurrentRow.Cells[3].Value);
            pictureBoxPlagnt.Image = img;
        }

        private void simpleButton30_Click(object sender, EventArgs e)
        {

            try
            {
                byte[] imageOrder = null;
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                SqlCommand CmdUpdatePieceJointOrder = new SqlCommand();
                if ((imagLocation != "" || textBox8.Modified != false))
                {
                    if (imagLocation != "")
                    {
                        FileStream stream = new FileStream(imagLocation, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(stream);
                        imageOrder = br.ReadBytes((int)stream.Length);
                        SqlParameter ParamLogo = new SqlParameter("@ImagePieceOrder", imageOrder);
                        CmdUpdatePieceJointOrder.Connection = cnx;
                        CmdUpdatePieceJointOrder.CommandText = "update Depot_piece set  Image_depot_piece=@ImagePieceOrder  where Num_Depot_piece='" + dataGridView6.CurrentRow.Cells[0].Value + "' ";
                        CmdUpdatePieceJointOrder.Parameters.Add(ParamLogo);
                        CmdUpdatePieceJointOrder.ExecuteNonQuery();
                        cnx.Close();
                        MessageBox.Show("ثم تعديل الصورة بنجاح ", "وثائق الامر", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearSaisieOrder();
                        GetDataInPieceJointOrder();
                    }
                    if (textBox8.Modified != false)
                    {
                        if (cnx.State == ConnectionState.Closed)
                        {
                            cnx.Open();
                        }
                        CmdUpdatePieceJointOrder.Connection = cnx;
                        CmdUpdatePieceJointOrder.CommandText = "update Depot_piece set Titre = '" + textBox8.Text + "'  where Num_Depot_piece='" + dataGridView6.CurrentRow.Cells[0].Value + "' ";
                        CmdUpdatePieceJointOrder.ExecuteNonQuery();
                        cnx.Close();
                        MessageBox.Show("ثم تعديل العنوان بنجاح ", "وثائق الامر", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearSaisieOrder();
                        GetDataInPieceJointOrder();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBoxNumOrder.Text = dataGridView6.CurrentRow.Cells[1].Value.ToString();
            textBox8.Text = dataGridView6.CurrentRow.Cells[2].Value.ToString();
            Image img = byteArrayToImage((byte[])dataGridView6.CurrentRow.Cells[3].Value);
            pictureBoxOrder.Image = img;
        }

        private void xtraTabPage11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void simpleButton29_Click(object sender, EventArgs e)
        {
            try
            {
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                if (dataGridView5.Rows.Count > 0)
                {
                    SqlCommand CmdDeletePieceJointPlgnt = new SqlCommand();
                    CmdDeletePieceJointPlgnt.Connection = cnx;
                    CmdDeletePieceJointPlgnt.CommandText = "delete from Depot_piece where Num_Depot_piece=" + dataGridView5.CurrentRow.Cells[0].Value + "";
                    CmdDeletePieceJointPlgnt.ExecuteNonQuery();
                    MessageBox.Show("ثم حدف الوثيقة بنجاح ", "وثائق الموضوع", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cnx.Close();
                    GetDataInPieceJointPlgnt();
                }
                else
                {
                    MessageBox.Show("يجب اختيار الوثيقة المراد حدفها  ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton31_Click(object sender, EventArgs e)
        {
             try
            {
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                if (dataGridView6.Rows.Count > 0)
                {
                    SqlCommand CmdDeletePieceJointPlgnt = new SqlCommand();
                    CmdDeletePieceJointPlgnt.Connection = cnx;
                    CmdDeletePieceJointPlgnt.CommandText = "delete from Depot_piece where Num_Depot_piece=" + dataGridView6.CurrentRow.Cells[0].Value + "";
                    CmdDeletePieceJointPlgnt.ExecuteNonQuery();
                    MessageBox.Show("ثم حدف الوثيقة بنجاح ", "وثائق الموضوع", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cnx.Close();
                    GetDataInPieceJointOrder();
                }
                else
                {
                    MessageBox.Show("يجب اختيار الوثيقة المراد حدفها  ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        
        }

        // Export to excel ( Cause ) :
        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            copyAlltoClipboardCause();
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

        // Export to excel ( Plgnt ) :
        private void simpleButton18_Click(object sender, EventArgs e)
        {
            copyAlltoClipboardPlgnt();
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

        // Export to excel ( Order ) :
        private void simpleButton21_Click_1(object sender, EventArgs e)
        {
            copyAlltoClipboardOrder();
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

        // Order :
        private void copyAlltoClipboardOrder()
        {
            
            dataGridView6.RowHeadersVisible = false;
            dataGridView6.SelectAll();
            DataObject dataObj = dataGridView6.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        
        //Cause :
        private void copyAlltoClipboardCause()
        {

            dataGridView4.RowHeadersVisible = false;
            dataGridView4.SelectAll();
            DataObject dataObj = dataGridView4.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }


        // Plgnt :
        private void copyAlltoClipboardPlgnt()
        {

            dataGridView5.RowHeadersVisible = false;
            dataGridView5.SelectAll();
            DataObject dataObj = dataGridView5.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void simpleButton10_Click_2(object sender, EventArgs e)
        {
            int Id_PieceJointDepotCause = int.Parse(dataGridView4.SelectedRows[0].Cells[0].Value.ToString());
            ImprimerOnePieceJointDepotCause i = new ImprimerOnePieceJointDepotCause(Id_PieceJointDepotCause);
            i.Show();
        }

        private void simpleButton20_Click(object sender, EventArgs e)
        {
            int id_PieceJointDepotPlgn = int.Parse(dataGridView5.SelectedRows[0].Cells[0].Value.ToString());
            ImprimerOnePieceJointDepotPlgnt i = new ImprimerOnePieceJointDepotPlgnt(id_PieceJointDepotPlgn);
            i.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cnx.State==ConnectionState.Closed)
                {
                    cnx.Open();
                }
                if (textBox4.Text == "")
                {
                    GetDataInPieceJointCause();
                }
                else
                {
                    dataGridView4.Rows.Clear();
                    SqlCommand CmdCause = new SqlCommand("SELECT * FROM [Depot_piece] where  [Num_File]  like @Num or Num_Depot_piece like @NumP", cnx);
                    SqlDataReader DrCasue;
                    CmdCause.Parameters.Add("@Num", textBox4.Text);
                    CmdCause.Parameters.Add("@NumP", textBox4.Text);
                    DrCasue = CmdCause.ExecuteReader();
                    
                    while (DrCasue.Read())
                    {
                        dataGridView4.Rows.Add(DrCasue[0].ToString(), DrCasue[1].ToString(), DrCasue[2].ToString(), DrCasue[3]);
                        
                    }
                    DrCasue.Close();
                    cnx.Close();
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                if (textBox5.Text=="")
                {
                    GetDataInPieceJointPlgnt();
                }
                else
                {
                    dataGridView5.Rows.Clear();
                    SqlCommand CmdPlgnt = new SqlCommand("SELECT * FROM [Depot_piece] where  [Num_File]  like @Num or  Num_Depot_piece like @NumP ", cnx);
                    SqlDataReader DrPlgnt;
                    CmdPlgnt.Parameters.Add("@Num", textBox5.Text);
                    CmdPlgnt.Parameters.Add("@NumP", textBox5.Text);
                    DrPlgnt = CmdPlgnt.ExecuteReader();
                    while (DrPlgnt.Read())
                    {

                        dataGridView5.Rows.Add(DrPlgnt[0].ToString(), DrPlgnt[1].ToString(), DrPlgnt[2].ToString(), DrPlgnt[3]);
                    }
                    DrPlgnt.Close();
                    cnx.Close();
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox6.Text == "")
                {
                    GetDataInPieceJointOrder();
                }
                else
                {
                    dataGridView6.Rows.Clear();
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                    SqlCommand CmdOrder = new SqlCommand("SELECT * FROM [Depot_piece] where  [Num_File] like @Num or Num_Depot_piece like @NumP ", cnx);
                    SqlDataReader DrOrder;
                    CmdOrder.Parameters.Add("@Num", textBox6.Text);
                    CmdOrder.Parameters.Add("@NumP", textBox6.Text);
                    DrOrder = CmdOrder.ExecuteReader();
                    while (DrOrder.Read())
                    {
                        
                        dataGridView6.Rows.Add(DrOrder[0].ToString(), DrOrder[1].ToString(), DrOrder[2].ToString(), DrOrder[3]);
                    }
                    DrOrder.Close();
                    cnx.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
