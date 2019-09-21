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
        public DVARInfo(DVAR dvar)
        {
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
            table_dvar.Rows.Add("Hex", currentDVAR.Hex);
            table_dvar.Rows.Add("Type", currentDVAR.Type);
            table_dvar.Rows.Add("Default", currentDVAR.DefaultValue);
            table_dvar.Rows.Add("Min", currentDVAR.MinValue);
            table_dvar.Rows.Add("Max", currentDVAR.MaxValue);
            table_dvar.Rows.Add("Description", currentDVAR.Description);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            MessageBox.Show(currentDVAR.ToString());
        }
    }
}
