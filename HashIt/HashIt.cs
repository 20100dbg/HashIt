using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Text;
using System.Collections.Generic;

namespace HashIt
{
    public partial class HashIt : Form
    {
        //https://www.mkpasswd.net/
        //https://www.browserling.com/tools/mysql-password


        public Boolean configShown = false;
        public String DraggedFile = "";
        String version = "1.1.0";
        String dateVersion = "25/02/2021";
        int tailleMaxAvertissement = 20;


        public HashIt()
        {
            InitializeComponent();

            Config.listEncodages.Add(new Encodage { Name = "Defaut", Enc = Encoding.Default });
            Config.listEncodages.Add(new Encodage { Name = "UTF8", Enc = Encoding.UTF8 });
            Config.listEncodages.Add(new Encodage { Name = "UTF16", Enc = Encoding.Unicode });
            Config.listEncodages.Add(new Encodage { Name = "Win Europe Ouest", Enc = Encoding.GetEncoding(1252) });
            Config.listEncodages.Add(new Encodage { Name = "ASCII", Enc = Encoding.ASCII });

            if (Settings.ReadConfigFile()) RefreshListboxAlgos();
            else MessageBox.Show("problème fichier de config");
            
            cb_useSalt.Items.AddRange(new String[] { "(none)", "$salt . $pass", "$pass . $salt", "$salt . $pass . $salt" });
            cb_useSalt.SelectedIndex = 0;


            //fctTest();
        }

        public void fctTest()
        {
            Param p = new Param { ValueToHash = "password" };

            CRC8.ComputeChecksum();

            string input = "8000";
            var bytes = Util.HexToBytes(input);
            string hex = CRC16.ComputeChecksum(bytes).ToString("x2");
            Console.WriteLine(hex); //c061

            CRC16_2 c = new CRC16_2(Crc16Mode.Standard);
        }
        

        public void RefreshListboxAlgos()
        {
            cblb_algos.Items.Clear();

            for (int i = 0; i < Config.listAlgos.Count; i++)
            {
                if (Config.listAlgos[i].ShowInList)
                {
                    cblb_algos.Items.Add(Config.listAlgos[i]);
                    if (Config.listAlgos[i].Selected) cblb_algos.SetItemChecked(cblb_algos.Items.Count - 1, true);
                }
            }
        }


        private void b_hashFile_Click(object sender, EventArgs e)
        {
            Clear();
            
            if (!File.Exists(DraggedFile)) return;

            if ((tailleMaxAvertissement * 1024 * 1024) <= new FileInfo(DraggedFile).Length)
            {
                DialogResult dr = MessageBox.Show("Attention fichier lourd. Continuer ?", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;
            }

            l_fichier.Text = Path.GetFileName(DraggedFile);


            List<String> algos = new List<string>();

            for (int i = 0; i < cblb_algos.CheckedItems.Count; i++)
                algos.Add(cblb_algos.CheckedItems[i].ToString());

            Dictionary<String, String>  dicAlgos = Work.HashFile(DraggedFile, algos);

            foreach (KeyValuePair<String, String> pair in dicAlgos)
                AddRow(pair.Key, pair.Value);

            Checksum();
        }


        private void b_hashText_Click(object sender, EventArgs e)
        {
            Clear();

            int saltUse = cb_useSalt.SelectedIndex;
            int nb = (int)nb_iterations.Value;
            String originalPassword = tb_texte.Text;
            String sel = tb_sel.Text;

            
            Param p = new Param
            {
                Iterations = nb,
                OriginalPassword = originalPassword,
                Salt = sel,
            };

            p.ApplySaltUse(saltUse);


            List<String> algos = new List<string>();

            for (int i = 0; i < cblb_algos.CheckedItems.Count; i++)
                algos.Add(cblb_algos.CheckedItems[i].ToString());


            Dictionary<String, String>  dicAlgos = Work.HashText(p, algos);

            foreach (KeyValuePair<String, String> pair in dicAlgos)
                AddRow(pair.Key, pair.Value);

            Checksum();
        }


        private void Checksum()
        {
            for (int i = 0; i < dgv_hashs.Rows.Count; i++)
            {
                if (dgv_hashs.Rows[i].Cells[1].Value.ToString() == tb_checksum.Text)
                {
                    tb_checksum.BackColor = Color.LightGreen;
                    dgv_hashs.Rows[i].Cells[1].Style.BackColor = Color.LightGreen;
                }
            }
        }

        public void Clear()
        {
            tb_checksum.BackColor = Color.White;
            dgv_hashs.Rows.Clear();
            l_fichier.Text = "Déposer un fichier";
            tb_checksum.Text = (Settings.OutputUppercase) ? tb_checksum.Text.ToUpper() : tb_checksum.Text.ToLower();
        }

        public void AddRow(String algo, String hash)
        {
            dgv_hashs.Rows.Add(new object[] { algo, hash });
        }

        private void paramètresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!configShown)
            {
                Config c = new Config(this);
                c.FormClosed += C_FormClosed;
                c.Show();
                configShown = true;
            }
        }

        private void C_FormClosed(object sender, FormClosedEventArgs e)
        {
            configShown = false;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("version " + version + "du " + dateVersion +
                            Environment.NewLine + Environment.NewLine +
                            "Utilise Hashlib 2.1.0.0, CryptSharp 2.1.0.0, WinHash, SHA3.Net, MD5crypt par Poul-Henning Kamp");
        }

        private void gb_fichier_DragDrop(object sender, DragEventArgs e)
        {
            String file = ((String[])e.Data.GetData(DataFormats.FileDrop))[0];
            DraggedFile = file;
            l_fichier.Text = Path.GetFileName(file);
        }

        private void gb_fichier_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void b_export_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Algo;Hash");

            for (int i = 0; i < dgv_hashs.Rows.Count; i++)
            {
                sb.AppendLine(dgv_hashs[0, i].Value.ToString() + ";" + dgv_hashs[1, i].Value.ToString());
            }

            Settings.WriteFile(sb.ToString(), "export_hashes.csv");
            MessageBox.Show("fichier export_hashes.csv sauvegardé");
        }

        private void cblb_algos_SelectedIndexChanged(object sender, EventArgs e)
        {
            l_descAlgo.Text = Config.listAlgos[cblb_algos.SelectedIndex].Description;
        }
    }
}