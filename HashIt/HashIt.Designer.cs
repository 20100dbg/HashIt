namespace HashIt
{
    partial class HashIt
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.cblb_algos = new System.Windows.Forms.CheckedListBox();
            this.gb_fichier = new System.Windows.Forms.GroupBox();
            this.l_fichier = new System.Windows.Forms.Label();
            this.dgv_hashs = new System.Windows.Forms.DataGridView();
            this.colAlgo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_checksum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.b_hashFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_useSalt = new System.Windows.Forms.ComboBox();
            this.nb_iterations = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_sel = new System.Windows.Forms.TextBox();
            this.b_hashText = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_texte = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.paramètresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.b_export = new System.Windows.Forms.Button();
            this.l_descAlgo = new System.Windows.Forms.Label();
            this.gb_fichier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hashs)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nb_iterations)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cblb_algos
            // 
            this.cblb_algos.CheckOnClick = true;
            this.cblb_algos.FormattingEnabled = true;
            this.cblb_algos.Location = new System.Drawing.Point(12, 27);
            this.cblb_algos.Name = "cblb_algos";
            this.cblb_algos.Size = new System.Drawing.Size(175, 334);
            this.cblb_algos.TabIndex = 12;
            this.cblb_algos.SelectedIndexChanged += new System.EventHandler(this.cblb_algos_SelectedIndexChanged);
            // 
            // gb_fichier
            // 
            this.gb_fichier.AllowDrop = true;
            this.gb_fichier.Controls.Add(this.l_fichier);
            this.gb_fichier.Location = new System.Drawing.Point(218, 27);
            this.gb_fichier.Name = "gb_fichier";
            this.gb_fichier.Size = new System.Drawing.Size(142, 65);
            this.gb_fichier.TabIndex = 5;
            this.gb_fichier.TabStop = false;
            this.gb_fichier.Text = "Fichier";
            this.gb_fichier.DragDrop += new System.Windows.Forms.DragEventHandler(this.gb_fichier_DragDrop);
            this.gb_fichier.DragEnter += new System.Windows.Forms.DragEventHandler(this.gb_fichier_DragEnter);
            // 
            // l_fichier
            // 
            this.l_fichier.AutoSize = true;
            this.l_fichier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_fichier.Location = new System.Drawing.Point(6, 27);
            this.l_fichier.Name = "l_fichier";
            this.l_fichier.Size = new System.Drawing.Size(125, 15);
            this.l_fichier.TabIndex = 0;
            this.l_fichier.Text = "Déposer un fichier";
            // 
            // dgv_hashs
            // 
            this.dgv_hashs.AllowUserToAddRows = false;
            this.dgv_hashs.AllowUserToDeleteRows = false;
            this.dgv_hashs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_hashs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAlgo,
            this.colHash});
            this.dgv_hashs.Location = new System.Drawing.Point(214, 208);
            this.dgv_hashs.Name = "dgv_hashs";
            this.dgv_hashs.Size = new System.Drawing.Size(665, 183);
            this.dgv_hashs.TabIndex = 10;
            // 
            // colAlgo
            // 
            this.colAlgo.FillWeight = 30F;
            this.colAlgo.HeaderText = "Algo";
            this.colAlgo.Name = "colAlgo";
            // 
            // colHash
            // 
            this.colHash.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colHash.HeaderText = "Hash";
            this.colHash.Name = "colHash";
            // 
            // tb_checksum
            // 
            this.tb_checksum.Location = new System.Drawing.Point(278, 183);
            this.tb_checksum.Name = "tb_checksum";
            this.tb_checksum.Size = new System.Drawing.Size(509, 20);
            this.tb_checksum.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Checksum";
            // 
            // b_hashFile
            // 
            this.b_hashFile.Location = new System.Drawing.Point(251, 98);
            this.b_hashFile.Name = "b_hashFile";
            this.b_hashFile.Size = new System.Drawing.Size(71, 27);
            this.b_hashFile.TabIndex = 10;
            this.b_hashFile.Text = "Hash File";
            this.b_hashFile.UseVisualStyleBackColor = true;
            this.b_hashFile.Click += new System.EventHandler(this.b_hashFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_useSalt);
            this.groupBox1.Controls.Add(this.nb_iterations);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_sel);
            this.groupBox1.Controls.Add(this.b_hashText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_texte);
            this.groupBox1.Location = new System.Drawing.Point(379, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 142);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Texte";
            // 
            // cb_useSalt
            // 
            this.cb_useSalt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_useSalt.FormattingEnabled = true;
            this.cb_useSalt.Location = new System.Drawing.Point(140, 105);
            this.cb_useSalt.Name = "cb_useSalt";
            this.cb_useSalt.Size = new System.Drawing.Size(103, 21);
            this.cb_useSalt.TabIndex = 3;
            // 
            // nb_iterations
            // 
            this.nb_iterations.Location = new System.Drawing.Point(316, 106);
            this.nb_iterations.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nb_iterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nb_iterations.Name = "nb_iterations";
            this.nb_iterations.Size = new System.Drawing.Size(73, 20);
            this.nb_iterations.TabIndex = 4;
            this.nb_iterations.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Itérations";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sel";
            // 
            // tb_sel
            // 
            this.tb_sel.Location = new System.Drawing.Point(34, 105);
            this.tb_sel.Name = "tb_sel";
            this.tb_sel.Size = new System.Drawing.Size(100, 20);
            this.tb_sel.TabIndex = 2;
            // 
            // b_hashText
            // 
            this.b_hashText.Location = new System.Drawing.Point(416, 103);
            this.b_hashText.Name = "b_hashText";
            this.b_hashText.Size = new System.Drawing.Size(68, 23);
            this.b_hashText.TabIndex = 5;
            this.b_hashText.Text = "Hash text";
            this.b_hashText.UseVisualStyleBackColor = true;
            this.b_hashText.Click += new System.EventHandler(this.b_hashText_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Texte";
            // 
            // tb_texte
            // 
            this.tb_texte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_texte.Location = new System.Drawing.Point(9, 32);
            this.tb_texte.Multiline = true;
            this.tb_texte.Name = "tb_texte";
            this.tb_texte.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_texte.Size = new System.Drawing.Size(475, 62);
            this.tb_texte.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paramètresToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(891, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // paramètresToolStripMenuItem
            // 
            this.paramètresToolStripMenuItem.Name = "paramètresToolStripMenuItem";
            this.paramètresToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.paramètresToolStripMenuItem.Text = "Paramètres";
            this.paramètresToolStripMenuItem.Click += new System.EventHandler(this.paramètresToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // b_export
            // 
            this.b_export.Location = new System.Drawing.Point(804, 180);
            this.b_export.Name = "b_export";
            this.b_export.Size = new System.Drawing.Size(75, 23);
            this.b_export.TabIndex = 13;
            this.b_export.Text = "Exporter";
            this.b_export.UseVisualStyleBackColor = true;
            this.b_export.Click += new System.EventHandler(this.b_export_Click);
            // 
            // l_descAlgo
            // 
            this.l_descAlgo.AutoSize = true;
            this.l_descAlgo.Location = new System.Drawing.Point(12, 375);
            this.l_descAlgo.Name = "l_descAlgo";
            this.l_descAlgo.Size = new System.Drawing.Size(35, 13);
            this.l_descAlgo.TabIndex = 14;
            this.l_descAlgo.Text = "label5";
            // 
            // HashIt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 397);
            this.Controls.Add(this.l_descAlgo);
            this.Controls.Add(this.b_export);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.b_hashFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_checksum);
            this.Controls.Add(this.dgv_hashs);
            this.Controls.Add(this.gb_fichier);
            this.Controls.Add(this.cblb_algos);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HashIt";
            this.Text = "HashIt";
            this.gb_fichier.ResumeLayout(false);
            this.gb_fichier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hashs)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nb_iterations)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox cblb_algos;
        private System.Windows.Forms.GroupBox gb_fichier;
        private System.Windows.Forms.DataGridView dgv_hashs;
        private System.Windows.Forms.TextBox tb_checksum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label l_fichier;
        private System.Windows.Forms.Button b_hashFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cb_useSalt;
        private System.Windows.Forms.NumericUpDown nb_iterations;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_sel;
        private System.Windows.Forms.Button b_hashText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_texte;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem paramètresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlgo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHash;
        private System.Windows.Forms.Button b_export;
        private System.Windows.Forms.Label l_descAlgo;
    }
}

