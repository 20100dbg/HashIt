using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace HashIt
{
    public partial class Config : Form
    {
        HashIt hashit;

        public Config(HashIt hashit)
        {
            InitializeComponent();
            this.hashit = hashit;

            dataGridView2.Rows.Add(new Object[] { "", false, true });
            dataGridView2.Rows[0].Visible = false;

            for (int i = 0; i < hashit.algo.Count; i++)
            {
                dataGridView2.Rows.Add(new Object[] { hashit.algo[i].Name, hashit.algo[i].Show, hashit.algo[i].Select });
            }
        }


        private void Config_FormClosing(object sender, FormClosingEventArgs e)
        {
            hashit.configShown = false;
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            hashit.SaveConfig();
            hashit.RefreshConfig();
            Close();
        }


        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DoYourThing(e);
        }


        private void DoYourThing(DataGridViewCellEventArgs e)
        {
            Object isChecked = dataGridView2.Rows[0].Cells[2].Value;
            Object isNotChecked = dataGridView2.Rows[0].Cells[1].Value;
            Boolean val = (Boolean)dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

            if (e.ColumnIndex == 1)
            {
                if (val)
                {
                    hashit.algo[e.RowIndex].Show = false;
                    hashit.algo[e.RowIndex].Select = false;
                    dataGridView2.Rows[e.RowIndex].Cells[1].Value = isNotChecked;
                    dataGridView2.Rows[e.RowIndex].Cells[2].Value = isNotChecked;
                }
                else
                {
                    hashit.algo[e.RowIndex].Show = true;
                    hashit.algo[e.RowIndex].Select = false;
                    dataGridView2.Rows[e.RowIndex].Cells[1].Value = isChecked;
                    dataGridView2.Rows[e.RowIndex].Cells[2].Value = isNotChecked;
                }
            }

            if (e.ColumnIndex == 2)
            {
                if (val)
                {
                    hashit.algo[e.RowIndex].Select = false;
                    dataGridView2.Rows[e.RowIndex].Cells[2].Value = isNotChecked;
                }
                else
                {
                    hashit.algo[e.RowIndex].Select = true;
                    hashit.algo[e.RowIndex].Show = true;
                    dataGridView2.Rows[e.RowIndex].Cells[1].Value = isChecked;
                    dataGridView2.Rows[e.RowIndex].Cells[2].Value = isChecked;
                }
            }

            //dataGridView2.ClearSelection();
            dataGridView2.RefreshEdit();
        }
    }
}
