namespace Neo4j
{
    partial class FormPlayer
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
            this.lblGoals = new System.Windows.Forms.Label();
            this.lblAssists = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.txtGolovi = new System.Windows.Forms.TextBox();
            this.txtAsistencije = new System.Windows.Forms.TextBox();
            this.txtPoeniPoUtakmici = new System.Windows.Forms.TextBox();
            this.txtUkupnoPoena = new System.Windows.Forms.TextBox();
            this.txtKlub = new System.Windows.Forms.TextBox();
            this.txtZutiKartoni = new System.Windows.Forms.TextBox();
            this.txtCrveniKartoni = new System.Windows.Forms.TextBox();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGoals
            // 
            this.lblGoals.AutoSize = true;
            this.lblGoals.Location = new System.Drawing.Point(23, 67);
            this.lblGoals.Name = "lblGoals";
            this.lblGoals.Size = new System.Drawing.Size(37, 13);
            this.lblGoals.TabIndex = 1;
            this.lblGoals.Text = "Golovi";
            // 
            // lblAssists
            // 
            this.lblAssists.AutoSize = true;
            this.lblAssists.Location = new System.Drawing.Point(22, 93);
            this.lblAssists.Name = "lblAssists";
            this.lblAssists.Size = new System.Drawing.Size(57, 13);
            this.lblAssists.TabIndex = 2;
            this.lblAssists.Text = "Asistencije";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ime";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Prezime";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Poeni po utakmici";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Ukupno poena";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Klub";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Zuti kartoni";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 229);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Crveni Kartoni";
            // 
            // txtIme
            // 
            this.txtIme.Enabled = false;
            this.txtIme.Location = new System.Drawing.Point(158, 14);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(100, 20);
            this.txtIme.TabIndex = 12;
            this.txtIme.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIme_KeyPress);
            // 
            // txtPrezime
            // 
            this.txtPrezime.Enabled = false;
            this.txtPrezime.Location = new System.Drawing.Point(158, 40);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(100, 20);
            this.txtPrezime.TabIndex = 13;
            this.txtPrezime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrezime_KeyPress);
            // 
            // txtGolovi
            // 
            this.txtGolovi.Location = new System.Drawing.Point(158, 64);
            this.txtGolovi.Name = "txtGolovi";
            this.txtGolovi.Size = new System.Drawing.Size(100, 20);
            this.txtGolovi.TabIndex = 14;
            this.txtGolovi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGolovi_KeyPress);
            // 
            // txtAsistencije
            // 
            this.txtAsistencije.Location = new System.Drawing.Point(158, 90);
            this.txtAsistencije.Name = "txtAsistencije";
            this.txtAsistencije.Size = new System.Drawing.Size(100, 20);
            this.txtAsistencije.TabIndex = 15;
            this.txtAsistencije.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAsistencije_KeyPress);
            // 
            // txtPoeniPoUtakmici
            // 
            this.txtPoeniPoUtakmici.Location = new System.Drawing.Point(158, 116);
            this.txtPoeniPoUtakmici.Name = "txtPoeniPoUtakmici";
            this.txtPoeniPoUtakmici.Size = new System.Drawing.Size(100, 20);
            this.txtPoeniPoUtakmici.TabIndex = 16;
            this.txtPoeniPoUtakmici.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPoeniPoUtakmici_KeyPress);
            // 
            // txtUkupnoPoena
            // 
            this.txtUkupnoPoena.Location = new System.Drawing.Point(158, 142);
            this.txtUkupnoPoena.Name = "txtUkupnoPoena";
            this.txtUkupnoPoena.Size = new System.Drawing.Size(100, 20);
            this.txtUkupnoPoena.TabIndex = 17;
            this.txtUkupnoPoena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUkupnoPoena_KeyPress);
            // 
            // txtKlub
            // 
            this.txtKlub.Enabled = false;
            this.txtKlub.Location = new System.Drawing.Point(158, 171);
            this.txtKlub.Name = "txtKlub";
            this.txtKlub.Size = new System.Drawing.Size(100, 20);
            this.txtKlub.TabIndex = 19;
            // 
            // txtZutiKartoni
            // 
            this.txtZutiKartoni.Location = new System.Drawing.Point(158, 200);
            this.txtZutiKartoni.Name = "txtZutiKartoni";
            this.txtZutiKartoni.Size = new System.Drawing.Size(100, 20);
            this.txtZutiKartoni.TabIndex = 20;
            this.txtZutiKartoni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtZutiKartoni_KeyPress);
            // 
            // txtCrveniKartoni
            // 
            this.txtCrveniKartoni.Location = new System.Drawing.Point(158, 229);
            this.txtCrveniKartoni.Name = "txtCrveniKartoni";
            this.txtCrveniKartoni.Size = new System.Drawing.Size(100, 20);
            this.txtCrveniKartoni.TabIndex = 21;
            this.txtCrveniKartoni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCrveniKartoni_KeyPress);
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.Location = new System.Drawing.Point(158, 279);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(100, 23);
            this.btnIzmeni.TabIndex = 22;
            this.btnIzmeni.Text = "Izmeni";
            this.btnIzmeni.UseVisualStyleBackColor = true;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
            // 
            // FormPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(277, 332);
            this.Controls.Add(this.btnIzmeni);
            this.Controls.Add(this.txtCrveniKartoni);
            this.Controls.Add(this.txtZutiKartoni);
            this.Controls.Add(this.txtKlub);
            this.Controls.Add(this.txtUkupnoPoena);
            this.Controls.Add(this.txtPoeniPoUtakmici);
            this.Controls.Add(this.txtAsistencije);
            this.Controls.Add(this.txtGolovi);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblAssists);
            this.Controls.Add(this.lblGoals);
            this.Name = "FormPlayer";
            this.Text = "FormPlayer";
            this.Load += new System.EventHandler(this.FormPlayer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblGoals;
        private System.Windows.Forms.Label lblAssists;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.TextBox txtGolovi;
        private System.Windows.Forms.TextBox txtAsistencije;
        private System.Windows.Forms.TextBox txtPoeniPoUtakmici;
        private System.Windows.Forms.TextBox txtUkupnoPoena;
        private System.Windows.Forms.TextBox txtKlub;
        private System.Windows.Forms.TextBox txtZutiKartoni;
        private System.Windows.Forms.TextBox txtCrveniKartoni;
        private System.Windows.Forms.Button btnIzmeni;
    }
}