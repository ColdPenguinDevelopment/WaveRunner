
namespace WaveRunnerV2.Modals
{
    partial class ManageAudioClips
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageAudioClips));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnImport = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpAudio = new System.Windows.Forms.FlowLayoutPanel();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmsContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxRename = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.cmsContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(930, 42);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnImport
            // 
            this.btnImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImport.Name = "btnImport";
            this.btnImport.Padding = new System.Windows.Forms.Padding(10);
            this.btnImport.Size = new System.Drawing.Size(128, 39);
            this.btnImport.Text = "Import Audio Files";
            this.btnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 650);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(930, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flpAudio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 42);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(930, 608);
            this.panel1.TabIndex = 3;
            // 
            // flpAudio
            // 
            this.flpAudio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flpAudio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAudio.Location = new System.Drawing.Point(8, 8);
            this.flpAudio.Name = "flpAudio";
            this.flpAudio.Size = new System.Drawing.Size(914, 592);
            this.flpAudio.TabIndex = 0;
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // cmsContext
            // 
            this.cmsContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxRename,
            this.toolStripSeparator1,
            this.ctxDelete});
            this.cmsContext.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.cmsContext.Name = "cmsContext";
            this.cmsContext.Size = new System.Drawing.Size(118, 54);
            this.cmsContext.Text = "Manage Audio File";
            // 
            // ctxRename
            // 
            this.ctxRename.Image = ((System.Drawing.Image)(resources.GetObject("ctxRename.Image")));
            this.ctxRename.Name = "ctxRename";
            this.ctxRename.Size = new System.Drawing.Size(117, 22);
            this.ctxRename.Text = "Rename";
            this.ctxRename.Click += new System.EventHandler(this.ctxRename_Click);
            // 
            // ctxDelete
            // 
            this.ctxDelete.Image = ((System.Drawing.Image)(resources.GetObject("ctxDelete.Image")));
            this.ctxDelete.Name = "ctxDelete";
            this.ctxDelete.Size = new System.Drawing.Size(117, 22);
            this.ctxDelete.Text = "Delete";
            this.ctxDelete.Click += new System.EventHandler(this.ctxDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // ManageAudioClips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 672);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ManageAudioClips";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ManageAudioClips";
            this.Load += new System.EventHandler(this.ManageAudioClips_Load);
            this.Shown += new System.EventHandler(this.ManageAudioClips_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.cmsContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnImport;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpAudio;
        private System.Windows.Forms.ContextMenuStrip cmsContext;
        private System.Windows.Forms.ToolStripMenuItem ctxRename;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ctxDelete;
    }
}