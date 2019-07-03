namespace AvocaBin
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabelCréerCompte = new System.Windows.Forms.LinkLabel();
            this.BtnConx = new DevExpress.XtraEditors.SimpleButton();
            this.txtbxPasse = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbxCIN = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dropDownButton1 = new DevExpress.XtraEditors.DropDownButton();
            this.dropDownButton2 = new DevExpress.XtraEditors.DropDownButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::AvocaBin.Properties.Resources._6_1__01;
            this.pictureBox1.Location = new System.Drawing.Point(122, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(251, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabelCréerCompte
            // 
            this.linkLabelCréerCompte.AutoSize = true;
            this.linkLabelCréerCompte.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelCréerCompte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.linkLabelCréerCompte.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.linkLabelCréerCompte.Location = new System.Drawing.Point(49, 295);
            this.linkLabelCréerCompte.Name = "linkLabelCréerCompte";
            this.linkLabelCréerCompte.Size = new System.Drawing.Size(66, 13);
            this.linkLabelCréerCompte.TabIndex = 16;
            this.linkLabelCréerCompte.TabStop = true;
            this.linkLabelCréerCompte.Text = "انشاء حساب";
            this.linkLabelCréerCompte.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCréerCompte_LinkClicked);
            // 
            // BtnConx
            // 
            this.BtnConx.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.BtnConx.Image = global::AvocaBin.Properties.Resources.ok_01;
            this.BtnConx.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnConx.Location = new System.Drawing.Point(327, 283);
            this.BtnConx.Name = "BtnConx";
            this.BtnConx.Size = new System.Drawing.Size(57, 38);
            this.BtnConx.TabIndex = 14;
            this.BtnConx.Click += new System.EventHandler(this.BtnConx_Click_1);
            // 
            // txtbxPasse
            // 
            this.txtbxPasse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.txtbxPasse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbxPasse.Font = new System.Drawing.Font("Sultan Nahia", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxPasse.ForeColor = System.Drawing.Color.White;
            this.txtbxPasse.Location = new System.Drawing.Point(49, 246);
            this.txtbxPasse.Name = "txtbxPasse";
            this.txtbxPasse.PasswordChar = '*';
            this.txtbxPasse.Size = new System.Drawing.Size(247, 23);
            this.txtbxPasse.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.label2.Location = new System.Drawing.Point(316, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "كلمة المرور :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.label1.Location = new System.Drawing.Point(316, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "رقم البطاقة الوطنية :";
            // 
            // txtbxCIN
            // 
            this.txtbxCIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.txtbxCIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbxCIN.Font = new System.Drawing.Font("Sultan Nahia", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxCIN.ForeColor = System.Drawing.Color.White;
            this.txtbxCIN.Location = new System.Drawing.Point(49, 204);
            this.txtbxCIN.Name = "txtbxCIN";
            this.txtbxCIN.Size = new System.Drawing.Size(247, 23);
            this.txtbxCIN.TabIndex = 9;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // dropDownButton1
            // 
            this.dropDownButton1.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Hide;
            this.dropDownButton1.Image = global::AvocaBin.Properties.Resources.Untitled_1_15;
            this.dropDownButton1.Location = new System.Drawing.Point(49, 204);
            this.dropDownButton1.Name = "dropDownButton1";
            this.dropDownButton1.Size = new System.Drawing.Size(28, 23);
            this.dropDownButton1.TabIndex = 19;
            this.dropDownButton1.Text = "dropDownButton1";
            this.dropDownButton1.Click += new System.EventHandler(this.dropDownButton1_Click);
            // 
            // dropDownButton2
            // 
            this.dropDownButton2.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Hide;
            this.dropDownButton2.Image = global::AvocaBin.Properties.Resources.Untitled_1_15;
            this.dropDownButton2.Location = new System.Drawing.Point(49, 245);
            this.dropDownButton2.Name = "dropDownButton2";
            this.dropDownButton2.Size = new System.Drawing.Size(28, 24);
            this.dropDownButton2.TabIndex = 20;
            this.dropDownButton2.Text = "dropDownButton2";
            this.dropDownButton2.Click += new System.EventHandler(this.dropDownButton2_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.linkLabel1.Location = new System.Drawing.Point(151, 295);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(83, 13);
            this.linkLabel1.TabIndex = 21;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "اعدادات السيرفر";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.label3.Font = new System.Drawing.Font("Sultan Nahia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "X";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(95)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 23);
            this.panel1.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::AvocaBin.Properties.Resources._3132_01;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.linkLabel1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.BtnConx);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.linkLabelCréerCompte);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(483, 347);
            this.panel2.TabIndex = 23;
            // 
            // Login
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 347);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dropDownButton2);
            this.Controls.Add(this.dropDownButton1);
            this.Controls.Add(this.txtbxPasse);
            this.Controls.Add(this.txtbxCIN);
            this.Controls.Add(this.panel2);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الدخول";
            this.Load += new System.EventHandler(this.Login_Load);
            this.Enter += new System.EventHandler(this.Login_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabelCréerCompte;
        private DevExpress.XtraEditors.SimpleButton BtnConx;
        private System.Windows.Forms.MaskedTextBox txtbxPasse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbxCIN;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private DevExpress.XtraEditors.DropDownButton dropDownButton1;
        private DevExpress.XtraEditors.DropDownButton dropDownButton2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;

    }
}