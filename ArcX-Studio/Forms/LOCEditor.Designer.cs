namespace ArcX_Studio.ARC
{
    partial class LOCEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOCEditor));
            this.duohnRabql = new System.Windows.Forms.ListView();
            this.columnHeader_0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvMessages = new System.Windows.Forms.ListView();
            this.columnHeader_2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLoc = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // duohnRabql
            // 
            this.duohnRabql.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.duohnRabql.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.duohnRabql.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.duohnRabql.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_0});
            this.duohnRabql.Dock = System.Windows.Forms.DockStyle.Left;
            this.duohnRabql.ForeColor = System.Drawing.Color.White;
            this.duohnRabql.FullRowSelect = true;
            this.duohnRabql.HideSelection = false;
            this.duohnRabql.Location = new System.Drawing.Point(0, 24);
            this.duohnRabql.Margin = new System.Windows.Forms.Padding(41, 19, 41, 19);
            this.duohnRabql.Name = "duohnRabql";
            this.duohnRabql.Size = new System.Drawing.Size(214, 597);
            this.duohnRabql.TabIndex = 4;
            this.duohnRabql.UseCompatibleStateImageBehavior = false;
            this.duohnRabql.View = System.Windows.Forms.View.Details;
            this.duohnRabql.SelectedIndexChanged += new System.EventHandler(this.duohnRabql_SelectedIndexChanged);
            // 
            // columnHeader_0
            // 
            this.columnHeader_0.Text = "Languages";
            this.columnHeader_0.Width = 105;
            // 
            // lvMessages
            // 
            this.lvMessages.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lvMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lvMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_1,
            this.columnHeader_2});
            this.lvMessages.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvMessages.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lvMessages.ForeColor = System.Drawing.Color.White;
            this.lvMessages.HideSelection = false;
            this.lvMessages.Location = new System.Drawing.Point(0, 0);
            this.lvMessages.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lvMessages.Name = "lvMessages";
            this.lvMessages.Size = new System.Drawing.Size(654, 348);
            this.lvMessages.TabIndex = 5;
            this.lvMessages.UseCompatibleStateImageBehavior = false;
            this.lvMessages.View = System.Windows.Forms.View.Details;
            this.lvMessages.SelectedIndexChanged += new System.EventHandler(this.lvMessages_SelectedIndexChanged);
            // 
            // columnHeader_2
            // 
            this.columnHeader_2.DisplayIndex = 0;
            this.columnHeader_2.Text = "Messages";
            this.columnHeader_2.Width = 609;
            // 
            // columnHeader_1
            // 
            this.columnHeader_1.Text = "#";
            this.columnHeader_1.Width = 40;
            // 
            // tbMessage
            // 
            this.tbMessage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbMessage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.tbMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tbMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMessage.ForeColor = System.Drawing.Color.White;
            this.tbMessage.Location = new System.Drawing.Point(0, 350);
            this.tbMessage.Margin = new System.Windows.Forms.Padding(41, 19, 41, 19);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbMessage.Size = new System.Drawing.Size(654, 328);
            this.tbMessage.TabIndex = 6;
            this.tbMessage.TextChanged += new System.EventHandler(this.tbMessage_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.menuStrip1.Size = new System.Drawing.Size(868, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveLoc});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveLoc
            // 
            this.saveLoc.Image = ((System.Drawing.Image)(resources.GetObject("saveLoc.Image")));
            this.saveLoc.Name = "saveLoc";
            this.saveLoc.ShortcutKeyDisplayString = "Ctrl + Z";
            this.saveLoc.Size = new System.Drawing.Size(145, 22);
            this.saveLoc.Text = "Save";
            this.saveLoc.Click += new System.EventHandler(this.saveLoc_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvMessages);
            this.panel1.Controls.Add(this.tbMessage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(214, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(41, 19, 41, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(654, 597);
            this.panel1.TabIndex = 8;
            // 
            // LOCEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(868, 621);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.duohnRabql);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(41, 19, 41, 19);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOCEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOC Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Lang.models.LanguagesContainer languagesContainer_0;

        private Lang.models.MessageEntry messageEntry_0;

        private System.Windows.Forms.ListView duohnRabql;
        private System.Windows.Forms.ColumnHeader columnHeader_0;
        private System.Windows.Forms.ListView lvMessages;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLoc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader columnHeader_1;
        private System.Windows.Forms.ColumnHeader columnHeader_2;
    }
}