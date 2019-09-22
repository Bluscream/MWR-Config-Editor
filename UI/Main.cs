using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CFGParser.Classes;

namespace MWR_Config_Editor
{
    public partial class Main : Form {
        // private bool SaveAsNames = true;
        private CFGFile loadedCFG = new CFGFile();
        public Main()
        {
            InitializeComponent();
            if (Program.Arguments.ConfigFilePath != null) LoadConfig(Program.Arguments.ConfigFilePath);
            else SearchConfig();
        }
        private void SearchConfig()
        {
            string[] searchPaths = { "", "players2", "../players2" };
            string[] searchNames = { "config_mp.cfg", "config.cfg" };
            foreach (var path in searchPaths) {
                foreach (var name in searchNames)
                {
                    var fullPath = Path.Combine(path, name);
                    Logger.Trace("Checking if {0} exists...", fullPath.Quote());
                    if (File.Exists(fullPath)) {
                        LoadConfig(fullPath);
                    }
                }
            }
        }
        private void LoadConfig(string filePath) => LoadConfig(new FileInfo(filePath));
        private void LoadConfig(FileInfo file) {
            Logger.Debug("Trying to load config {0}...", file.FullName.Quote());
            if (!file.Exists) return;
            var newCFG = new CFGFile(file);
            Logger.Info("Loaded config {0} with {1} lines.", file.Name.Quote(), newCFG.Data.Lines.Count);
            loadedCFG = newCFG;
            FillConfig();
        }
        private void FillConfig()
        {
            table_config.DataSource = loadedCFG.Data.Lines;
            for (int i = 0; i < table_config.Columns.Count; i++) {
                var column = table_config.Columns[i];
                if (i == table_config.Columns.Count - 1) column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                else column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
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
            LoadConfig(pickedFile);
        }

        private void saveConfigToolStripMenuItem_Click(object sender, EventArgs e) {
            
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
            if (System.IO.File.Exists(DVARS.DefaultFileName))
                Utils.StartProcess(DVARS.DefaultFileName);
        }

        private void table_config_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if ((e.RowIndex > -1) && (e.ColumnIndex == table_config.Columns["DVAR"].Index)) {
                var sb = new StringBuilder();
                var dvar = ((CFGLine)(table_config.Rows[e.RowIndex].DataBoundItem)).DVAR;
                if (dvar is null) return;
                if (dvar.Name != null) sb.AppendLine($"Name: {dvar.Name}");
                if (dvar.Hash != null) sb.AppendLine($"Hash: {dvar.Hash}");
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
            if (e.RowIndex > -1) {
                table_config.CurrentCell = table_config.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if ((e.ColumnIndex == table_config.Columns["DVAR"].Index)) e.ContextMenuStrip = menu_dvar;
            }
        }

        private void changeNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dvar = (DVAR)table_config.SelectedCells[0].Value;
            var retDvar = UI.DVARInfo.ShowSync(dvar);
            if (retDvar is null) return;
            loadedCFG.Data.Lines[loadedCFG.Data.Lines.FindIndex(d => d.DVAR.Hash == dvar.Hash)].DVAR = retDvar;
            // new UI.DVARInfo(dvar).Show();
        }

        private void table_config_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void saveAsNamesToolStripMenuItem_Click(object sender, EventArgs e) {
            var selectedMenuItem = (ToolStripMenuItem)sender;
            if (selectedMenuItem is null) return;
            selectedMenuItem.Checked ^= true;
            Program.Arguments.SaveAsNames = selectedMenuItem.Checked;
        }
    }
}
