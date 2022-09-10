namespace Registracija_i_Prijava.Forme
{
    partial class ZaboravljenaLozinka
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
            this.paneldrag = new System.Windows.Forms.Panel();
            this.labelNatrag = new System.Windows.Forms.Label();
            this.buttonVerificirajKod = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxKodPoslannaMail = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonPošaljinaMail = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.pictureBoxEmail = new System.Windows.Forms.PictureBox();
            this.labelZaboravljenaLozinka = new System.Windows.Forms.Label();
            this.pictureBoxLogoVIK = new System.Windows.Forms.PictureBox();
            this.paneldrag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogoVIK)).BeginInit();
            this.SuspendLayout();
            // 
            // paneldrag
            // 
            this.paneldrag.Controls.Add(this.labelNatrag);
            this.paneldrag.Controls.Add(this.buttonVerificirajKod);
            this.paneldrag.Controls.Add(this.panel2);
            this.paneldrag.Controls.Add(this.textBoxKodPoslannaMail);
            this.paneldrag.Controls.Add(this.pictureBox1);
            this.paneldrag.Controls.Add(this.buttonPošaljinaMail);
            this.paneldrag.Controls.Add(this.panel1);
            this.paneldrag.Controls.Add(this.textBoxEmail);
            this.paneldrag.Controls.Add(this.pictureBoxEmail);
            this.paneldrag.Controls.Add(this.labelZaboravljenaLozinka);
            this.paneldrag.Controls.Add(this.pictureBoxLogoVIK);
            this.paneldrag.Location = new System.Drawing.Point(1, -2);
            this.paneldrag.Name = "paneldrag";
            this.paneldrag.Size = new System.Drawing.Size(676, 703);
            this.paneldrag.TabIndex = 0;
            this.paneldrag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.paneldrag_MouseDown);
            this.paneldrag.MouseMove += new System.Windows.Forms.MouseEventHandler(this.paneldrag_MouseMove);
            this.paneldrag.MouseUp += new System.Windows.Forms.MouseEventHandler(this.paneldrag_MouseUp);
            // 
            // labelNatrag
            // 
            this.labelNatrag.AutoSize = true;
            this.labelNatrag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelNatrag.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNatrag.Location = new System.Drawing.Point(300, 657);
            this.labelNatrag.Name = "labelNatrag";
            this.labelNatrag.Size = new System.Drawing.Size(64, 22);
            this.labelNatrag.TabIndex = 98;
            this.labelNatrag.Text = "Natrag";
            this.labelNatrag.Click += new System.EventHandler(this.labelNatrag_Click);
            this.labelNatrag.MouseLeave += new System.EventHandler(this.labelNatrag_MouseLeave);
            this.labelNatrag.MouseHover += new System.EventHandler(this.labelNatrag_MouseHover);
            // 
            // buttonVerificirajKod
            // 
            this.buttonVerificirajKod.BackColor = System.Drawing.Color.DarkGray;
            this.buttonVerificirajKod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonVerificirajKod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonVerificirajKod.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonVerificirajKod.Location = new System.Drawing.Point(139, 565);
            this.buttonVerificirajKod.Name = "buttonVerificirajKod";
            this.buttonVerificirajKod.Size = new System.Drawing.Size(429, 64);
            this.buttonVerificirajKod.TabIndex = 97;
            this.buttonVerificirajKod.Text = "Verificiraj kod";
            this.buttonVerificirajKod.UseVisualStyleBackColor = false;
            this.buttonVerificirajKod.Click += new System.EventHandler(this.button1_Click);
            this.buttonVerificirajKod.MouseLeave += new System.EventHandler(this.buttonVerificirajKod_MouseLeave);
            this.buttonVerificirajKod.MouseHover += new System.EventHandler(this.buttonVerificirajKod_MouseHover);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(139, 534);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(429, 4);
            this.panel2.TabIndex = 96;
            // 
            // textBoxKodPoslannaMail
            // 
            this.textBoxKodPoslannaMail.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxKodPoslannaMail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxKodPoslannaMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxKodPoslannaMail.Location = new System.Drawing.Point(139, 482);
            this.textBoxKodPoslannaMail.Multiline = true;
            this.textBoxKodPoslannaMail.Name = "textBoxKodPoslannaMail";
            this.textBoxKodPoslannaMail.Size = new System.Drawing.Size(429, 53);
            this.textBoxKodPoslannaMail.TabIndex = 95;
            this.textBoxKodPoslannaMail.Text = "Kod poslan na E-mail";
            this.textBoxKodPoslannaMail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxKodPoslannaMail.Click += new System.EventHandler(this.textBoxKodPoslannaMail_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Registracija_i_Prijava.Properties.Resources.Verifikacija;
            this.pictureBox1.Location = new System.Drawing.Point(47, 482);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 94;
            this.pictureBox1.TabStop = false;
            // 
            // buttonPošaljinaMail
            // 
            this.buttonPošaljinaMail.BackColor = System.Drawing.Color.DarkGray;
            this.buttonPošaljinaMail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonPošaljinaMail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPošaljinaMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPošaljinaMail.Location = new System.Drawing.Point(139, 395);
            this.buttonPošaljinaMail.Name = "buttonPošaljinaMail";
            this.buttonPošaljinaMail.Size = new System.Drawing.Size(429, 64);
            this.buttonPošaljinaMail.TabIndex = 93;
            this.buttonPošaljinaMail.Text = "Pošalji na E-mail";
            this.buttonPošaljinaMail.UseVisualStyleBackColor = false;
            this.buttonPošaljinaMail.Click += new System.EventHandler(this.buttonPošaljinaMail_Click);
            this.buttonPošaljinaMail.MouseLeave += new System.EventHandler(this.buttonPošaljinaMail_MouseLeave);
            this.buttonPošaljinaMail.MouseHover += new System.EventHandler(this.buttonPošaljinaMail_MouseHover);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(139, 364);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 4);
            this.panel1.TabIndex = 74;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxEmail.Location = new System.Drawing.Point(139, 312);
            this.textBoxEmail.Multiline = true;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(429, 53);
            this.textBoxEmail.TabIndex = 73;
            this.textBoxEmail.Text = "E-mail";
            this.textBoxEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxEmail.Click += new System.EventHandler(this.textBoxEmail_Click);
            // 
            // pictureBoxEmail
            // 
            this.pictureBoxEmail.Image = global::Registracija_i_Prijava.Properties.Resources.E_mail2;
            this.pictureBoxEmail.Location = new System.Drawing.Point(47, 312);
            this.pictureBoxEmail.Name = "pictureBoxEmail";
            this.pictureBoxEmail.Size = new System.Drawing.Size(61, 56);
            this.pictureBoxEmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxEmail.TabIndex = 72;
            this.pictureBoxEmail.TabStop = false;
            // 
            // labelZaboravljenaLozinka
            // 
            this.labelZaboravljenaLozinka.AutoSize = true;
            this.labelZaboravljenaLozinka.Font = new System.Drawing.Font("Bauhaus 93", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelZaboravljenaLozinka.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelZaboravljenaLozinka.Location = new System.Drawing.Point(11, 205);
            this.labelZaboravljenaLozinka.Name = "labelZaboravljenaLozinka";
            this.labelZaboravljenaLozinka.Size = new System.Drawing.Size(611, 68);
            this.labelZaboravljenaLozinka.TabIndex = 5;
            this.labelZaboravljenaLozinka.Text = "Zaboravljena lozinka";
            // 
            // pictureBoxLogoVIK
            // 
            this.pictureBoxLogoVIK.Image = global::Registracija_i_Prijava.Properties.Resources.vik;
            this.pictureBoxLogoVIK.Location = new System.Drawing.Point(252, 14);
            this.pictureBoxLogoVIK.Name = "pictureBoxLogoVIK";
            this.pictureBoxLogoVIK.Size = new System.Drawing.Size(179, 165);
            this.pictureBoxLogoVIK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogoVIK.TabIndex = 4;
            this.pictureBoxLogoVIK.TabStop = false;
            this.pictureBoxLogoVIK.Click += new System.EventHandler(this.pictureBoxLogoVIK_Click);
            // 
            // ZaboravljenaLozinka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 700);
            this.Controls.Add(this.paneldrag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ZaboravljenaLozinka";
            this.Text = "ZaboravljenaLozinka";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ZaboravljenaLozinka_KeyDown);
            this.paneldrag.ResumeLayout(false);
            this.paneldrag.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogoVIK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel paneldrag;
        private System.Windows.Forms.Label labelZaboravljenaLozinka;
        private System.Windows.Forms.PictureBox pictureBoxLogoVIK;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.PictureBox pictureBoxEmail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonVerificirajKod;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxKodPoslannaMail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonPošaljinaMail;
        private System.Windows.Forms.Label labelNatrag;
    }
}