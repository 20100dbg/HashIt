namespace HashIt
{
    partial class Config
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
            this.b_save = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.cb_encoding = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_outputUppercase = new System.Windows.Forms.CheckBox();
            this.Algo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.show = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Texte = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Fichier = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // b_save
            // 
            this.b_save.Location = new System.Drawing.Point(628, 278);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(106, 29);
            this.b_save.TabIndex = 12;
            this.b_save.Text = "Sauver et fermer";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Algo,
            this.Description,
            this.show,
            this.select,
            this.Texte,
            this.Fichier});
            this.dataGridView2.Location = new System.Drawing.Point(10, 53);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView2.Size = new System.Drawing.Size(731, 219);
            this.dataGridView2.TabIndex = 14;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // cb_encoding
            // 
            this.cb_encoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_encoding.FormattingEnabled = true;
            this.cb_encoding.Location = new System.Drawing.Point(95, 12);
            this.cb_encoding.Name = "cb_encoding";
            this.cb_encoding.Size = new System.Drawing.Size(121, 21);
            this.cb_encoding.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Encodage texte";
            // 
            // cb_outputUppercase
            // 
            this.cb_outputUppercase.AutoSize = true;
            this.cb_outputUppercase.Location = new System.Drawing.Point(278, 14);
            this.cb_outputUppercase.Name = "cb_outputUppercase";
            this.cb_outputUppercase.Size = new System.Drawing.Size(121, 17);
            this.cb_outputUppercase.TabIndex = 18;
            this.cb_outputUppercase.Text = "Hash en majuscules";
            this.cb_outputUppercase.UseVisualStyleBackColor = true;
            // 
            // Algo
            // 
            this.Algo.HeaderText = "Algo";
            this.Algo.Name = "Algo";
            this.Algo.Width = 140;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.Width = 200;
            // 
            // show
            // 
            this.show.HeaderText = "Afficher";
            this.show.Name = "show";
            this.show.Width = 80;
            // 
            // select
            // 
            this.select.HeaderText = "Présélectionner";
            this.select.Name = "select";
            this.select.Width = 80;
            // 
            // Texte
            // 
            this.Texte.HeaderText = "Texte";
            this.Texte.Name = "Texte";
            this.Texte.ReadOnly = true;
            this.Texte.Width = 80;
            // 
            // Fichier
            // 
            this.Fichier.HeaderText = "Fichier";
            this.Fichier.Name = "Fichier";
            this.Fichier.ReadOnly = true;
            this.Fichier.Width = 80;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 319);
            this.Controls.Add(this.cb_outputUppercase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_encoding);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.b_save);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Config";
            this.Text = "Config";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox cb_encoding;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_outputUppercase;
        private System.Windows.Forms.DataGridViewTextBoxColumn Algo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewCheckBoxColumn show;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Texte;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Fichier;
    }
}