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

namespace MWR_Config_Editor
{
    public partial class Main : Form
    {
        private CFGFile loadedCFG; // = new CFGFile();
        public Main()
        {
            InitializeComponent();
        }
        private void FillConfig()
        {
            table_config.DataSource = loadedCFG.Data.Lines;
            table_config.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            table_config.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            table_config.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void FillConfig(CFGData config) {
            table_config.Rows.Clear();
            foreach (var item in config.Lines) {
                table_config.Rows.Add(item.Command, item.DVAR, item.Value);
            }
        }

        private void loadConfigToolStripMenuItem_Click(object sender, EventArgs e) {
            var pickedFile = Utils.pickFile(title: "Select the MWR config file", filter: "MWR config files|config*.cfg|All config files|*.cfg");
            if (pickedFile is null || !pickedFile.Exists) return;
            loadedCFG = new CFGFile(pickedFile);
            FillConfig(); // loadedCFG.Data
        }

        private void saveConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openConfigExternallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadedCFG is null) { MessageBox.Show("No config loaded", "Error"); return; }
            Utils.StartProcess(loadedCFG.File);
        }

        private void openToolConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateDVARInfosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadedCFG is null) { MessageBox.Show("No config loaded", "Error"); return; }
            var fName = DVARS.DefaultFileName.Quote();
            var result = MessageBox.Show($"You're about to update the dvars in {fName} with the dvars found in {loadedCFG.File.Name.Quote()}.", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;
            DVARS.Update(loadedCFG.Data);
            MessageBox.Show($"Updated {fName}!");
        }

        private void openDVARInfosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.StartProcess(DVARS.DefaultFileName);
        }

        private void table_config_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if ((e.RowIndex > -1) && (e.ColumnIndex == table_config.Columns["DVAR"].Index)) {
                var sb = new StringBuilder();
                var dvar = ((CFGLine)(table_config.Rows[e.RowIndex].DataBoundItem)).DVAR;
                if (dvar.Name != null) sb.AppendLine($"Name: {dvar.Name}");
                if (dvar.Hex != null) sb.AppendLine($"HEX: {dvar.Hex}");
                if (dvar.Type != null) sb.AppendLine($"Type: {dvar.Type}");
                if (dvar.MinValue != null) sb.AppendLine($"Min Value: {dvar.MinValue}");
                if (dvar.MaxValue != null) sb.AppendLine($"Max Value: {dvar.MaxValue}");
                if (dvar.DefaultValue != null) sb.AppendLine($"Default Value: {dvar.DefaultValue}");
                if (dvar.Description != null) sb.AppendLine($"Description: {dvar.Description}");
                e.ToolTipText = sb.ToString();
            }
        }

        private void table_config_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            table_config.CurrentCell = table_config.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if ((e.RowIndex > -1) && (e.ColumnIndex == table_config.Columns["DVAR"].Index)) {
                e.ContextMenuStrip = menu_dvar;
            }
        }

        private void changeNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dvar = (DVAR)table_config.SelectedCells[0].Value;
            new UI.DVARInfo(dvar).Show();
        }
    }
}
