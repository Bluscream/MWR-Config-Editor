namespace MWR_Config_Editor.UI
{
    partial class DVARInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DVARInfo));
            this.btn_save = new System.Windows.Forms.Button();
            this.table_dvar = new System.Windows.Forms.DataGridView();
            this.Header_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Header_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.table_dvar)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.Location = new System.Drawing.Point(365, 412);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 0;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // table_dvar
            // 
            this.table_dvar.AllowUserToAddRows = false;
            this.table_dvar.AllowUserToDeleteRows = false;
            this.table_dvar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_dvar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Header_Name,
            this.Header_Value});
            this.table_dvar.Location = new System.Drawing.Point(12, 12);
            this.table_dvar.MultiSelect = false;
            this.table_dvar.Name = "table_dvar";
            this.table_dvar.RowHeadersVisible = false;
            this.table_dvar.Size = new System.Drawing.Size(428, 394);
            this.table_dvar.TabIndex = 1;
            // 
            // Header_Name
            // 
            this.Header_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Header_Name.HeaderText = "Name";
            this.Header_Name.Name = "Header_Name";
            this.Header_Name.Width = 58;
            // 
            // Header_Value
            // 
            this.Header_Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Header_Value.HeaderText = "Value";
            this.Header_Value.Name = "Header_Value";
            // 
            // DVARInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 447);
            this.Controls.Add(this.table_dvar);
            this.Controls.Add(this.btn_save);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DVARInfo";
            this.Text = "Infos about DVAR";
            ((System.ComponentModel.ISupportInitialize)(this.table_dvar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.DataGridView table_dvar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Header_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Header_Value;
    }
}