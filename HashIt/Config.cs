using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace HashIt
{
    public partial class Config : Form
    {
        public static List<Algo> listAlgos = new List<Algo>();
        public static List<Encodage> listEncodages = new List<Encodage>();
        HashIt fHashIt;

        public Config(HashIt f)
        {
            InitializeComponent();
            this.fHashIt = f;
            //dataGridView2.Rows.Add(new Object[] { "", false, true });
            //dataGridView2.Rows[0].Visible = false;

            for (int i = 0; i < listAlgos.Count; i++)
            {
                dataGridView2.Rows.Add(new Object[] {
                    listAlgos[i].Name,
                    listAlgos[i].Description,
                    listAlgos[i].ShowInList,
                    listAlgos[i].Selected,
                    listAlgos[i].TextCompatible,
                    listAlgos[i].FileCompatible
                });
            }


            cb_encoding.Items.AddRange(listEncodages.ToArray());
            cb_outputUppercase.Checked = Settings.OutputUppercase;
            cb_encoding.SelectedIndex = Settings.EncodageIndex;
        }


        private void b_save_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <dataGridView2.Rows.Count;i++)
            {
                listAlgos[i].Description = dataGridView2[1, i].Value.ToString();
                listAlgos[i].ShowInList = Settings.BoolParse(dataGridView2[2, i].Value.ToString());
                listAlgos[i].Selected = Settings.BoolParse(dataGridView2[3, i].Value.ToString());
            }

            Settings.OutputUppercase = cb_outputUppercase.Checked;
            Settings.EncodageIndex = cb_encoding.SelectedIndex;

            Settings.WriteConfigFile();
            fHashIt.RefreshListboxAlgos();
            Close();
        }


        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DoYourThing(e);
        }


        private void DoYourThing(DataGridViewCellEventArgs e)
        {
            //Object isChecked = dataGridView2.Rows[0].Cells[2].Value;
            //Object isNotChecked = dataGridView2.Rows[0].Cells[1].Value;
            //Boolean val = (Boolean)dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;


            //dataGridView2.Rows[e.RowIndex].Cells[2].Value = false;

            //dataGridView2.ClearSelection();
            //dataGridView2.RefreshEdit();

        }
    }

    public class Encodage
    {
        public String Name { get; set; }
        public Encoding Enc { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Algo
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public Boolean ShowInList { get; set; }
        public Boolean Selected { get; set; }
        public Boolean FileCompatible { get; set; }
        public Boolean TextCompatible { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Param
    {
        public String OriginalPassword { get; set; }
        public String SaltedPassword { get; set; }

        public String StringValueToHash { get; set; }
        public Byte[] ByteValueToHash { get; set; }

        public String ResultHash { get; set; }
        public String Salt { get; set; }
        public Int32 Iterations { get; set; }
        public FileStream Fs { get; set; }
    }


    public static class Settings
    {
        static String ConFile = "hashit.config.txt";
        public static int EncodageIndex { get; set; }
        public static Boolean OutputUppercase { get; set; }
        public static Boolean UseBytesInsteadString { get; set; }


        public static Boolean ReadConfigFile()
        {
            if (!File.Exists(ConFile)) return false;
            String conStr = File.ReadAllText(ConFile);

            String[] lines = conStr.Split(new String[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("EncodageIndex="))
                    Settings.EncodageIndex = int.Parse(lines[i].Substring(14));
                else if (lines[i].StartsWith("OutputUppercase="))
                    Settings.OutputUppercase = BoolParse(lines[i].Substring(16));
                else if (lines[i].StartsWith("UseBytesInsteadString="))
                    Settings.UseBytesInsteadString = BoolParse(lines[i].Substring(22));
                else
                {
                    String[] tab = lines[i].Split(new char[] { ';' });

                    Config.listAlgos.Add(new Algo
                    {
                        Name = tab[0],
                        Description = tab[1],
                        ShowInList = BoolParse(tab[2]),
                        Selected = BoolParse(tab[3]),
                        TextCompatible = BoolParse(tab[4]),
                        FileCompatible = BoolParse(tab[5])
                    });
                }
            }

            return true;
        }

        

        public static void WriteConfigFile()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("EncodageIndex="+Settings.EncodageIndex);
            sb.AppendLine("OutputUppercase=" + Settings.OutputUppercase);
            sb.AppendLine("UseBytesInsteadString=" + Settings.UseBytesInsteadString);

            for (int i = 0; i < Config.listAlgos.Count; i++)
            {
                sb.AppendLine(Config.listAlgos[i].Name + ";" + Config.listAlgos[i].Description + ";" +
                                Config.listAlgos[i].ShowInList + ";" + Config.listAlgos[i].Selected + ";" +
                                Config.listAlgos[i].TextCompatible + ";" + Config.listAlgos[i].FileCompatible);
            }

            WriteFile(sb.ToString(), ConFile);
        }

        public static void WriteFile(String txt, String filename)
        {
            using (StreamWriter sw = new StreamWriter(filename, false, Encoding.UTF8))
            {
                sw.Write(txt);
            }
        }

        public static Boolean BoolParse(String str)
        {
            return (str.ToLower() == "true");
        }

        public static Encoding GetEncoding()
        {
            return Config.listEncodages[Settings.EncodageIndex].Enc;
        }

    }
}