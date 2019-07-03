namespace AvocaBin
{
    partial class ادارة_موكلي_الامر
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ادارة_موكلي_الامر));
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label9 = new System.Windows.Forms.Label();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_remove = new DevExpress.XtraEditors.SimpleButton();
            this.btn_edit = new DevExpress.XtraEditors.SimpleButton();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id_client_order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type_client_order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.representant_legal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registre_commerce = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adresse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_nouveau = new DevExpress.XtraEditors.SimpleButton();
            this.btn_ajouter = new DevExpress.XtraEditors.SimpleButton();
            this.txb_tele = new System.Windows.Forms.TextBox();
            this.txb_adresse = new System.Windows.Forms.TextBox();
            this.txb_cin = new System.Windows.Forms.TextBox();
            this.txb_juridique = new System.Windows.Forms.TextBox();
            this.txb_name = new System.Windows.Forms.TextBox();
            this.txb_num_societe = new System.Windows.Forms.TextBox();
            this.txb_ident_client = new System.Windows.Forms.TextBox();
            this.txb_genre_client = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Appearance.Options.UseForeColor = true;
            this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.simpleButton2.Image = global::AvocaBin.Properties.Resources.Untitled_1_14;
            this.simpleButton2.Location = new System.Drawing.Point(282, 716);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(109, 37);
            this.simpleButton2.TabIndex = 52;
            this.simpleButton2.Text = "طباعة الكل";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.simpleButton1.Image = global::AvocaBin.Properties.Resources.Untitled_1_14;
            this.simpleButton1.Location = new System.Drawing.Point(181, 715);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(95, 37);
            this.simpleButton1.TabIndex = 51;
            this.simpleButton1.Text = "طباعة";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.label9.Location = new System.Drawing.Point(738, 232);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 19);
            this.label9.TabIndex = 47;
            this.label9.Text = "البحث بالاسم :";
            // 
            // simpleButton5
            // 
            this.simpleButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton5.Appearance.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton5.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.simpleButton5.Appearance.Options.UseFont = true;
            this.simpleButton5.Appearance.Options.UseForeColor = true;
            this.simpleButton5.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.simpleButton5.Image = global::AvocaBin.Properties.Resources.Untitled_1_13;
            this.simpleButton5.Location = new System.Drawing.Point(397, 715);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(161, 38);
            this.simpleButton5.TabIndex = 46;
            this.simpleButton5.Text = "ارسال الى الاكسل";
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // btn_remove
            // 
            this.btn_remove.Appearance.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_remove.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.btn_remove.Appearance.Options.UseFont = true;
            this.btn_remove.Appearance.Options.UseForeColor = true;
            this.btn_remove.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btn_remove.Image = global::AvocaBin.Properties.Resources.Untitled_1_17;
            this.btn_remove.Location = new System.Drawing.Point(12, 716);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(75, 36);
            this.btn_remove.TabIndex = 9;
            this.btn_remove.Text = "حدف";
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Appearance.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.btn_edit.Appearance.Options.UseFont = true;
            this.btn_edit.Appearance.Options.UseForeColor = true;
            this.btn_edit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btn_edit.Image = global::AvocaBin.Properties.Resources.Untitled_1_161;
            this.btn_edit.Location = new System.Drawing.Point(93, 716);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(82, 36);
            this.btn_edit.TabIndex = 8;
            this.btn_edit.Text = "تعديل";
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox8.Font = new System.Drawing.Font("Sultan Nahia", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(540, 230);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(254, 23);
            this.textBox8.TabIndex = 1;
            this.textBox8.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Sultan Nahia", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_client_order,
            this.type_client_order,
            this.cin,
            this.nom,
            this.telephone,
            this.representant_legal,
            this.registre_commerce,
            this.adresse});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.dataGridView1.Location = new System.Drawing.Point(17, 273);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Sultan Nahia", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1238, 423);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // id_client_order
            // 
            this.id_client_order.DataPropertyName = "id_client_order";
            this.id_client_order.FillWeight = 86.52004F;
            this.id_client_order.HeaderText = "المرحع";
            this.id_client_order.Name = "id_client_order";
            this.id_client_order.ReadOnly = true;
            // 
            // type_client_order
            // 
            this.type_client_order.DataPropertyName = "type_client_order";
            this.type_client_order.FillWeight = 86.52004F;
            this.type_client_order.HeaderText = "نوع الموكل";
            this.type_client_order.Name = "type_client_order";
            this.type_client_order.ReadOnly = true;
            // 
            // cin
            // 
            this.cin.DataPropertyName = "cin";
            this.cin.FillWeight = 86.52004F;
            this.cin.HeaderText = "البطاقة الوطنية";
            this.cin.Name = "cin";
            this.cin.ReadOnly = true;
            // 
            // nom
            // 
            this.nom.DataPropertyName = "nom";
            this.nom.FillWeight = 86.52004F;
            this.nom.HeaderText = "الإسم";
            this.nom.Name = "nom";
            this.nom.ReadOnly = true;
            // 
            // telephone
            // 
            this.telephone.DataPropertyName = "telephone";
            this.telephone.FillWeight = 86.52004F;
            this.telephone.HeaderText = "الهاتف";
            this.telephone.Name = "telephone";
            this.telephone.ReadOnly = true;
            // 
            // representant_legal
            // 
            this.representant_legal.DataPropertyName = "representant_legal";
            this.representant_legal.FillWeight = 86.52004F;
            this.representant_legal.HeaderText = "الممثل القانوني";
            this.representant_legal.Name = "representant_legal";
            this.representant_legal.ReadOnly = true;
            // 
            // registre_commerce
            // 
            this.registre_commerce.DataPropertyName = "registre_commerce";
            this.registre_commerce.FillWeight = 86.52004F;
            this.registre_commerce.HeaderText = "السجل التجاري";
            this.registre_commerce.Name = "registre_commerce";
            this.registre_commerce.ReadOnly = true;
            // 
            // adresse
            // 
            this.adresse.DataPropertyName = "adresse";
            this.adresse.FillWeight = 86.52004F;
            this.adresse.HeaderText = "العنوان";
            this.adresse.Name = "adresse";
            this.adresse.ReadOnly = true;
            // 
            // btn_nouveau
            // 
            this.btn_nouveau.Appearance.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nouveau.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.btn_nouveau.Appearance.Options.UseFont = true;
            this.btn_nouveau.Appearance.Options.UseForeColor = true;
            this.btn_nouveau.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btn_nouveau.Image = global::AvocaBin.Properties.Resources.Untitled_1_15;
            this.btn_nouveau.Location = new System.Drawing.Point(939, 175);
            this.btn_nouveau.Name = "btn_nouveau";
            this.btn_nouveau.Size = new System.Drawing.Size(101, 41);
            this.btn_nouveau.TabIndex = 5;
            this.btn_nouveau.Text = "جديد";
            this.btn_nouveau.Click += new System.EventHandler(this.btn_nouveau_Click);
            // 
            // btn_ajouter
            // 
            this.btn_ajouter.Appearance.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ajouter.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.btn_ajouter.Appearance.Options.UseFont = true;
            this.btn_ajouter.Appearance.Options.UseForeColor = true;
            this.btn_ajouter.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btn_ajouter.Image = global::AvocaBin.Properties.Resources.ok_01;
            this.btn_ajouter.Location = new System.Drawing.Point(1046, 175);
            this.btn_ajouter.Name = "btn_ajouter";
            this.btn_ajouter.Size = new System.Drawing.Size(105, 41);
            this.btn_ajouter.TabIndex = 4;
            this.btn_ajouter.Text = "اضافة";
            this.btn_ajouter.Click += new System.EventHandler(this.btn_ajouter_Click);
            // 
            // txb_tele
            // 
            this.txb_tele.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.txb_tele.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_tele.Font = new System.Drawing.Font("Sultan Nahia", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_tele.ForeColor = System.Drawing.Color.White;
            this.txb_tele.Location = new System.Drawing.Point(890, 134);
            this.txb_tele.Name = "txb_tele";
            this.txb_tele.Size = new System.Drawing.Size(196, 23);
            this.txb_tele.TabIndex = 2;
            // 
            // txb_adresse
            // 
            this.txb_adresse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.txb_adresse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_adresse.Font = new System.Drawing.Font("Sultan Nahia", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_adresse.ForeColor = System.Drawing.Color.White;
            this.txb_adresse.Location = new System.Drawing.Point(890, 65);
            this.txb_adresse.Multiline = true;
            this.txb_adresse.Name = "txb_adresse";
            this.txb_adresse.Size = new System.Drawing.Size(334, 57);
            this.txb_adresse.TabIndex = 2;
            // 
            // txb_cin
            // 
            this.txb_cin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.txb_cin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_cin.Font = new System.Drawing.Font("Sultan Nahia", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_cin.ForeColor = System.Drawing.Color.White;
            this.txb_cin.Location = new System.Drawing.Point(540, 128);
            this.txb_cin.Name = "txb_cin";
            this.txb_cin.Size = new System.Drawing.Size(196, 23);
            this.txb_cin.TabIndex = 2;
            // 
            // txb_juridique
            // 
            this.txb_juridique.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.txb_juridique.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_juridique.Font = new System.Drawing.Font("Sultan Nahia", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_juridique.ForeColor = System.Drawing.Color.White;
            this.txb_juridique.Location = new System.Drawing.Point(540, 94);
            this.txb_juridique.Name = "txb_juridique";
            this.txb_juridique.Size = new System.Drawing.Size(196, 23);
            this.txb_juridique.TabIndex = 2;
            // 
            // txb_name
            // 
            this.txb_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.txb_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_name.Font = new System.Drawing.Font("Sultan Nahia", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_name.ForeColor = System.Drawing.Color.White;
            this.txb_name.Location = new System.Drawing.Point(122, 131);
            this.txb_name.Name = "txb_name";
            this.txb_name.Size = new System.Drawing.Size(196, 23);
            this.txb_name.TabIndex = 2;
            // 
            // txb_num_societe
            // 
            this.txb_num_societe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.txb_num_societe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_num_societe.Font = new System.Drawing.Font("Sultan Nahia", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_num_societe.ForeColor = System.Drawing.Color.White;
            this.txb_num_societe.Location = new System.Drawing.Point(540, 60);
            this.txb_num_societe.Name = "txb_num_societe";
            this.txb_num_societe.Size = new System.Drawing.Size(196, 23);
            this.txb_num_societe.TabIndex = 2;
            // 
            // txb_ident_client
            // 
            this.txb_ident_client.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.txb_ident_client.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_ident_client.Font = new System.Drawing.Font("Sultan Nahia", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_ident_client.ForeColor = System.Drawing.Color.White;
            this.txb_ident_client.Location = new System.Drawing.Point(122, 93);
            this.txb_ident_client.Name = "txb_ident_client";
            this.txb_ident_client.Size = new System.Drawing.Size(196, 23);
            this.txb_ident_client.TabIndex = 2;
            // 
            // txb_genre_client
            // 
            this.txb_genre_client.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.txb_genre_client.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txb_genre_client.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txb_genre_client.Font = new System.Drawing.Font("Sultan Nahia", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_genre_client.ForeColor = System.Drawing.Color.White;
            this.txb_genre_client.FormattingEnabled = true;
            this.txb_genre_client.Items.AddRange(new object[] {
            "طبيعي",
            "معنوي"});
            this.txb_genre_client.Location = new System.Drawing.Point(122, 55);
            this.txb_genre_client.Name = "txb_genre_client";
            this.txb_genre_client.Size = new System.Drawing.Size(196, 23);
            this.txb_genre_client.TabIndex = 1;
            this.txb_genre_client.SelectedIndexChanged += new System.EventHandler(this.txb_genre_client_SelectedIndexChanged);
            this.txb_genre_client.TextChanged += new System.EventHandler(this.txb_genre_client_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.label8.Location = new System.Drawing.Point(759, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "رقم البطاقة الوطنية :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.label7.Location = new System.Drawing.Point(397, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "الهاتف :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.label4.Location = new System.Drawing.Point(1167, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "المرجع :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.label6.Location = new System.Drawing.Point(759, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "السجل التجاري :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.label3.Location = new System.Drawing.Point(759, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "الممثل القانوني :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.label5.Location = new System.Drawing.Point(397, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "العنوان :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.label2.Location = new System.Drawing.Point(1167, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "الاسم :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.label1.Location = new System.Drawing.Point(1167, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "نوع الموكل :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.label10.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(5, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 19);
            this.label10.TabIndex = 9;
            this.label10.Text = "X";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1273, 23);
            this.panel1.TabIndex = 24;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(596, 2);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label11.Size = new System.Drawing.Size(92, 19);
            this.label11.TabIndex = 24;
            this.label11.Text = "ادارة موكلي الامر";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::AvocaBin.Properties.Resources._31322fgf2_01;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1272, 768);
            this.panel2.TabIndex = 53;
            // 
            // ادارة_موكلي_الامر
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = global::AvocaBin.Properties.Resources._6_1__01;
            this.ClientSize = new System.Drawing.Size(1272, 768);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.btn_nouveau);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btn_ajouter);
            this.Controls.Add(this.simpleButton5);
            this.Controls.Add(this.btn_remove);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txb_tele);
            this.Controls.Add(this.txb_adresse);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.txb_cin);
            this.Controls.Add(this.txb_juridique);
            this.Controls.Add(this.txb_num_societe);
            this.Controls.Add(this.txb_name);
            this.Controls.Add(this.txb_genre_client);
            this.Controls.Add(this.txb_ident_client);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ادارة_موكلي_الامر";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ادارة موكلي الامر";
            this.Load += new System.EventHandler(this.ادارة_موكلي_الامر_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_remove;
        private DevExpress.XtraEditors.SimpleButton btn_edit;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevExpress.XtraEditors.SimpleButton btn_nouveau;
        private DevExpress.XtraEditors.SimpleButton btn_ajouter;
        private System.Windows.Forms.TextBox txb_tele;
        private System.Windows.Forms.TextBox txb_adresse;
        private System.Windows.Forms.TextBox txb_cin;
        private System.Windows.Forms.TextBox txb_juridique;
        private System.Windows.Forms.TextBox txb_name;
        private System.Windows.Forms.TextBox txb_num_societe;
        private System.Windows.Forms.ComboBox txb_genre_client;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_ident_client;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_client_order;
        private System.Windows.Forms.DataGridViewTextBoxColumn type_client_order;
        private System.Windows.Forms.DataGridViewTextBoxColumn cin;
        private System.Windows.Forms.DataGridViewTextBoxColumn nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn telephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn representant_legal;
        private System.Windows.Forms.DataGridViewTextBoxColumn registre_commerce;
        private System.Windows.Forms.DataGridViewTextBoxColumn adresse;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
    }
}