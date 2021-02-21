using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Reflection;
using System.Text;
using HashLib;

namespace HashIt
{
    public partial class HashIt : Form
    {
        public Boolean configShown = false;
        public String DraggedFile = "";
        String version = "1.0.0";
        String dateVersion = "04/02/2021";

        /*
        PBKDF2 :  Rfc2898DeriveBytes (HMAC SHA1)
        maj des algos

        siphash / SIP digest authentication (MD5)
        WPA ?
        Kerberos, Skype
        MacOS
        MSSQL, Postgre, Oracle
        MS Office, PKZIP, 7zip
        */

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


            //test
            String sPass = "test";
            Byte[] bPass = Settings.GetEncoding().GetBytes(sPass);

            HashResult hr;
            hr = HashFactory.Crypto.SHA3.CreateKeccak256().ComputeString(sPass);

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

            if ((20 * 1024 * 1024) <= new FileInfo(DraggedFile).Length)
            {
                DialogResult dr = MessageBox.Show("Attention fichier lourd. Continuer ?", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;
            }

            l_fichier.Text = Path.GetFileName(DraggedFile);
            HashClass h = new HashClass();
            Param p = new Param();

            using (FileStream stream = File.OpenRead(DraggedFile))
            {
                for (int i = 0; i < cblb_algos.CheckedItems.Count; i++)
                {
                    String algo = cblb_algos.CheckedItems[i].ToString();
                    p.Fs = stream;

                    object ob = h.GetType().InvokeMember("Get" + algo, BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod, null, h, new object[] { p });
                    String hash = ob.ToString();
                    hash = ((Settings.OutputUppercase) ? hash.ToUpper() : hash.ToLower());
                    hash = hash.Replace("-", "");
                    AddRow(algo, hash);

                    stream.Position = 0;
                }
            }

            Checksum();
        }


        private void b_hashText_Click(object sender, EventArgs e)
        {
            Clear();
            int saltUse = cb_useSalt.SelectedIndex;
            int nb = (int)nb_iterations.Value;
            String originalPassword = tb_texte.Text;
            String saltedPassword = tb_texte.Text;
            String sel = tb_sel.Text;

            if (saltUse == 1) saltedPassword = sel + originalPassword;
            else if (saltUse == 2) saltedPassword = originalPassword + sel;
            else if (saltUse == 3) saltedPassword = sel + originalPassword + sel;

            HashClass h = new HashClass();
            Param p = new Param
            {
                Iterations = nb,
                OriginalPassword = originalPassword,
                Salt = sel,
                SaltedPassword = saltedPassword
            };

            if (saltUse == 0) p.StringValueToHash = p.OriginalPassword;
            else p.StringValueToHash = p.SaltedPassword;
            p.ByteValueToHash = Settings.GetEncoding().GetBytes(p.StringValueToHash);

            for (int i = 0; i < cblb_algos.CheckedItems.Count; i++)
            {
                String algo = cblb_algos.CheckedItems[i].ToString();

                for (int j = 0; j < p.Iterations; j++)
                {
                    object ob = h.GetType().InvokeMember("Get" + algo, BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod, null, h, new object[] { p });
                    
                    String hash = ob.ToString();
                    hash = hash.Replace("-", "");
                    hash = ((Settings.OutputUppercase) ? hash.ToUpper() : hash.ToLower());
                    p.ResultHash = hash;
                    p.StringValueToHash = hash;
                }

                AddRow(algo, p.ResultHash);
            }

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