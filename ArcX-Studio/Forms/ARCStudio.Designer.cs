namespace ArcX_Studio
{
    partial class ARCStudio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ARCStudio));
            this.TreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.extractArc = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildArc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.rebuildArc = new System.Windows.Forms.ToolStripMenuItem();
            this.repairArc = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.checkUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.miniToolStrip = new System.Windows.Forms.StatusStrip();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.EntryList = new System.Windows.Forms.TreeView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.DimLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.FileSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.OffsetLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.refreshTree = new System.Windows.Forms.ToolStripMenuItem();
            this.addFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteFile = new System.Windows.Forms.ToolStripMenuItem();
            this.imageViewer = new ArcX_Studio.PictureBoxWithInterpolationMode();
            this.pictureBox1 = new ArcX_Studio.PictureBoxWithInterpolationMode();
            this.TreeMenu.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TreeMenu
            // 
            this.TreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replaceToolStripMenuItem,
            this.extractToolStripMenuItem,
            this.toolStripSeparator5,
            this.addFile,
            this.deleteFile});
            this.TreeMenu.Name = "TreeMenu";
            this.TreeMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.TreeMenu.Size = new System.Drawing.Size(129, 98);
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.replaceToolStripMenuItem.Text = "Replace";
            this.replaceToolStripMenuItem.Click += new System.EventHandler(this.replaceToolStripMenuItem_Click);
            // 
            // extractToolStripMenuItem
            // 
            this.extractToolStripMenuItem.Name = "extractToolStripMenuItem";
            this.extractToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.extractToolStripMenuItem.Text = "Extract";
            this.extractToolStripMenuItem.Click += new System.EventHandler(this.extractToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.AutoSize = false;
            this.menuStrip.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.buildToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(1105, 25);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeFileToolStripMenuItem,
            this.SaveAsBtn,
            this.extractArc,
            this.toolStripSeparator2,
            this.refreshTree});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::ArcX_Studio.Properties.Resources.ZZFolder;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + Z";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.openToolStripMenuItem.Text = "Open Archive";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // closeFileToolStripMenuItem
            // 
            this.closeFileToolStripMenuItem.Name = "closeFileToolStripMenuItem";
            this.closeFileToolStripMenuItem.ShortcutKeyDisplayString = "Alt + S";
            this.closeFileToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.closeFileToolStripMenuItem.Text = "Close File...";
            this.closeFileToolStripMenuItem.Click += new System.EventHandler(this.closeFileToolStripMenuItem_Click);
            // 
            // SaveAsBtn
            // 
            this.SaveAsBtn.Name = "SaveAsBtn";
            this.SaveAsBtn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.SaveAsBtn.Size = new System.Drawing.Size(193, 22);
            this.SaveAsBtn.Text = "Save As...";
            this.SaveAsBtn.Click += new System.EventHandler(this.SaveAsBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(190, 6);
            // 
            // extractArc
            // 
            this.extractArc.Name = "extractArc";
            this.extractArc.Size = new System.Drawing.Size(193, 22);
            this.extractArc.Text = "Extract Archive...";
            this.extractArc.Visible = false;
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildArc,
            this.toolStripSeparator4,
            this.rebuildArc,
            this.repairArc});
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(46, 19);
            this.buildToolStripMenuItem.Text = "Build";
            // 
            // buildArc
            // 
            this.buildArc.Image = ((System.Drawing.Image)(resources.GetObject("buildArc.Image")));
            this.buildArc.Name = "buildArc";
            this.buildArc.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.buildArc.Size = new System.Drawing.Size(199, 22);
            this.buildArc.Text = "Build Archive";
            this.buildArc.Click += new System.EventHandler(this.buildArc_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(196, 6);
            this.toolStripSeparator4.Visible = false;
            // 
            // rebuildArc
            // 
            this.rebuildArc.Name = "rebuildArc";
            this.rebuildArc.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.rebuildArc.Size = new System.Drawing.Size(199, 22);
            this.rebuildArc.Text = "Rebuild Archive";
            this.rebuildArc.Visible = false;
            // 
            // repairArc
            // 
            this.repairArc.Name = "repairArc";
            this.repairArc.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.repairArc.Size = new System.Drawing.Size(199, 22);
            this.repairArc.Text = "Repair Archive";
            this.repairArc.Click += new System.EventHandler(this.repairArc_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem,
            this.toolStripSeparator3,
            this.checkUpdate});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 19);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("infoToolStripMenuItem.Image")));
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.infoToolStripMenuItem.Text = "About";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(176, 6);
            this.toolStripSeparator3.Visible = false;
            // 
            // checkUpdate
            // 
            this.checkUpdate.Name = "checkUpdate";
            this.checkUpdate.Size = new System.Drawing.Size(179, 22);
            this.checkUpdate.Text = "Check for updates...";
            this.checkUpdate.Visible = false;
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AccessibleName = "New item selection";
            this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.Location = new System.Drawing.Point(1, 1);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.miniToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.miniToolStrip.Size = new System.Drawing.Size(1072, 22);
            this.miniToolStrip.SizingGrip = false;
            this.miniToolStrip.TabIndex = 7;
            this.miniToolStrip.Visible = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(173, 29);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(932, 503);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // EntryList
            // 
            this.EntryList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.EntryList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EntryList.ContextMenuStrip = this.TreeMenu;
            this.EntryList.Dock = System.Windows.Forms.DockStyle.Left;
            this.EntryList.Indent = 18;
            this.EntryList.Location = new System.Drawing.Point(0, 25);
            this.EntryList.Name = "EntryList";
            this.EntryList.Size = new System.Drawing.Size(173, 507);
            this.EntryList.TabIndex = 7;
            this.EntryList.Visible = false;
            this.EntryList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.EntryList_AfterSelect);
            this.EntryList.DoubleClick += new System.EventHandler(this.EntryList_DoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DimLabel,
            this.FileSize,
            this.OffsetLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 510);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(1105, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Visible = false;
            // 
            // DimLabel
            // 
            this.DimLabel.Name = "DimLabel";
            this.DimLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // FileSize
            // 
            this.FileSize.Name = "FileSize";
            this.FileSize.Size = new System.Drawing.Size(0, 17);
            // 
            // OffsetLabel
            // 
            this.OffsetLabel.Name = "OffsetLabel";
            this.OffsetLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // refreshTree
            // 
            this.refreshTree.Name = "refreshTree";
            this.refreshTree.Size = new System.Drawing.Size(193, 22);
            this.refreshTree.Text = "Refresh";
            this.refreshTree.Click += new System.EventHandler(this.refreshTree_Click);
            // 
            // addFile
            // 
            this.addFile.Name = "addFile";
            this.addFile.Size = new System.Drawing.Size(128, 22);
            this.addFile.Text = "Add File";
            this.addFile.Click += new System.EventHandler(this.addFile_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(125, 6);
            // 
            // deleteFile
            // 
            this.deleteFile.Name = "deleteFile";
            this.deleteFile.Size = new System.Drawing.Size(128, 22);
            this.deleteFile.Text = "Delete File";
            this.deleteFile.Click += new System.EventHandler(this.deleteFile_Click);
            // 
            // imageViewer
            // 
            this.imageViewer.BackColor = System.Drawing.Color.Transparent;
            this.imageViewer.DrawFrame = false;
            this.imageViewer.FrameColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(160)))), ((int)(((byte)(30)))));
            this.imageViewer.FrameThickness = 1;
            this.imageViewer.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.imageViewer.KeepAspectRatio = true;
            this.imageViewer.Location = new System.Drawing.Point(173, 25);
            this.imageViewer.Name = "imageViewer";
            this.imageViewer.Size = new System.Drawing.Size(932, 507);
            this.imageViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageViewer.TabIndex = 4;
            this.imageViewer.TabStop = false;
            this.imageViewer.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.DrawFrame = false;
            this.pictureBox1.FrameColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(160)))), ((int)(((byte)(30)))));
            this.pictureBox1.FrameThickness = 4;
            this.pictureBox1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.pictureBox1.KeepAspectRatio = true;
            this.pictureBox1.Location = new System.Drawing.Point(200, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(570, 215);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // ARCStudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1105, 532);
            this.Controls.Add(this.EntryList);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.imageViewer);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.richTextBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ARCStudio";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArcX Studio LCE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TreeMenu.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip TreeMenu;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractToolStripMenuItem;
        private PictureBoxWithInterpolationMode pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem closeFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem SaveAsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.StatusStrip miniToolStrip;
        private PictureBoxWithInterpolationMode imageViewer;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TreeView EntryList;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel DimLabel;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildArc;
        private System.Windows.Forms.ToolStripMenuItem rebuildArc;
        private System.Windows.Forms.ToolStripMenuItem repairArc;
        private System.Windows.Forms.ToolStripStatusLabel FileSize;
        private System.Windows.Forms.ToolStripStatusLabel OffsetLabel;
        private System.Windows.Forms.ToolStripMenuItem checkUpdate;
        private System.Windows.Forms.ToolStripMenuItem extractArc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem refreshTree;
        private System.Windows.Forms.ToolStripMenuItem addFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem deleteFile;
    }
}