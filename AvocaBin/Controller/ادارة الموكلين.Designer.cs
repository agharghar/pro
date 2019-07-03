namespace AvocaBin
{
    partial class ادارة_الموكلين
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ادارة_الموكلين));
            this.dropDownButton2 = new DevExpress.XtraEditors.DropDownButton();
            this.label9 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_imprimer_all = new DevExpress.XtraEditors.SimpleButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_imprimer = new DevExpress.XtraEditors.SimpleButton();
            this.btn_remove = new DevExpress.XtraEditors.SimpleButton();
            this.btn_edit = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type_client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.representant_legal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registre_commerce = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adresse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txb_genre_client = new System.Windows.Forms.ComboBox();
            this.txb_num_societe = new System.Windows.Forms.TextBox();
            this.txb_name = new System.Windows.Forms.TextBox();
            this.txb_juridique = new System.Windows.Forms.TextBox();
            this.txb_cin = new System.Windows.Forms.TextBox();
            this.txb_adresse = new System.Windows.Forms.TextBox();
            this.txb_tele = new System.Windows.Forms.TextBox();
            this.btn_nouveau = new DevExpress.XtraEditors.SimpleButton();
            this.btn_ajouter = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dropDownButton2
            // 
            this.dropDownButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.dropDownButton2.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Hide;
            this.dropDownButton2.Image = global::AvocaBin.Properties.Resources.Untitled_1_15;
            this.dropDownButton2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.dropDownButton2.Location = new System.Drawing.Point(832, 253);
            this.dropDownButton2.Name = "dropDownButton2";
            this.dropDownButton2.Size = new System.Drawing.Size(58, 21);
            this.dropDownButton2.TabIndex = 51;
            this.dropDownButton2.Click += new System.EventHandler(this.dropDownButton2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.label9.Location = new System.Drawing.Point(685, 254);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(270, 19);
            this.label9.TabIndex = 50;
            this.label9.Text = "البحث بالاسم, رقم البطاقة الوطنية او مرجع الموكل :";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.simpleButton1.Image = global::AvocaBin.Properties.Resources.Untitled_1_13;
            this.simpleButton1.Location = new System.Drawing.Point(416, 651);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(199, 38);
            this.simpleButton1.TabIndex = 13;
            this.simpleButton1.Text = "ارسال الموكلين الى الاكسل";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btn_imprimer_all
            // 
            this.btn_imprimer_all.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_imprimer_all.Appearance.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_imprimer_all.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.btn_imprimer_all.Appearance.Options.UseFont = true;
            this.btn_imprimer_all.Appearance.Options.UseForeColor = true;
            this.btn_imprimer_all.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btn_imprimer_all.Image = global::AvocaBin.Properties.Resources.Untitled_1_14;
            this.btn_imprimer_all.Location = new System.Drawing.Point(303, 651);
            this.btn_imprimer_all.Name = "btn_imprimer_all";
            this.btn_imprimer_all.Size = new System.Drawing.Size(105, 38);
            this.btn_imprimer_all.TabIndex = 12;
            this.btn_imprimer_all.Text = "طباعة الكل";
            this.btn_imprimer_all.Click += new System.EventHandler(this.btn_imprimer_all_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(479, 253);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(359, 21);
            this.textBox1.TabIndex = 11;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btn_imprimer
            // 
            this.btn_imprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_imprimer.Appearance.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_imprimer.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.btn_imprimer.Appearance.Options.UseFont = true;
            this.btn_imprimer.Appearance.Options.UseForeColor = true;
            this.btn_imprimer.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btn_imprimer.Image = global::AvocaBin.Properties.Resources.Untitled_1_14;
            this.btn_imprimer.Location = new System.Drawing.Point(215, 651);
            this.btn_imprimer.Name = "btn_imprimer";
            this.btn_imprimer.Size = new System.Drawing.Size(82, 38);
            this.btn_imprimer.TabIndex = 10;
            this.btn_imprimer.Text = "طباعة";
            this.btn_imprimer.Click += new System.EventHandler(this.btn_imprimer_Click);
            // 
            // btn_remove
            // 
            this.btn_remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_remove.Appearance.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_remove.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.btn_remove.Appearance.Options.UseFont = true;
            this.btn_remove.Appearance.Options.UseForeColor = true;
            this.btn_remove.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btn_remove.Image = global::AvocaBin.Properties.Resources.Untitled_1_17;
            this.btn_remove.Location = new System.Drawing.Point(127, 651);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(82, 38);
            this.btn_remove.TabIndex = 9;
            this.btn_remove.Text = "حدف";
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_edit.Appearance.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.btn_edit.Appearance.Options.UseFont = true;
            this.btn_edit.Appearance.Options.UseForeColor = true;
            this.btn_edit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btn_edit.Image = global::AvocaBin.Properties.Resources.Untitled_1_161;
            this.btn_edit.Location = new System.Drawing.Point(39, 651);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(82, 38);
            this.btn_edit.TabIndex = 8;
            this.btn_edit.Text = "تعديل";
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.nom,
            this.type_client,
            this.cin,
            this.representant_legal,
            this.registre_commerce,
            this.telephone,
            this.adresse});
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.dataGridView1.Location = new System.Drawing.Point(39, 289);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Sultan Nahia", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1076, 352);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "مرجعنا";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // nom
            // 
            this.nom.HeaderText = "الاسم";
            this.nom.Name = "nom";
            this.nom.ReadOnly = true;
            // 
            // type_client
            // 
            this.type_client.HeaderText = "نوع الموكل";
            this.type_client.Name = "type_client";
            this.type_client.ReadOnly = true;
            // 
            // cin
            // 
            this.cin.HeaderText = "ر.ب.و او مرجع الموكل";
            this.cin.Name = "cin";
            this.cin.ReadOnly = true;
            // 
            // representant_legal
            // 
            this.representant_legal.HeaderText = "الممثل القانوني";
            this.representant_legal.Name = "representant_legal";
            this.representant_legal.ReadOnly = true;
            // 
            // registre_commerce
            // 
            this.registre_commerce.HeaderText = "السجل التجاري";
            this.registre_commerce.Name = "registre_commerce";
            this.registre_commerce.ReadOnly = true;
            // 
            // telephone
            // 
            this.telephone.HeaderText = "الهاتف";
            this.telephone.Name = "telephone";
            this.telephone.ReadOnly = true;
            // 
            // adresse
            // 
            this.adresse.HeaderText = "العنوان";
            this.adresse.Name = "adresse";
            this.adresse.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.label1.Location = new System.Drawing.Point(1055, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "نوع الموكل :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.label2.Location = new System.Drawing.Point(1058, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "الاسم :";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.label5.Location = new System.Drawing.Point(1058, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "العنوان :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.label3.Location = new System.Drawing.Point(293, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "الممثل القانوني :";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.label6.Location = new System.Drawing.Point(622, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "السجل التجاري :";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.label7.Location = new System.Drawing.Point(293, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "الهاتف :";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.label8.Location = new System.Drawing.Point(626, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "رقم البطاقة الوطنية :";
            // 
            // txb_genre_client
            // 
            this.txb_genre_client.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_genre_client.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.txb_genre_client.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txb_genre_client.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txb_genre_client.Font = new System.Drawing.Font("Sultan Nahia", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_genre_client.ForeColor = System.Drawing.Color.White;
            this.txb_genre_client.FormattingEnabled = true;
            this.txb_genre_client.Items.AddRange(new object[] {
            "طبيعي",
            "معنوي"});
            this.txb_genre_client.Location = new System.Drawing.Point(109, 60);
            this.txb_genre_client.Name = "txb_genre_client";
            this.txb_genre_client.Size = new System.Drawing.Size(214, 23);
            this.txb_genre_client.TabIndex = 1;
            this.txb_genre_client.SelectedIndexChanged += new System.EventHandler(this.txb_genre_client_SelectedIndexChanged);
            // 
            // txb_num_societe
            // 
            this.txb_num_societe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_num_societe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.txb_num_societe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_num_societe.Enabled = false;
            this.txb_num_societe.Font = new System.Drawing.Font("Sultan Nahia", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_num_societe.ForeColor = System.Drawing.Color.White;
            this.txb_num_societe.Location = new System.Drawing.Point(549, 61);
            this.txb_num_societe.Name = "txb_num_societe";
            this.txb_num_societe.Size = new System.Drawing.Size(196, 23);
            this.txb_num_societe.TabIndex = 2;
            // 
            // txb_name
            // 
            this.txb_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.txb_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_name.Enabled = false;
            this.txb_name.Font = new System.Drawing.Font("Sultan Nahia", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_name.ForeColor = System.Drawing.Color.White;
            this.txb_name.Location = new System.Drawing.Point(109, 107);
            this.txb_name.Name = "txb_name";
            this.txb_name.Size = new System.Drawing.Size(214, 23);
            this.txb_name.TabIndex = 2;
            // 
            // txb_juridique
            // 
            this.txb_juridique.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_juridique.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.txb_juridique.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_juridique.Enabled = false;
            this.txb_juridique.Font = new System.Drawing.Font("Sultan Nahia", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_juridique.ForeColor = System.Drawing.Color.White;
            this.txb_juridique.Location = new System.Drawing.Point(874, 61);
            this.txb_juridique.Name = "txb_juridique";
            this.txb_juridique.Size = new System.Drawing.Size(245, 23);
            this.txb_juridique.TabIndex = 2;
            // 
            // txb_cin
            // 
            this.txb_cin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_cin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.txb_cin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_cin.Enabled = false;
            this.txb_cin.Font = new System.Drawing.Font("Sultan Nahia", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_cin.ForeColor = System.Drawing.Color.White;
            this.txb_cin.Location = new System.Drawing.Point(549, 108);
            this.txb_cin.Name = "txb_cin";
            this.txb_cin.Size = new System.Drawing.Size(196, 23);
            this.txb_cin.TabIndex = 2;
            // 
            // txb_adresse
            // 
            this.txb_adresse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_adresse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.txb_adresse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_adresse.Enabled = false;
            this.txb_adresse.Font = new System.Drawing.Font("Sultan Nahia", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_adresse.ForeColor = System.Drawing.Color.White;
            this.txb_adresse.Location = new System.Drawing.Point(109, 151);
            this.txb_adresse.Multiline = true;
            this.txb_adresse.Name = "txb_adresse";
            this.txb_adresse.Size = new System.Drawing.Size(581, 65);
            this.txb_adresse.TabIndex = 2;
            // 
            // txb_tele
            // 
            this.txb_tele.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_tele.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.txb_tele.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_tele.Enabled = false;
            this.txb_tele.Font = new System.Drawing.Font("Sultan Nahia", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_tele.ForeColor = System.Drawing.Color.White;
            this.txb_tele.Location = new System.Drawing.Point(874, 108);
            this.txb_tele.Name = "txb_tele";
            this.txb_tele.Size = new System.Drawing.Size(245, 23);
            this.txb_tele.TabIndex = 2;
            // 
            // btn_nouveau
            // 
            this.btn_nouveau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_nouveau.Appearance.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nouveau.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.btn_nouveau.Appearance.Options.UseFont = true;
            this.btn_nouveau.Appearance.Options.UseForeColor = true;
            this.btn_nouveau.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btn_nouveau.Image = global::AvocaBin.Properties.Resources.Untitled_1_15;
            this.btn_nouveau.Location = new System.Drawing.Point(874, 161);
            this.btn_nouveau.Name = "btn_nouveau";
            this.btn_nouveau.Size = new System.Drawing.Size(127, 38);
            this.btn_nouveau.TabIndex = 5;
            this.btn_nouveau.Text = "جديد";
            this.btn_nouveau.Click += new System.EventHandler(this.btn_nouveau_Click);
            // 
            // btn_ajouter
            // 
            this.btn_ajouter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ajouter.Appearance.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ajouter.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.btn_ajouter.Appearance.Options.UseFont = true;
            this.btn_ajouter.Appearance.Options.UseForeColor = true;
            this.btn_ajouter.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btn_ajouter.Image = global::AvocaBin.Properties.Resources.ok_01;
            this.btn_ajouter.Location = new System.Drawing.Point(1007, 161);
            this.btn_ajouter.Name = "btn_ajouter";
            this.btn_ajouter.Size = new System.Drawing.Size(108, 38);
            this.btn_ajouter.TabIndex = 4;
            this.btn_ajouter.Text = "اضافة";
            this.btn_ajouter.Click += new System.EventHandler(this.btn_ajouter_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.label4.Location = new System.Drawing.Point(625, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "مرجع الموكل :";
            this.label4.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1159, 23);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.label10.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(4, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 19);
            this.label10.TabIndex = 2;
            this.label10.Text = "X";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(539, 2);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label11.Size = new System.Drawing.Size(78, 19);
            this.label11.TabIndex = 24;
            this.label11.Text = "ادارة الموكلين";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::AvocaBin.Properties.Resources._31322fgf2_01;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1158, 711);
            this.panel2.TabIndex = 52;
            // 
            // ادارة_الموكلين
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 711);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btn_imprimer_all);
            this.Controls.Add(this.dropDownButton2);
            this.Controls.Add(this.btn_imprimer);
            this.Controls.Add(this.btn_nouveau);
            this.Controls.Add(this.btn_remove);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_ajouter);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txb_tele);
            this.Controls.Add(this.txb_juridique);
            this.Controls.Add(this.txb_cin);
            this.Controls.Add(this.txb_adresse);
            this.Controls.Add(this.txb_num_societe);
            this.Controls.Add(this.txb_name);
            this.Controls.Add(this.txb_genre_client);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ادارة_الموكلين";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ادارة الموكلين";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ادارة_الموكلين_FormClosed);
            this.Load += new System.EventHandler(this.ادارة_الموكلين_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox txb_genre_client;
        private System.Windows.Forms.TextBox txb_num_societe;
        private System.Windows.Forms.TextBox txb_name;
        private System.Windows.Forms.TextBox txb_juridique;
        private System.Windows.Forms.TextBox txb_cin;
        private System.Windows.Forms.TextBox txb_adresse;
        private System.Windows.Forms.TextBox txb_tele;
        private DevExpress.XtraEditors.SimpleButton btn_ajouter;
        private DevExpress.XtraEditors.SimpleButton btn_nouveau;
        private DevExpress.XtraEditors.SimpleButton btn_edit;
        private DevExpress.XtraEditors.SimpleButton btn_remove;
        private DevExpress.XtraEditors.SimpleButton btn_imprimer;
        private System.Windows.Forms.TextBox textBox1;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.SimpleButton btn_imprimer_all;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn type_client;
        private System.Windows.Forms.DataGridViewTextBoxColumn cin;
        private System.Windows.Forms.DataGridViewTextBoxColumn representant_legal;
        private System.Windows.Forms.DataGridViewTextBoxColumn registre_commerce;
        private System.Windows.Forms.DataGridViewTextBoxColumn telephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn adresse;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.DropDownButton dropDownButton2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
    }
}