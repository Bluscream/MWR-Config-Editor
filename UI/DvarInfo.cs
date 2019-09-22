using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CFGParser.Classes;

namespace MWR_Config_Editor.UI
{
    public partial class DVARInfo : Form
    {
        private DVAR currentDVAR;

        public static DVAR ShowSync(DVAR dvar)
        {
            var mi = new DVARInfo(dvar);
            if (mi.ShowDialog() == DialogResult.OK)
                return mi.currentDVAR;
            return null;
        }
        public DVARInfo(DVAR dvar)
        {
            DialogResult = DialogResult.Cancel;
            InitializeComponent();
            FillInfos(dvar);
        }

        public void FillInfos(DVAR dvar)
        {
            currentDVAR = dvar;
            Text = $"Infos about DVAR {currentDVAR}";
            // table_dvar.DataSource = currentDVAR;
            table_dvar.Rows.Clear();
            table_dvar.Rows.Add("Name", currentDVAR.Name);
            table_dvar.Rows.Add("Hash", currentDVAR.Hash);
            table_dvar.Rows.Add("Type", currentDVAR.Type);
            table_dvar.Rows.Add("Default", currentDVAR.DefaultValue);
            table_dvar.Rows.Add("Min", currentDVAR.MinValue);
            table_dvar.Rows.Add("Max", currentDVAR.MaxValue);
            table_dvar.Rows.Add("Description", currentDVAR.Description);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            currentDVAR.Name = (string)table_dvar.Rows[0].Cells[1].Value;
            currentDVAR.Hash = (string)table_dvar.Rows[1].Cells[1].Value;
            currentDVAR.Type = (string)table_dvar.Rows[2].Cells[1].Value;
            currentDVAR.DefaultValue = (string)table_dvar.Rows[3].Cells[1].Value;
            currentDVAR.MinValue = (string)table_dvar.Rows[4].Cells[1].Value;
            currentDVAR.MaxValue = (string)table_dvar.Rows[5].Cells[1].Value;
            currentDVAR.Description = (string)table_dvar.Rows[6].Cells[1].Value;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
