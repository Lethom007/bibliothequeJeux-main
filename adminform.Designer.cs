namespace repertJeux
{
    partial class adminform
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Titre = new System.Windows.Forms.Label();
            this.BtAjoutJeu = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtModifJeu = new System.Windows.Forms.Button();
            this.BtSuppJeu = new System.Windows.Forms.Button();
            this.txtTitre = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtNbrJoueursMin = new System.Windows.Forms.TextBox();
            this.txtNbrJoueursMax = new System.Windows.Forms.TextBox();
            this.txtCategorie = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 196);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(803, 463);
            this.dataGridView1.TabIndex = 0;
            // 
            // Titre
            // 
            this.Titre.AutoSize = true;
            this.Titre.Font = new System.Drawing.Font("Monotype Corsiva", 19.8F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titre.Location = new System.Drawing.Point(523, 45);
            this.Titre.Name = "Titre";
            this.Titre.Size = new System.Drawing.Size(216, 41);
            this.Titre.TabIndex = 1;
            this.Titre.Text = "Administration";
            // 
            // BtAjoutJeu
            // 
            this.BtAjoutJeu.BackColor = System.Drawing.Color.Cyan;
            this.BtAjoutJeu.Location = new System.Drawing.Point(861, 450);
            this.BtAjoutJeu.Name = "BtAjoutJeu";
            this.BtAjoutJeu.Size = new System.Drawing.Size(292, 36);
            this.BtAjoutJeu.TabIndex = 2;
            this.BtAjoutJeu.Text = "Ajouter un jeu";
            this.BtAjoutJeu.UseVisualStyleBackColor = false;
            this.BtAjoutJeu.Click += new System.EventHandler(this.BtAjoutJeu_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(388, 117);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(485, 27);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Recherche";
            // 
            // BtModifJeu
            // 
            this.BtModifJeu.BackColor = System.Drawing.Color.Yellow;
            this.BtModifJeu.Location = new System.Drawing.Point(861, 497);
            this.BtModifJeu.Name = "BtModifJeu";
            this.BtModifJeu.Size = new System.Drawing.Size(292, 36);
            this.BtModifJeu.TabIndex = 5;
            this.BtModifJeu.Text = "Modifier un jeu";
            this.BtModifJeu.UseVisualStyleBackColor = false;
            this.BtModifJeu.Click += new System.EventHandler(this.BtModifJeu_Click);
            // 
            // BtSuppJeu
            // 
            this.BtSuppJeu.BackColor = System.Drawing.Color.Red;
            this.BtSuppJeu.Location = new System.Drawing.Point(861, 545);
            this.BtSuppJeu.Name = "BtSuppJeu";
            this.BtSuppJeu.Size = new System.Drawing.Size(292, 36);
            this.BtSuppJeu.TabIndex = 6;
            this.BtSuppJeu.Text = "Supprimer un jeu";
            this.BtSuppJeu.UseVisualStyleBackColor = false;
            this.BtSuppJeu.Click += new System.EventHandler(this.BtSuppJeu_Click);
            // 
            // txtTitre
            // 
            this.txtTitre.Location = new System.Drawing.Point(861, 309);
            this.txtTitre.Name = "txtTitre";
            this.txtTitre.Size = new System.Drawing.Size(148, 22);
            this.txtTitre.TabIndex = 7;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(1013, 309);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(151, 22);
            this.txtDescription.TabIndex = 8;
            // 
            // txtNbrJoueursMin
            // 
            this.txtNbrJoueursMin.Location = new System.Drawing.Point(861, 346);
            this.txtNbrJoueursMin.Name = "txtNbrJoueursMin";
            this.txtNbrJoueursMin.Size = new System.Drawing.Size(151, 22);
            this.txtNbrJoueursMin.TabIndex = 9;
            // 
            // txtNbrJoueursMax
            // 
            this.txtNbrJoueursMax.Location = new System.Drawing.Point(1013, 346);
            this.txtNbrJoueursMax.Name = "txtNbrJoueursMax";
            this.txtNbrJoueursMax.Size = new System.Drawing.Size(148, 22);
            this.txtNbrJoueursMax.TabIndex = 10;
            // 
            // txtCategorie
            // 
            this.txtCategorie.Location = new System.Drawing.Point(941, 383);
            this.txtCategorie.Name = "txtCategorie";
            this.txtCategorie.Size = new System.Drawing.Size(152, 22);
            this.txtCategorie.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(850, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 22);
            this.label2.TabIndex = 12;
            this.label2.Text = "-Sélectionner un jeu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(850, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(338, 22);
            this.label3.TabIndex = 13;
            this.label3.Text = "-Modifier un (ou plus) champ puis cliquer \r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(850, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(312, 22);
            this.label4.TabIndex = 14;
            this.label4.Text = "-Cliquer sur supprimer pour supprimer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(853, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 22);
            this.label5.TabIndex = 15;
            this.label5.Text = "sur modifier";
            // 
            // adminform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 720);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCategorie);
            this.Controls.Add(this.txtNbrJoueursMax);
            this.Controls.Add(this.txtNbrJoueursMin);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtTitre);
            this.Controls.Add(this.BtSuppJeu);
            this.Controls.Add(this.BtModifJeu);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BtAjoutJeu);
            this.Controls.Add(this.Titre);
            this.Controls.Add(this.dataGridView1);
            this.Name = "adminform";
            this.Text = "adminform";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.adminform_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label Titre;
        private System.Windows.Forms.Button BtAjoutJeu;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BtModifJeu;
        private System.Windows.Forms.Button BtSuppJeu;
        private System.Windows.Forms.TextBox txtTitre;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtNbrJoueursMin;
        private System.Windows.Forms.TextBox txtNbrJoueursMax;
        private System.Windows.Forms.TextBox txtCategorie;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}