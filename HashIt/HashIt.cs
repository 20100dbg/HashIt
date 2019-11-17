using System;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Configuration;

namespace HashIt
{
    public partial class HashIt : Form
    {
        public Configuration config;
        public List<Algo> algo = new List<Algo>();
        public String DraggedFile = "";

        public HashIt()
        {
            InitializeComponent();

            this.MinimumSize = new Size(860, 350);
            InitConfig();
        }


        #region config

        public Boolean configShown = false;

        public void InitConfig()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (config.AppSettings.Settings["algo"] != null)
            {
                String[] tab_algo = config.AppSettings.Settings["algo"].Value.Split(';');

                for (int i = 0; i < tab_algo.Length; i++)
                {
                    String[] tab = tab_algo[i].Split(',');
                    algo.Add(new Algo { Name = tab[0], Show = StringToBool(tab[1]), Select = StringToBool(tab[2]) });
                }
            }

            if (config.AppSettings.Settings["nb_iterations"] != null)
            {
                decimal x;
                if (decimal.TryParse(config.AppSettings.Settings["nb_iterations"].Value, out x))
                    nb_iterations.Value = x;
            }


            RefreshConfig();
        }


        public void SaveConfig()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < algo.Count; i++)
            {
                sb.Append(algo[i].Name + "," + algo[i].Show + "," + algo[i].Select + ";");
            }
            sb.Remove(sb.Length - 1, 1);

            config.AppSettings.Settings["algo"].Value = sb.ToString();
            config.Save(ConfigurationSaveMode.Modified);
        }


        public void RefreshConfig()
        {
            cblb_algos.Items.Clear();

            for (int i = 0; i < algo.Count; i++)
            {
                if (algo[i].Show)
                {
                    cblb_algos.Items.Add(algo[i].Name);
                    if (algo[i].Select) cblb_algos.SetItemChecked(cblb_algos.Items.Count - 1, true);
                }
            }
        }


        private void b_config_Click(object sender, EventArgs e)
        {
            if (!configShown)
            {
                Config c = new Config(this);
                c.Show();
                configShown = true;
            }
        }

        public Boolean StringToBool(String str)
        {
            return (str.ToLower() == "true");
        }

        #endregion



        public void HashText(String str, String sel, Boolean forcerSel, decimal nb_iterations)
        {
            Hash h = new Hash();
            if (nb_iterations <= 0) nb_iterations = 1;

            String strSansSel = str;

            if (forcerSel)
                str = sel + str;

            for (int i = 0; i < cblb_algos.CheckedItems.Count; i++)
            {
                if (cblb_algos.CheckedItems[i].ToString() == "MD2")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetMD2(str);
                    AddRow("MD2", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "MD4")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetMD4(str);
                    AddRow("MD4", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "MD5")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetMD5(str);
                    AddRow("MD5", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "MD5 Unix")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetMD5Unix(strSansSel, sel);
                    AddRow("MD5 Unix", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "SHA1")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetSHA1(str);
                    AddRow("SHA1", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "SHA256")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetSHA256(str);
                    AddRow("SHA256", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "SHA384")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetSHA384(str);
                    AddRow("SHA384", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "SHA512")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetSHA512(str);
                    AddRow("SHA512", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "RIPEMD160")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetRIPEMD160(str);
                    AddRow("RIPEMD160", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "RIPEMD256")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetRIPEMD256(str);
                    AddRow("RIPEMD256", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "RIPEMD320")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetRIPEMD320(str);
                    AddRow("RIPEMD320", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "CRC32")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetCRC32(str);
                    AddRow("CRC32", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "CRC64")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetCRC64(str);
                    AddRow("CRC64", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "Whirlpool")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetWhirlpool(str);
                    AddRow("Whirlpool", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "HAVAL256")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetHaval256(str);
                    AddRow("HAVAL256", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "Tiger2")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetTiger2(str);
                    AddRow("Tiger2", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "Panama")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetPanama(str);
                    AddRow("Panama", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "Gost")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetGost(str);
                    AddRow("Gost", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "Grindahl512")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetGrindahl512(str);
                    AddRow("Grindahl512", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "HAS160")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetHAS160(str);
                    AddRow("HAS160", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "RadioGatun64")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetRadioGatun64(str);
                    AddRow("RadioGatun64", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "Snefru8_256")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetSnefru8_256(str);
                    AddRow("Snefru8_256", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "Blake512")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetBlake512(str);
                    AddRow("Blake512", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "BlueMidnightWish512")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetBlueMidnightWish512(str);
                    AddRow("BlueMidnightWish512", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "CubeHash512")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetCubeHash512(str);
                    AddRow("CubeHash512", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "Echo512")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetEcho512(str);
                    AddRow("Echo512", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "Fugue512")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetFugue512(str);
                    AddRow("Fugue512", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "Groestl512")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetGroestl512(str);
                    AddRow("Groestl512", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "Hamsi512")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetHamsi512(str);
                    AddRow("Hamsi512", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "JH512")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetJH512(str);
                    AddRow("JH512", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "Keccak512")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetKeccak512(str);
                    AddRow("Keccak512", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "Luffa512")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetLuffa512(str);
                    AddRow("Luffa512", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "Shabal512")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetShabal512(str);
                    AddRow("Shabal512", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "SHAvite3_512")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetSHAvite3_512(str);
                    AddRow("SHAvite3_512", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "SIMD512")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetSIMD512(str);
                    AddRow("SIMD512", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "Skein512")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetSkein512(str);
                    AddRow("Skein512", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "PBKDF2")
                {
                    str = h.GetPBKDF2(strSansSel, sel, (int)nb_iterations);
                    AddRow("PBKDF2", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "Murmur2")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetMurmur2(str);
                    AddRow("Murmur2", str);
                }
                else if (cblb_algos.CheckedItems[i].ToString() == "Murmur3")
                {
                    for (int j = 0; j < nb_iterations; j++) str = h.GetMurmur3(str);
                    AddRow("Murmur3", str);
                }
            }

            for (int i = 0; i < dgv_hashs.Rows.Count; i++)
            {
                if (dgv_hashs.Rows[i].Cells[1].Value.ToString() == tb_checksum.Text)
                {
                    tb_checksum.BackColor = Color.LightGreen;
                    dgv_hashs.Rows[i].Cells[1].Style.BackColor = Color.LightGreen;
                }
            }
        }


        public void HashFile(String filepath)
        {
            Hash h = new Hash();

            using (FileStream stream = File.OpenRead(filepath))
            {
                for (int i = 0; i < cblb_algos.CheckedItems.Count; i++)
                {
                    if (cblb_algos.CheckedItems[i].ToString() == "MD2") AddRow("MD2", h.GetMD2(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "MD4") AddRow("MD4", h.GetMD4(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "MD5") AddRow("MD5", h.GetMD5(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "SHA1") AddRow("SHA1", h.GetSHA1(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "SHA256") AddRow("SHA256", h.GetSHA256(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "SHA384") AddRow("SHA384", h.GetSHA384(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "SHA512") AddRow("SHA512", h.GetSHA512(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "RIPEMD160") AddRow("RIPEMD160", h.GetRIPEMD160(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "RIPEMD256") AddRow("RIPEMD256", h.GetRIPEMD256(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "RIPEMD320") AddRow("RIPEMD320", h.GetRIPEMD320(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "CRC32") AddRow("CRC32", h.GetCRC32(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "CRC64") AddRow("CRC64", h.GetCRC64(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "Whirlpool") AddRow("Whirlpool", h.GetWhirlpool(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "HAVAL256") AddRow("HAVAL256", h.GetHaval256(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "Tiger2") AddRow("Tiger2", h.GetTiger2(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "Panama") AddRow("Panama", h.GetPanama(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "Gost") AddRow("Gost", h.GetGost(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "Grindahl512") AddRow("Grindahl512", h.GetGrindahl512(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "HAS160") AddRow("HAS160", h.GetHAS160(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "RadioGatun64") AddRow("RadioGatun64", h.GetRadioGatun64(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "Snefru8_256") AddRow("Snefru8_256", h.GetSnefru8_256(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "Blake512") AddRow("Blake512", h.GetBlake512(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "BlueMidnightWish512") AddRow("BlueMidnightWish512", h.GetBlueMidnightWish512(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "CubeHash512") AddRow("CubeHash512", h.GetCubeHash512(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "Echo512") AddRow("Echo512", h.GetEcho512(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "Fugue512") AddRow("Fugue512", h.GetFugue512(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "Groestl512") AddRow("Groestl512", h.GetGroestl512(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "Hamsi512") AddRow("Hamsi512", h.GetHamsi512(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "JH512") AddRow("JH512", h.GetJH512(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "Keccak512") AddRow("Keccak512", h.GetKeccak512(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "Luffa512") AddRow("Luffa512", h.GetLuffa512(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "Shabal512") AddRow("Shabal512", h.GetShabal512(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "SHAvite3_512") AddRow("SHAvite3_512", h.GetSHAvite3_512(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "SIMD512") AddRow("SIMD512", h.GetSIMD512(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "Skein512") AddRow("Skein512", h.GetSkein512(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "Murmur2") AddRow("Murmur2", h.GetMurmur2(stream));
                    else if (cblb_algos.CheckedItems[i].ToString() == "Murmur3") AddRow("Murmur3", h.GetMurmur3(stream));

                    stream.Position = 0;
                }
            }

            for (int i = 0; i < dgv_hashs.Rows.Count; i++)
            {
                if (dgv_hashs.Rows[i].Cells[1].Value.ToString() == tb_checksum.Text)
                {
                    tb_checksum.BackColor = Color.LightGreen;
                    dgv_hashs.Rows[i].Cells[1].Style.BackColor = Color.LightGreen;
                }
            }
        }


        private void b_hash_Click(object sender, EventArgs e)
        {
            Clear();

            if (!String.IsNullOrEmpty(DraggedFile))
            {
                l_fichier.Text = "Chargement ...";
                HashFile(DraggedFile);
                l_fichier.Text = "Hash du fichier " + Path.GetFileName(DraggedFile);
                DraggedFile = "";
                tb_texte.Text = "";
            }
            else
            {
                HashText(tb_texte.Text, tb_sel.Text, cb_ForcerSel.Checked, nb_iterations.Value);
                l_fichier.Text = "Déposer un fichier";
            }
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




        public void Clear()
        {
            tb_checksum.BackColor = Color.White;
            dgv_hashs.Rows.Clear();
        }

        public void AddRow(String algo, String hash)
        {
            dgv_hashs.Rows.Add(new object[] { algo, hash });
        }



    }

    public class Algo
    {
        public String Name { get; set; }
        public Boolean Show { get; set; }
        public Boolean Select { get; set; }
    }
}
