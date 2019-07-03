using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AvocaBin.Operation;
using AvocaBin.Models.Plaintes;
using AvocaBin.Models;
using System.Data.SqlClient;

namespace AvocaBin.Controller
{
    public partial class plainteArchivé : Form
    {
        PlaintesOperations op;
        SqlCommand cmd;
        SqlConnection cn = connection.getConnection();
        public plainteArchivé()
        {
            InitializeComponent();
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
        private void plainteArchivé_Load(object sender, EventArgs e)
        {
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Sultan Nahia", 12));
            getDataTable();
        }
        public void getDataTable()
         {
            dataGridView1.Rows.Clear();
            op = new PlaintesOperations();

            List<Plainte> plaintes = op.getAllPlanteArchivé();
            foreach (Plainte pp in plaintes)
            {
                try
                {
                    dataGridView1.Rows.Add(pp.Num_archive,pp.IdPlainte,pp.DateCreation,pp.TypeTribunal,pp.TypePlaint);
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
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                String idplainte = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                Plainte p = op.getPlanteArchiveById(idplainte).First();
                Plaignant plaignant = op.getPlaignantByCinAndId(p.IdPlaignant.ToString()).First();
                List<PlainteParPlaignant> ppp = op.getPlainteParPlaintes(p.IdPlainte);
                dataGridView2.Rows.Clear();
                foreach (var par in getParplaintes(ppp))
                {
                    dataGridView2.Rows.Add(par.IdParPlaignant, par.Nom, par.TypeParPlaignant);
                }
                lblnom.Text = plaignant.Nom;
                lbltype.Text = plaignant.TypePlaignant;
                //textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void simpleButtonSupprimer_Click(object sender, EventArgs e)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }







            if (dataGridView1.Rows.Count>0)
            {
                cmd = new SqlCommand("update plainte set etat='non archivé',num_archive=NULL where id_plainte='" + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "'", cn);
                cmd.ExecuteNonQuery();
                getDataTable();

                lblnom.Text = "...";
                lbltype.Text = "...";
                dataGridView2.Rows.Clear();
                MessageBox.Show("تم الارجاع بنجاح");
            }
            else
            {

            }
                
           
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            PrintAllPlainteArchivé f = new PrintAllPlainteArchivé();
            f.Show();
        }

        private void btnImpr_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                String idplaint = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                Form2 f = new Form2(idplaint);

                f.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            op = new PlaintesOperations();
            dataGridView1.Rows.Clear();
            List<Plainte> plaintes = op.getPlanteArchiveById(textBox1.Text);
            foreach (Plainte pp in plaintes)
            {
                try
                {
                    dataGridView1.Rows.Add(pp.Num_archive, pp.IdPlainte, pp.DateCreation, pp.TypeTribunal, pp.TypePlaint);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void simpleButtonModification_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
