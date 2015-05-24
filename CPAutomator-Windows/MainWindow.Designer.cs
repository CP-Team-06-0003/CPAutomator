namespace CPAutomator_Windows
{
    partial class MainWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pluginGridView = new MetroFramework.Controls.MetroGrid();
            this.pluginName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RunPlugin = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PluginProperties = new System.Windows.Forms.DataGridViewButtonColumn();
            this.UnloadPlugin = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PluginRuns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRunAll = new MetroFramework.Controls.MetroButton();
            this.pluginProgress = new MetroFramework.Controls.MetroProgressBar();
            this.btnLog = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.pluginGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // pluginGridView
            // 
            this.pluginGridView.AllowUserToAddRows = false;
            this.pluginGridView.AllowUserToResizeRows = false;
            this.pluginGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pluginGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pluginGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.pluginGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pluginGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.pluginGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pluginGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pluginName,
            this.RunPlugin,
            this.PluginProperties,
            this.UnloadPlugin,
            this.PluginRuns,
            this.ID});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.pluginGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.pluginGridView.EnableHeadersVisualStyles = false;
            this.pluginGridView.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.pluginGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pluginGridView.Location = new System.Drawing.Point(23, 63);
            this.pluginGridView.Name = "pluginGridView";
            this.pluginGridView.ReadOnly = true;
            this.pluginGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pluginGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.pluginGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.pluginGridView.RowTemplate.Height = 24;
            this.pluginGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.pluginGridView.Size = new System.Drawing.Size(436, 302);
            this.pluginGridView.TabIndex = 0;
            this.pluginGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pluginGridView_CellContentClick);
            // 
            // pluginName
            // 
            this.pluginName.HeaderText = "Plugin Name";
            this.pluginName.MinimumWidth = 175;
            this.pluginName.Name = "pluginName";
            this.pluginName.ReadOnly = true;
            this.pluginName.Width = 175;
            // 
            // RunPlugin
            // 
            this.RunPlugin.HeaderText = "";
            this.RunPlugin.MinimumWidth = 50;
            this.RunPlugin.Name = "RunPlugin";
            this.RunPlugin.ReadOnly = true;
            this.RunPlugin.Width = 50;
            // 
            // PluginProperties
            // 
            this.PluginProperties.HeaderText = "";
            this.PluginProperties.MinimumWidth = 65;
            this.PluginProperties.Name = "PluginProperties";
            this.PluginProperties.ReadOnly = true;
            this.PluginProperties.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PluginProperties.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PluginProperties.Width = 65;
            // 
            // UnloadPlugin
            // 
            this.UnloadPlugin.HeaderText = "";
            this.UnloadPlugin.MinimumWidth = 50;
            this.UnloadPlugin.Name = "UnloadPlugin";
            this.UnloadPlugin.ReadOnly = true;
            this.UnloadPlugin.Width = 50;
            // 
            // PluginRuns
            // 
            this.PluginRuns.HeaderText = "Runs";
            this.PluginRuns.MinimumWidth = 40;
            this.PluginRuns.Name = "PluginRuns";
            this.PluginRuns.ReadOnly = true;
            this.PluginRuns.Width = 40;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // btnRunAll
            // 
            this.btnRunAll.Location = new System.Drawing.Point(23, 371);
            this.btnRunAll.Name = "btnRunAll";
            this.btnRunAll.Size = new System.Drawing.Size(350, 30);
            this.btnRunAll.TabIndex = 1;
            this.btnRunAll.Text = "Run All Plugins";
            this.btnRunAll.UseSelectable = true;
            // 
            // pluginProgress
            // 
            this.pluginProgress.Location = new System.Drawing.Point(23, 407);
            this.pluginProgress.Name = "pluginProgress";
            this.pluginProgress.Size = new System.Drawing.Size(436, 23);
            this.pluginProgress.TabIndex = 2;
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(379, 371);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(80, 30);
            this.btnLog.TabIndex = 3;
            this.btnLog.Text = "Log";
            this.btnLog.UseSelectable = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.pluginProgress);
            this.Controls.Add(this.btnRunAll);
            this.Controls.Add(this.pluginGridView);
            this.MaximumSize = new System.Drawing.Size(482, 453);
            this.MinimumSize = new System.Drawing.Size(482, 453);
            this.Name = "MainWindow";
            this.Text = "CP Automator";
            ((System.ComponentModel.ISupportInitialize)(this.pluginGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public MetroFramework.Controls.MetroGrid pluginGridView;
        public MetroFramework.Controls.MetroButton btnRunAll;
        private MetroFramework.Controls.MetroProgressBar pluginProgress;
        private MetroFramework.Controls.MetroButton btnLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn pluginName;
        private System.Windows.Forms.DataGridViewButtonColumn RunPlugin;
        private System.Windows.Forms.DataGridViewButtonColumn PluginProperties;
        private System.Windows.Forms.DataGridViewButtonColumn UnloadPlugin;
        private System.Windows.Forms.DataGridViewTextBoxColumn PluginRuns;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    }
}

