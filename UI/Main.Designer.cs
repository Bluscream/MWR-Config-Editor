﻿namespace MWR_Config_Editor
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.status = new System.Windows.Forms.StatusStrip();
            this.menu_main = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openConfigExternallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateDVARInfosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDVARInfosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.table_config = new System.Windows.Forms.DataGridView();
            this.menu_dvar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_config)).BeginInit();
            this.menu_dvar.SuspendLayout();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(0, 428);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(800, 22);
            this.status.TabIndex = 0;
            this.status.Text = "statusStrip1";
            // 
            // menu_main
            // 
            this.menu_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helToolStripMenuItem});
            this.menu_main.Location = new System.Drawing.Point(0, 0);
            this.menu_main.Name = "menu_main";
            this.menu_main.Size = new System.Drawing.Size(800, 25);
            this.menu_main.TabIndex = 1;
            this.menu_main.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadConfigToolStripMenuItem,
            this.saveConfigToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadConfigToolStripMenuItem
            // 
            this.loadConfigToolStripMenuItem.Name = "loadConfigToolStripMenuItem";
            this.loadConfigToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.loadConfigToolStripMenuItem.Text = "Load Config";
            this.loadConfigToolStripMenuItem.Click += new System.EventHandler(this.loadConfigToolStripMenuItem_Click);
            // 
            // saveConfigToolStripMenuItem
            // 
            this.saveConfigToolStripMenuItem.Name = "saveConfigToolStripMenuItem";
            this.saveConfigToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.saveConfigToolStripMenuItem.Text = "Save Config";
            this.saveConfigToolStripMenuItem.Click += new System.EventHandler(this.saveConfigToolStripMenuItem_Click);
            // 
            // helToolStripMenuItem
            // 
            this.helToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openConfigExternallyToolStripMenuItem,
            this.openToolConfigToolStripMenuItem,
            this.updateDVARInfosToolStripMenuItem,
            this.openDVARInfosToolStripMenuItem});
            this.helToolStripMenuItem.Name = "helToolStripMenuItem";
            this.helToolStripMenuItem.Size = new System.Drawing.Size(46, 21);
            this.helToolStripMenuItem.Text = "Help";
            // 
            // openConfigExternallyToolStripMenuItem
            // 
            this.openConfigExternallyToolStripMenuItem.Name = "openConfigExternallyToolStripMenuItem";
            this.openConfigExternallyToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.openConfigExternallyToolStripMenuItem.Text = "Open Config externally";
            this.openConfigExternallyToolStripMenuItem.Click += new System.EventHandler(this.openConfigExternallyToolStripMenuItem_Click);
            // 
            // openToolConfigToolStripMenuItem
            // 
            this.openToolConfigToolStripMenuItem.Name = "openToolConfigToolStripMenuItem";
            this.openToolConfigToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.openToolConfigToolStripMenuItem.Text = "Open Tool Config";
            this.openToolConfigToolStripMenuItem.Click += new System.EventHandler(this.openToolConfigToolStripMenuItem_Click);
            // 
            // updateDVARInfosToolStripMenuItem
            // 
            this.updateDVARInfosToolStripMenuItem.Name = "updateDVARInfosToolStripMenuItem";
            this.updateDVARInfosToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.updateDVARInfosToolStripMenuItem.Text = "Update DVAR Infos";
            this.updateDVARInfosToolStripMenuItem.Click += new System.EventHandler(this.updateDVARInfosToolStripMenuItem_Click);
            // 
            // openDVARInfosToolStripMenuItem
            // 
            this.openDVARInfosToolStripMenuItem.Name = "openDVARInfosToolStripMenuItem";
            this.openDVARInfosToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.openDVARInfosToolStripMenuItem.Text = "Open DVAR Infos";
            this.openDVARInfosToolStripMenuItem.Click += new System.EventHandler(this.openDVARInfosToolStripMenuItem_Click);
            // 
            // table_config
            // 
            this.table_config.AllowUserToOrderColumns = true;
            this.table_config.AllowUserToResizeRows = false;
            this.table_config.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_config.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_config.Location = new System.Drawing.Point(0, 25);
            this.table_config.MultiSelect = false;
            this.table_config.Name = "table_config";
            this.table_config.RowHeadersVisible = false;
            this.table_config.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.table_config.ShowRowErrors = false;
            this.table_config.Size = new System.Drawing.Size(800, 403);
            this.table_config.TabIndex = 2;
            this.table_config.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.table_config_CellContextMenuStripNeeded);
            this.table_config.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.table_config_CellToolTipTextNeeded);
            this.table_config.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.table_config_DataError);
            // 
            // menu_dvar
            // 
            this.menu_dvar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeNameToolStripMenuItem});
            this.menu_dvar.Name = "menu_dvar";
            this.menu_dvar.Size = new System.Drawing.Size(144, 26);
            // 
            // changeNameToolStripMenuItem
            // 
            this.changeNameToolStripMenuItem.Name = "changeNameToolStripMenuItem";
            this.changeNameToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.changeNameToolStripMenuItem.Text = "Change Info";
            this.changeNameToolStripMenuItem.Click += new System.EventHandler(this.changeNameToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.table_config);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menu_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu_main;
            this.Name = "Main";
            this.Text = "Call of Duty: MWR Config Editor";
            this.menu_main.ResumeLayout(false);
            this.menu_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_config)).EndInit();
            this.menu_dvar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.MenuStrip menu_main;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openConfigExternallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolConfigToolStripMenuItem;
        private System.Windows.Forms.DataGridView table_config;
        private System.Windows.Forms.ToolStripMenuItem updateDVARInfosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDVARInfosToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip menu_dvar;
        private System.Windows.Forms.ToolStripMenuItem changeNameToolStripMenuItem;
    }
}

