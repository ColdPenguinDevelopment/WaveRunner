
namespace WaveRunnerV2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManageAudio = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManageMusic = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlAudioControls = new System.Windows.Forms.Panel();
            this.btnFade = new System.Windows.Forms.Button();
            this.mpLayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flpAudio = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvMusic = new System.Windows.Forms.DataGridView();
            this.SortOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFadeFast = new System.Windows.Forms.Button();
            this.btnFadeSlow = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.pnlAudioControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mpLayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusic)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.manageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(877, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuManageAudio,
            this.mnuManageMusic,
            this.toolStripSeparator1,
            this.settingsToolStripMenuItem});
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(62, 19);
            this.manageToolStripMenuItem.Text = "Manage";
            // 
            // mnuManageAudio
            // 
            this.mnuManageAudio.Name = "mnuManageAudio";
            this.mnuManageAudio.Size = new System.Drawing.Size(181, 22);
            this.mnuManageAudio.Text = "Manage Audio Clips";
            this.mnuManageAudio.Click += new System.EventHandler(this.mnuManageAudio_Click);
            // 
            // mnuManageMusic
            // 
            this.mnuManageMusic.Name = "mnuManageMusic";
            this.mnuManageMusic.Size = new System.Drawing.Size(181, 22);
            this.mnuManageMusic.Text = "Manage Music";
            this.mnuManageMusic.Click += new System.EventHandler(this.mnuManageMusic_Click);
            // 
            // pnlAudioControls
            // 
            this.pnlAudioControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlAudioControls.Controls.Add(this.btnFadeSlow);
            this.pnlAudioControls.Controls.Add(this.btnFadeFast);
            this.pnlAudioControls.Controls.Add(this.btnFade);
            this.pnlAudioControls.Controls.Add(this.mpLayer);
            this.pnlAudioControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAudioControls.Location = new System.Drawing.Point(0, 612);
            this.pnlAudioControls.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAudioControls.Name = "pnlAudioControls";
            this.pnlAudioControls.Size = new System.Drawing.Size(877, 111);
            this.pnlAudioControls.TabIndex = 1;
            // 
            // btnFade
            // 
            this.btnFade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFade.Location = new System.Drawing.Point(309, 15);
            this.btnFade.Name = "btnFade";
            this.btnFade.Size = new System.Drawing.Size(129, 28);
            this.btnFade.TabIndex = 1;
            this.btnFade.Text = "Fade Out";
            this.btnFade.UseVisualStyleBackColor = true;
            this.btnFade.Click += new System.EventHandler(this.btnFade_Click);
            // 
            // mpLayer
            // 
            this.mpLayer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mpLayer.Enabled = true;
            this.mpLayer.Location = new System.Drawing.Point(0, 49);
            this.mpLayer.Name = "mpLayer";
            this.mpLayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mpLayer.OcxState")));
            this.mpLayer.Size = new System.Drawing.Size(877, 62);
            this.mpLayer.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.flpAudio);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(11);
            this.splitContainer1.Panel1MinSize = 225;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Panel2.Controls.Add(this.dgvMusic);
            this.splitContainer1.Panel2MinSize = 150;
            this.splitContainer1.Size = new System.Drawing.Size(877, 594);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.SplitterWidth = 7;
            this.splitContainer1.TabIndex = 2;
            // 
            // flpAudio
            // 
            this.flpAudio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAudio.Location = new System.Drawing.Point(11, 11);
            this.flpAudio.Margin = new System.Windows.Forms.Padding(4);
            this.flpAudio.Name = "flpAudio";
            this.flpAudio.Size = new System.Drawing.Size(274, 568);
            this.flpAudio.TabIndex = 1;
            // 
            // dgvMusic
            // 
            this.dgvMusic.AllowUserToAddRows = false;
            this.dgvMusic.AllowUserToDeleteRows = false;
            this.dgvMusic.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMusic.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMusic.BackgroundColor = System.Drawing.Color.Black;
            this.dgvMusic.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMusic.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvMusic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMusic.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SortOrder,
            this.Title,
            this.Duration});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMusic.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvMusic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMusic.Location = new System.Drawing.Point(0, 0);
            this.dgvMusic.Name = "dgvMusic";
            this.dgvMusic.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMusic.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvMusic.RowHeadersVisible = false;
            this.dgvMusic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMusic.Size = new System.Drawing.Size(566, 590);
            this.dgvMusic.TabIndex = 0;
            this.dgvMusic.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMusic_CellMouseClick);
            this.dgvMusic.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMusic_CellMouseDoubleClick);
            this.dgvMusic.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMusic_CellMouseEnter);
            this.dgvMusic.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMusic_CellMouseLeave);
            this.dgvMusic.SelectionChanged += new System.EventHandler(this.dgvMusic_SelectionChanged);
            // 
            // SortOrder
            // 
            this.SortOrder.HeaderText = "#";
            this.SortOrder.Name = "SortOrder";
            this.SortOrder.ReadOnly = true;
            this.SortOrder.Width = 50;
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Duration
            // 
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            this.Duration.ReadOnly = true;
            this.Duration.Width = 96;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // btnFadeFast
            // 
            this.btnFadeFast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFadeFast.Location = new System.Drawing.Point(444, 15);
            this.btnFadeFast.Name = "btnFadeFast";
            this.btnFadeFast.Size = new System.Drawing.Size(209, 28);
            this.btnFadeFast.TabIndex = 2;
            this.btnFadeFast.Text = "Fade Out Fast (1 Second)";
            this.btnFadeFast.UseVisualStyleBackColor = true;
            this.btnFadeFast.Click += new System.EventHandler(this.btnFadeFast_Click);
            // 
            // btnFadeSlow
            // 
            this.btnFadeSlow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFadeSlow.Location = new System.Drawing.Point(656, 15);
            this.btnFadeSlow.Name = "btnFadeSlow";
            this.btnFadeSlow.Size = new System.Drawing.Size(209, 28);
            this.btnFadeSlow.TabIndex = 3;
            this.btnFadeSlow.Text = "Fade Out Slow (10 Seconds)";
            this.btnFadeSlow.UseVisualStyleBackColor = true;
            this.btnFadeSlow.Click += new System.EventHandler(this.btnFadeSlow_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 723);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlAudioControls);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WaveRunner v2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlAudioControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mpLayer)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuManageAudio;
        private System.Windows.Forms.ToolStripMenuItem mnuManageMusic;
        private System.Windows.Forms.Panel pnlAudioControls;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flpAudio;
        private AxWMPLib.AxWindowsMediaPlayer mpLayer;
        private System.Windows.Forms.Button btnFade;
        private System.Windows.Forms.DataGridView dgvMusic;
        private System.Windows.Forms.DataGridViewTextBoxColumn SortOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Button btnFadeSlow;
        private System.Windows.Forms.Button btnFadeFast;
    }
}

