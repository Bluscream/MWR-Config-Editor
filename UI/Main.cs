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
        private static readonly string[] searchPaths = { "", "players2", "../players2" };
        private static readonly string[] searchNames = { "config_mp.cfg", "config.cfg" };
        private CFGFile loadedCFG = new CFGFile();
        public Main()
        {
            InitializeComponent();
            indentOnSaveToolStripMenuItem.Checked = Program.Arguments.Indent;
            saveAsNamesToolStripMenuItem.Checked = Program.Arguments.SaveAsNames;
            if (Program.Arguments.ConfigFilePath != null) LoadConfig(Program.Arguments.ConfigFilePath);
            else SearchConfig();
        }
        private void SearchConfig()
        {
            foreach (var path in searchPaths) {
                foreach (var name in searchNames)
                {
                    var fullPath = Path.Combine(path, name);
                    Logger.Trace("Checking if {0} exists...", fullPath.Quote());
                    if (File.Exists(fullPath)) {
                        LoadConfig(fullPath);
                        return;
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
            openConfigExternallyToolStripMenuItem.Enabled = true;
            reloadConfigToolStripMenuItem.Enabled = true;
            saveConfigToolStripMenuItem.Enabled = true;
            FillConfig();
        }
        private void FillConfig()
        {
            int scrollRow = 0;
            if (table_config.SelectedRows.Count > 0) scrollRow = table_config.SelectedRows[0].Index;
            table_config.DataSource = loadedCFG.Data.Lines;
            for (int i = 0; i < table_config.Columns.Count; i++) {
                var column = table_config.Columns[i];
                if (i == table_config.Columns.Count - 1) column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                else column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            if (scrollRow > 0) table_config.FirstDisplayedScrollingRowIndex = scrollRow;
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
            loadedCFG.Save(Program.Arguments.SaveAsNames, Program.Arguments.Indent);
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
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.ColumnIndex == table_config.Columns["DVAR"].Index) {
                var line = (CFGLine)(table_config.Rows[e.RowIndex].DataBoundItem);
                if (line is null) return;
                var dvar = line.DVAR;
                if (dvar is null) return;
                var sb = new StringBuilder();
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
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            table_config.CurrentCell = table_config.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (e.ColumnIndex == table_config.Columns["DVAR"].Index) e.ContextMenuStrip = menu_dvar;
            else e.ContextMenuStrip = menu_list; // TODO: Properly merge them nigga
        }

        private void changeNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dvar = (DVAR)table_config.SelectedCells[0].Value;
            var retDvar = UI.DVARInfo.ShowSync(dvar);
            if (retDvar is null) return;
            loadedCFG.Data.Lines[loadedCFG.Data.Lines.ToList().FindIndex(d => d.DVAR.Hash == dvar.Hash)].DVAR = retDvar;
            // new UI.DVARInfo(dvar).Show();
        }

        private void table_config_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void saveAsNamesToolStripMenuItem_Click(object sender, EventArgs e) => ToggleSetting("SaveAsNames", (ToolStripMenuItem)sender);
       private void indentOnSaveToolStripMenuItem_Click(object sender, EventArgs e) => ToggleSetting("Indent", (ToolStripMenuItem)sender);
        private void ToggleSetting(string setting, ToolStripMenuItem selectedMenuItem) {
            if (selectedMenuItem is null) return;
            selectedMenuItem.Checked ^= true;
            switch (setting) {
                case "SaveAsNames": Program.Arguments.SaveAsNames = selectedMenuItem.Checked; break;
                case "Indent": Program.Arguments.Indent = selectedMenuItem.Checked; break;
                default: break;
            }
        }

        private void reloadConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*loadedCFG = new CFGFile(loadedCFG.File);*/
            loadedCFG.Reload(); FillConfig();
        }

        private void addLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadedCFG.Data.Lines.Add(new CFGLine());
            table_config.FirstDisplayedScrollingRowIndex = table_config.RowCount-1;
            table_config.FirstDisplayedScrollingColumnIndex = 0;
        }
        private void removeLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = table_config.SelectedCells[0].OwningRow;
            loadedCFG.Data.Lines.RemoveAt(row.Index); // table_config.Rows.Remove(table_config.SelectedRows[0]);
        }
    }
}
