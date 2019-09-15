namespace BankProject
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Minimize = new System.Windows.Forms.Label();
            this.Kapat = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnYonetici = new System.Windows.Forms.Button();
            this.btnTicari = new System.Windows.Forms.Button();
            this.btnBireysel = new System.Windows.Forms.Button();
            this.btnFinansal = new System.Windows.Forms.Button();
            this.btnBankaBilgileri = new System.Windows.Forms.Button();
            this.lblBankaAdii = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.userControl51 = new BankProject.UserControl5();
            this.userControl41 = new BankProject.UserControl4();
            this.userControl31 = new BankProject.UserControl3();
            this.userControl21 = new BankProject.UserControl2();
            this.userControl11 = new BankProject.UserControl1();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.Minimize);
            this.panel1.Controls.Add(this.Kapat);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1147, 41);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.Location = new System.Drawing.Point(99, 7);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(35, 29);
            this.panel4.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.Location = new System.Drawing.Point(12, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(67, 34);
            this.panel3.TabIndex = 3;
            // 
            // Minimize
            // 
            this.Minimize.AutoSize = true;
            this.Minimize.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Minimize.Location = new System.Drawing.Point(1087, -3);
            this.Minimize.Name = "Minimize";
            this.Minimize.Size = new System.Drawing.Size(26, 38);
            this.Minimize.TabIndex = 2;
            this.Minimize.Text = "-";
            this.Minimize.Click += new System.EventHandler(this.label2_Click);
            // 
            // Kapat
            // 
            this.Kapat.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.Kapat.AutoSize = true;
            this.Kapat.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Kapat.Location = new System.Drawing.Point(1111, 4);
            this.Kapat.Name = "Kapat";
            this.Kapat.Size = new System.Drawing.Size(33, 32);
            this.Kapat.TabIndex = 0;
            this.Kapat.Text = "X";
            this.Kapat.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(110)))), ((int)(((byte)(213)))));
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.btnYonetici);
            this.panel2.Controls.Add(this.btnTicari);
            this.panel2.Controls.Add(this.btnBireysel);
            this.panel2.Controls.Add(this.btnFinansal);
            this.panel2.Controls.Add(this.btnBankaBilgileri);
            this.panel2.Location = new System.Drawing.Point(0, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 553);
            this.panel2.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(110)))), ((int)(((byte)(213)))));
            this.panel6.BackgroundImage = global::BankProject.Properties.Resources.iconnn1;
            this.panel6.Location = new System.Drawing.Point(3, -8);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(144, 10);
            this.panel6.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(110)))), ((int)(((byte)(213)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-56, 311);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 236);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(110)))), ((int)(((byte)(213)))));
            this.panel5.BackgroundImage = global::BankProject.Properties.Resources.iconnn1;
            this.panel5.Location = new System.Drawing.Point(3, 423);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(144, 127);
            this.panel5.TabIndex = 7;
            // 
            // btnYonetici
            // 
            this.btnYonetici.AllowDrop = true;
            this.btnYonetici.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnYonetici.FlatAppearance.BorderSize = 0;
            this.btnYonetici.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(110)))), ((int)(((byte)(213)))));
            this.btnYonetici.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(34)))), ((int)(((byte)(64)))));
            this.btnYonetici.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYonetici.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYonetici.ForeColor = System.Drawing.Color.White;
            this.btnYonetici.Location = new System.Drawing.Point(0, 220);
            this.btnYonetici.Name = "btnYonetici";
            this.btnYonetici.Size = new System.Drawing.Size(152, 41);
            this.btnYonetici.TabIndex = 4;
            this.btnYonetici.Text = "Yönetici";
            this.btnYonetici.UseVisualStyleBackColor = true;
            this.btnYonetici.Click += new System.EventHandler(this.btnYonetici_Click);
            this.btnYonetici.MouseLeave += new System.EventHandler(this.btnYonetici_MouseLeave);
            this.btnYonetici.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnYonetici_MouseMove);
            // 
            // btnTicari
            // 
            this.btnTicari.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTicari.FlatAppearance.BorderSize = 0;
            this.btnTicari.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(110)))), ((int)(((byte)(213)))));
            this.btnTicari.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(34)))), ((int)(((byte)(64)))));
            this.btnTicari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTicari.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTicari.ForeColor = System.Drawing.Color.White;
            this.btnTicari.Location = new System.Drawing.Point(0, 175);
            this.btnTicari.Name = "btnTicari";
            this.btnTicari.Size = new System.Drawing.Size(152, 41);
            this.btnTicari.TabIndex = 3;
            this.btnTicari.Text = "Ticari";
            this.btnTicari.UseVisualStyleBackColor = true;
            this.btnTicari.Click += new System.EventHandler(this.btnTicari_Click);
            this.btnTicari.MouseLeave += new System.EventHandler(this.btnYonetici_MouseLeave);
            this.btnTicari.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnYonetici_MouseMove);
            // 
            // btnBireysel
            // 
            this.btnBireysel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBireysel.FlatAppearance.BorderSize = 0;
            this.btnBireysel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(110)))), ((int)(((byte)(213)))));
            this.btnBireysel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(34)))), ((int)(((byte)(64)))));
            this.btnBireysel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBireysel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBireysel.ForeColor = System.Drawing.Color.White;
            this.btnBireysel.Location = new System.Drawing.Point(0, 130);
            this.btnBireysel.Name = "btnBireysel";
            this.btnBireysel.Size = new System.Drawing.Size(152, 41);
            this.btnBireysel.TabIndex = 2;
            this.btnBireysel.Text = "Bireysel";
            this.btnBireysel.UseVisualStyleBackColor = true;
            this.btnBireysel.Click += new System.EventHandler(this.btnBireysel_Click);
            this.btnBireysel.MouseLeave += new System.EventHandler(this.btnYonetici_MouseLeave);
            this.btnBireysel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnYonetici_MouseMove);
            // 
            // btnFinansal
            // 
            this.btnFinansal.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFinansal.FlatAppearance.BorderSize = 0;
            this.btnFinansal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(110)))), ((int)(((byte)(213)))));
            this.btnFinansal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(34)))), ((int)(((byte)(64)))));
            this.btnFinansal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinansal.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFinansal.ForeColor = System.Drawing.Color.White;
            this.btnFinansal.Location = new System.Drawing.Point(0, 85);
            this.btnFinansal.Name = "btnFinansal";
            this.btnFinansal.Size = new System.Drawing.Size(152, 41);
            this.btnFinansal.TabIndex = 1;
            this.btnFinansal.Text = "Finansal";
            this.btnFinansal.UseVisualStyleBackColor = true;
            this.btnFinansal.Click += new System.EventHandler(this.btnHosgeldiniz_Click);
            this.btnFinansal.MouseLeave += new System.EventHandler(this.btnYonetici_MouseLeave);
            this.btnFinansal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnYonetici_MouseMove);
            // 
            // btnBankaBilgileri
            // 
            this.btnBankaBilgileri.AllowDrop = true;
            this.btnBankaBilgileri.AutoSize = true;
            this.btnBankaBilgileri.CausesValidation = false;
            this.btnBankaBilgileri.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBankaBilgileri.FlatAppearance.BorderSize = 0;
            this.btnBankaBilgileri.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(110)))), ((int)(((byte)(213)))));
            this.btnBankaBilgileri.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(34)))), ((int)(((byte)(64)))));
            this.btnBankaBilgileri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBankaBilgileri.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBankaBilgileri.ForeColor = System.Drawing.Color.White;
            this.btnBankaBilgileri.Location = new System.Drawing.Point(0, 40);
            this.btnBankaBilgileri.Name = "btnBankaBilgileri";
            this.btnBankaBilgileri.Size = new System.Drawing.Size(152, 41);
            this.btnBankaBilgileri.TabIndex = 0;
            this.btnBankaBilgileri.Text = "Banka Bilgileri";
            this.btnBankaBilgileri.Click += new System.EventHandler(this.btnBankaBilgileri_Click);
            this.btnBankaBilgileri.MouseLeave += new System.EventHandler(this.btnYonetici_MouseLeave);
            this.btnBankaBilgileri.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnYonetici_MouseMove);
            // 
            // lblBankaAdii
            // 
            this.lblBankaAdii.AutoSize = true;
            this.lblBankaAdii.BackColor = System.Drawing.Color.White;
            this.lblBankaAdii.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBankaAdii.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblBankaAdii.Location = new System.Drawing.Point(498, 7);
            this.lblBankaAdii.Name = "lblBankaAdii";
            this.lblBankaAdii.Size = new System.Drawing.Size(0, 28);
            this.lblBankaAdii.TabIndex = 7;
            this.lblBankaAdii.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.lblBankaAdii.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.lblBankaAdii.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblBankaAdii_MouseUp);
            // 
            // userControl51
            // 
            this.userControl51.BackColor = System.Drawing.Color.White;
            this.userControl51.Location = new System.Drawing.Point(147, 41);
            this.userControl51.Name = "userControl51";
            this.userControl51.Size = new System.Drawing.Size(1000, 561);
            this.userControl51.TabIndex = 6;
            this.userControl51.Visible = false;
            // 
            // userControl41
            // 
            this.userControl41.BackColor = System.Drawing.Color.White;
            this.userControl41.Location = new System.Drawing.Point(147, 41);
            this.userControl41.Name = "userControl41";
            this.userControl41.Size = new System.Drawing.Size(1000, 601);
            this.userControl41.TabIndex = 5;
            this.userControl41.Visible = false;
            // 
            // userControl31
            // 
            this.userControl31.BackColor = System.Drawing.Color.White;
            this.userControl31.Location = new System.Drawing.Point(147, 41);
            this.userControl31.Name = "userControl31";
            this.userControl31.Size = new System.Drawing.Size(1000, 601);
            this.userControl31.TabIndex = 4;
            this.userControl31.Visible = false;
            // 
            // userControl21
            // 
            this.userControl21.BackColor = System.Drawing.Color.White;
            this.userControl21.Location = new System.Drawing.Point(147, 41);
            this.userControl21.Name = "userControl21";
            this.userControl21.Size = new System.Drawing.Size(1000, 601);
            this.userControl21.TabIndex = 3;
            this.userControl21.Visible = false;
            // 
            // userControl11
            // 
            this.userControl11.BackColor = System.Drawing.Color.White;
            this.userControl11.Location = new System.Drawing.Point(147, 41);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(1000, 601);
            this.userControl11.TabIndex = 2;
            this.userControl11.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(1145, 590);
            this.Controls.Add(this.lblBankaAdii);
            this.Controls.Add(this.userControl51);
            this.Controls.Add(this.userControl41);
            this.Controls.Add(this.userControl31);
            this.Controls.Add(this.userControl21);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Kapat;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label Minimize;
        private System.Windows.Forms.Button btnBireysel;
        private System.Windows.Forms.Button btnBankaBilgileri;
        private UserControl1 userControl11;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private UserControl2 userControl21;
        private UserControl4 userControl41;
        private UserControl3 userControl31;
        public UserControl5 userControl51;
        private System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Label lblBankaAdii;
        public System.Windows.Forms.Button btnTicari;
        public System.Windows.Forms.Button btnYonetici;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.Button btnFinansal;
    }
}

