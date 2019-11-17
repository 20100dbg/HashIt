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
            this.Algo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_checksum = new System.Windows.Forms.TextBox();
            this.tb_texte = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.b_config = new System.Windows.Forms.Button();
            this.b_hash = new System.Windows.Forms.Button();
            this.tb_sel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nb_iterations = new System.Windows.Forms.NumericUpDown();
            this.cb_ForcerSel = new System.Windows.Forms.CheckBox();
            this.gb_fichier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hashs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_iterations)).BeginInit();
            this.SuspendLayout();
            // 
            // cblb_algos
            // 
            this.cblb_algos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cblb_algos.CheckOnClick = true;
            this.cblb_algos.FormattingEnabled = true;
            this.cblb_algos.Location = new System.Drawing.Point(9, 12);
            this.cblb_algos.Name = "cblb_algos";
            this.cblb_algos.Size = new System.Drawing.Size(146, 334);
            this.cblb_algos.TabIndex = 0;
            // 
            // gb_fichier
            // 
            this.gb_fichier.AllowDrop = true;
            this.gb_fichier.Controls.Add(this.l_fichier);
            this.gb_fichier.Location = new System.Drawing.Point(165, 12);
            this.gb_fichier.Name = "gb_fichier";
            this.gb_fichier.Size = new System.Drawing.Size(142, 65);
            this.gb_fichier.TabIndex = 1;
            this.gb_fichier.TabStop = false;
            this.gb_fichier.Text = "Fichier";
            this.gb_fichier.DragDrop += new System.Windows.Forms.DragEventHandler(this.gb_fichier_DragDrop);
            this.gb_fichier.DragEnter += new System.Windows.Forms.DragEventHandler(this.gb_fichier_DragEnter);
            // 
            // l_fichier
            // 
            this.l_fichier.AutoSize = true;
            this.l_fichier.Location = new System.Drawing.Point(6, 27);
            this.l_fichier.Name = "l_fichier";
            this.l_fichier.Size = new System.Drawing.Size(93, 13);
            this.l_fichier.TabIndex = 0;
            this.l_fichier.Text = "Déposer un fichier";
            // 
            // dgv_hashs
            // 
            this.dgv_hashs.AllowUserToAddRows = false;
            this.dgv_hashs.AllowUserToDeleteRows = false;
            this.dgv_hashs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_hashs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_hashs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Algo,
            this.Hash});
            this.dgv_hashs.Location = new System.Drawing.Point(165, 128);
            this.dgv_hashs.Name = "dgv_hashs";
            this.dgv_hashs.Size = new System.Drawing.Size(667, 244);
            this.dgv_hashs.TabIndex = 3;
            // 
            // Algo
            // 
            this.Algo.FillWeight = 30F;
            this.Algo.HeaderText = "Algo";
            this.Algo.Name = "Algo";
            // 
            // Hash
            // 
            this.Hash.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Hash.HeaderText = "Hash";
            this.Hash.Name = "Hash";
            // 
            // tb_checksum
            // 
            this.tb_checksum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_checksum.Location = new System.Drawing.Point(282, 102);
            this.tb_checksum.Name = "tb_checksum";
            this.tb_checksum.Size = new System.Drawing.Size(435, 20);
            this.tb_checksum.TabIndex = 4;
            // 
            // tb_texte
            // 
            this.tb_texte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_texte.Location = new System.Drawing.Point(373, 12);
            this.tb_texte.Multiline = true;
            this.tb_texte.Name = "tb_texte";
            this.tb_texte.Size = new System.Drawing.Size(344, 44);
            this.tb_texte.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(333, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Texte";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Checksum";
            // 
            // b_config
            // 
            this.b_config.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_config.Location = new System.Drawing.Point(9, 349);
            this.b_config.Name = "b_config";
            this.b_config.Size = new System.Drawing.Size(75, 23);
            this.b_config.TabIndex = 8;
            this.b_config.Text = "Configurer";
            this.b_config.UseVisualStyleBackColor = true;
            this.b_config.Click += new System.EventHandler(this.b_config_Click);
            // 
            // b_hash
            // 
            this.b_hash.Location = new System.Drawing.Point(757, 12);
            this.b_hash.Name = "b_hash";
            this.b_hash.Size = new System.Drawing.Size(75, 44);
            this.b_hash.TabIndex = 9;
            this.b_hash.Text = "Zou";
            this.b_hash.UseVisualStyleBackColor = true;
            this.b_hash.Click += new System.EventHandler(this.b_hash_Click);
            // 
            // tb_sel
            // 
            this.tb_sel.Location = new System.Drawing.Point(373, 62);
            this.tb_sel.Name = "tb_sel";
            this.tb_sel.Size = new System.Drawing.Size(100, 20);
            this.tb_sel.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(333, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Sel";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(607, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Itérations";
            // 
            // nb_iterations
            // 
            this.nb_iterations.Location = new System.Drawing.Point(663, 62);
            this.nb_iterations.Name = "nb_iterations";
            this.nb_iterations.Size = new System.Drawing.Size(54, 20);
            this.nb_iterations.TabIndex = 14;
            this.nb_iterations.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cb_ForcerSel
            // 
            this.cb_ForcerSel.AutoSize = true;
            this.cb_ForcerSel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cb_ForcerSel.Location = new System.Drawing.Point(479, 64);
            this.cb_ForcerSel.Name = "cb_ForcerSel";
            this.cb_ForcerSel.Size = new System.Drawing.Size(72, 17);
            this.cb_ForcerSel.TabIndex = 15;
            this.cb_ForcerSel.Text = "Forcer sel";
            this.cb_ForcerSel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cb_ForcerSel.UseVisualStyleBackColor = true;
            // 
            // HashIt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 384);
            this.Controls.Add(this.cb_ForcerSel);
            this.Controls.Add(this.nb_iterations);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_sel);
            this.Controls.Add(this.b_hash);
            this.Controls.Add(this.b_config);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_texte);
            this.Controls.Add(this.tb_checksum);
            this.Controls.Add(this.dgv_hashs);
            this.Controls.Add(this.gb_fichier);
            this.Controls.Add(this.cblb_algos);
            this.Name = "HashIt";
            this.Text = "HashIt";
            this.gb_fichier.ResumeLayout(false);
            this.gb_fichier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hashs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_iterations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox cblb_algos;
        private System.Windows.Forms.GroupBox gb_fichier;
        private System.Windows.Forms.DataGridView dgv_hashs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Algo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hash;
        private System.Windows.Forms.TextBox tb_checksum;
        private System.Windows.Forms.TextBox tb_texte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label l_fichier;
        private System.Windows.Forms.Button b_config;
        private System.Windows.Forms.Button b_hash;
        private System.Windows.Forms.TextBox tb_sel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nb_iterations;
        private System.Windows.Forms.CheckBox cb_ForcerSel;
    }
}

