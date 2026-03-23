using DarkModeForms;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArcX_Studio
{
    public partial class ARCStudio : Form
    {
        public ARCStudio()
        {
            InitializeComponent();
            SetBorderColor(Color.FromArgb(0, 122, 204));
            mica();

            menuStrip.Renderer = new MenuRenderer();
            statusStrip1.Renderer = new StatusStripRenderer();
            DarkModeCS.ExcludeFromProcessing(menuStrip);
            DarkModeCS.ExcludeFromProcessing(statusStrip1);
            #region DarkMode
            dm = new DarkModeCS(this)
            {
                ColorMode = DarkModeCS.DisplayMode.DarkMode
            };
            foreach (ToolStripItem item in statusStrip1.Items)
            {
                item.ForeColor = Color.Gainsboro;
            }
            foreach (ToolStripMenuItem item in menuStrip.Items)
            {
                item.DropDown.Padding = new Padding(0);
            }
            #endregion
        }

        #region RPC 

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //RPC.SetArcEditorPresence();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            //RPC.SetArcEditorPresence(arcfile);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            //RPC.ClearPresence();
        }
        #endregion

        #region Variables

        private DarkModeCS dm = null;
        const int DWMWA_BORDER_COLOR = 34;
        const int DWMWA_SYSTEMBACKDROP_TYPE = 38;
        string arcfile = "";
        string currentFilePath;
        bool closingInProgress = false;
        string appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ArcXStudios", "Media");

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Messenger.MessageBox("========== ArcX Studio ==========\n========== Developed by DescZ ==========\n======== v1.2 Release - Build 02 ==========", "About", MessageBoxButtons.OK, MsgIcon.None);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(32, 32, 30),
                Color.FromArgb(45, 45, 45),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        #endregion

        #region Saving and opening and closing and repairing

        private async void repairArc_Click(object sender, EventArgs e)
        {
            using (var lf = new LoadingForm("Initializing repair engine..."))
            {
                lf.Show();
                await Task.Delay(100);
                await Task.Run(delegate 
                {
                    ArchiveWorker.RepairArchive(arcfile, lf);
                });
            }
            Messenger.MessageBox("Repair completed successfully", "Success", MessageBoxButtons.OK, MsgIcon.Success);
        }

        public async void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.CheckFileExists = true;
                    ofd.RestoreDirectory = true;
                    ofd.Filter = "ARC (Minecraft Legecy Console Archive)|*.arc";
                    ofd.Title = "Open a file - ArcX Studio";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        EntryList?.Show();
                        extractArc.Visible = true;
                        //RPC.SetLoadingFormPresence();
                        using (var loading = new LoadingForm("Opening the file..."))
                        {
                            //arcPicture.Hide();
                            loading.Show();
                            await Task.Delay(100);

                            try
                            {
                                await Task.Run(() =>
                                {
                                    if (Path.GetExtension(ofd.FileName).Equals(".arc", StringComparison.OrdinalIgnoreCase))
                                    {
                                        ArchiveWorker ps3ARCWorker = new ArchiveWorker();
                                        ps3ARCWorker.ExtractArchive(ofd.FileName, appdata, loading);

                                        arcfile = ofd.FileName;
                                        currentFilePath = Path.GetFileName(arcfile);
                                        extractArc.Text = $"Extract {currentFilePath}...";
                                        SetStatus(Path.GetFileName(arcfile));
                                        //RPC.SetArcEditorPresence(arcfile);

                                        // Update UI on UI thread
                                        this.Invoke(new Action(() =>
                                        {
                                            EntryList.Nodes.Clear();
                                            openArc(arcfile);
                                            UpdateFileMenuState(true);
                                        }));
                                    }
                                    else
                                    {
                                        this.Invoke(new Action(() =>
                                        {
                                            MessageBox.Show("Check Data", "Data Error");
                                        }));
                                    }
                                });
                            }
                            catch (Exception err)
                            {
                                this.Invoke(new Action(() =>
                                {
                                    MessageBox.Show("error\n" + err.ToString());
                                }));
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The ARC you're trying to use currently isn't supported");
            }
        }

        private void buildArc_Click(object sender, EventArgs e)
        {
            DisposeImages();
            richTextBox1.Show();
            string currentTime = DateTime.Now.ToString("h:mm tt");
            currentFilePath = Path.GetFileName(arcfile);
            try
            {
                ArchiveWorker ARCWorker = new ArchiveWorker();
                ARCWorker.BuildArchive(arcfile, appdata);
                richTextBox1.Text = $"Build started at {currentTime}...\n1------ Build started: File: {arcfile}, Configuration: Default ------\n2> {arcfile} -> {currentFilePath}\n=============== Build: 1 succeeded, 0 failed ===============\n=============== Build completed at {currentTime} ===============";
            }
            catch (Exception err)
            {
                richTextBox1.Text = $"Build started at {currentTime}...\n1------ Build started: File: {arcfile}, Configuration: Default ------\n2> {arcfile} -> {currentFilePath}\n=============== Build: 0 succeeded, 1 failed ===============\nError: {err.Message.ToString()}";
                statusStrip1.Visible = true;
                SizeLabel2.Text = "Save failed!";
            }
        }

        private void closeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseCurrentFile();
        }

        private void CloseCurrentFile()
        {
            try
            {
                // Clear the current file path
                currentFilePath = string.Empty;
                arcfile = string.Empty;

                // Clear the TreeView
                EntryList.Nodes.Clear();

                // Clear the display areas
                richTextBox1.Text = null;
                richTextBox1.Hide();
                statusStrip1.Hide();
                //arcPicture.Show();
                this.Text = "ArcX Studio";

                if (pictureBoxWithInterpolationMode2 != null)
                {
                    pictureBoxWithInterpolationMode2.Image = null;
                    pictureBoxWithInterpolationMode2.Invalidate();
                }

                // Clear extracted files directory
                ClearExtractedFiles();

                // Update RPC presence
                //RPC.SetArcEditorPresence();

                // Update UI state
                UpdateFileMenuState(false);

                Messenger.MessageBox("File closed successfully.", "Close File", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error closing file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearExtractedFiles()
        {
            try
            {
                if (Directory.Exists(appdata))
                {
                    DirectoryInfo di = new DirectoryInfo(appdata);

                    foreach (FileInfo file in di.GetFiles())
                    {
                        try { file.Delete(); } catch { }
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        try { dir.Delete(true); } catch { }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Warning: Could not clear extracted files: {ex.Message}");
            }
        }

        public void UpdateFileMenuState(bool fileOpen)
        {
            // Enable/disable menu items based on whether a file is open
            buildArc.Enabled = fileOpen;
            repairArc.Enabled = fileOpen;
            rebuildArc.Enabled = fileOpen;
            closeFileToolStripMenuItem.Enabled = fileOpen;
            SaveAsBtn.Enabled = fileOpen;
            extractArc.Enabled = fileOpen;
        }

        private void SaveFile(string file)
        {
            try
            {
                ArchiveWorker ps3ARCWorker = new ArchiveWorker();
                ps3ARCWorker.BuildArchive(file, appdata);
                Messenger.MessageBox("Saved Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message);
            }
        }

        #endregion

        #region Loading form

        private void Form1_Load(object sender, EventArgs e)
        {
            // Cleans leftover files if crash or End task happenes
            if (Path.GetFileName(appdata) == "Media")
            {
                try
                {
                    Directory.Delete(appdata, true);
                }
                catch { }
            }
           
            UpdateFileMenuState(false);
        }

        private void SetStatus(string message)
        {
            if (message != null)
            {
                Text = message + " - ArcX Studio"; // Set status based on the current file 
            }
            else
            {
                Text = "ArcX Studio";
            }
        }

        #endregion

        #region Delete files when program close

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closingInProgress) return;

            e.Cancel = true;
            closingInProgress = true;

            using (var loading = new LoadingForm("Cleaning up"))
            {
                loading.Show(this);
                await Task.Delay(5000);

                try
                {
                    if (Directory.Exists(appdata))
                    {
                        Directory.Delete(appdata, true); // Delete ARC folder that contains the files extracted (if exists)
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Cleanup warning: {ex.Message}");
                }
                closingInProgress = false;
                loading.Hide();
                Application.ExitThread(); // close loop (do not use Application.Exit(); unless only 1 form is opened
            }
        }

        #endregion

        #region Load ARC
        /// <summary>
        /// Handles Archive extracted in the appDir and building TreeNodes
        /// </summary>
        /// <param name="filePath"></param>
        public void openArc(string filePath)
        {
            // Build image list
            ImageList icons = new ImageList();
            icons.ColorDepth = ColorDepth.Depth32Bit;
            icons.ImageSize = new Size(20, 20);

            icons.Images.Add(ArcX_Studio.Properties.Resources.ZZFolder);   // 0
            icons.Images.Add(ArcX_Studio.Properties.Resources.IMAGE_ICON); // 1
            icons.Images.Add(ArcX_Studio.Properties.Resources.LOC_ICON);   // 2
            icons.Images.Add(ArcX_Studio.Properties.Resources.PCK_ICON);   // 3
            icons.Images.Add(ArcX_Studio.Properties.Resources.FUI_ICON);   // 4
            icons.Images.Add(ArcX_Studio.Properties.Resources.NBT_ICON);   // 5
            icons.Images.Add(ArcX_Studio.Properties.Resources.TXT_ICON);   // 6
            icons.Images.Add(ArcX_Studio.Properties.Resources.ZUnknown);   // 7

            EntryList.ImageList = icons; // Sets files icon image list

            EntryList.BeginUpdate();
            EntryList.Nodes.Clear();

            // If extracted folder doesn't exist, return
            if (!Directory.Exists(appdata))
            {
                MessageBox.Show("No extracted files found. Extraction may have failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Add directories (top-level) and their content recursively
            try
            {
                // Add top-level directories
                foreach (string topDir in Directory.GetDirectories(appdata))
                {
                    TreeNode topNode = new TreeNode(Path.GetFileName(topDir))
                    {
                        Tag = topDir,
                        ImageIndex = 0,
                        SelectedImageIndex = 0
                    };

                    // Add subdirectories and files recursively
                    AddDirectoryNodes(topDir, topNode);

                    EntryList.Nodes.Add(topNode);
                }

                // Add files in root of appdata
                foreach (string file in Directory.GetFiles(appdata))
                {
                    string ext = Path.GetExtension(file).ToString();
                    TreeNode fileNode = new TreeNode(Path.GetFileName(file))
                    {
                        Tag = file
                    };

                    // Set icons based on extension
                    switch (ext)
                    {
                        case ".png":
                        case ".jpg":
                            fileNode.ImageIndex = 1;
                            fileNode.SelectedImageIndex = 1;
                            break;
                        case ".loc":
                            fileNode.ImageIndex = 2;
                            fileNode.SelectedImageIndex = 2;
                            break;
                        case ".fui":
                            fileNode.ImageIndex = 4;
                            fileNode.SelectedImageIndex = 4;
                            break;
                        case ".nbt":
                            fileNode.ImageIndex = 5;
                            fileNode.SelectedImageIndex = 5;
                            break;
                        case ".col":
                            fileNode.ImageIndex = 7;
                            fileNode.SelectedImageIndex = 7;
                            break;
                        case ".txt":
                            fileNode.ImageIndex = 6;
                            fileNode.SelectedImageIndex = 6;
                            break;
                        default:
                            fileNode.ImageIndex = 7;
                            fileNode.SelectedImageIndex = 7;
                            break;
                    }
                    EntryList.Nodes.Add(fileNode);
                }

                // enable related menus
                foreach (ToolStripMenuItem item in fileToolStripMenuItem.DropDownItems)
                {
                    item.Enabled = true;
                    item.Checked = true;
                }

                int fileCount = EntryList.GetNodeCount(true);
            }
            catch (Exception)
            {
               // MessageBox.Show("Error building file tree: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                EntryList.EndUpdate();
            }
        }

        /// <summary>
        /// Recursively add directory nodes to a parent TreeNode
        /// </summary>
        /// <param name="dirPath"></param>
        /// <param name="parentNode"></param>
        private void AddDirectoryNodes(string dirPath, TreeNode parentNode)
        {
            // Add files in this directory
            try
            {
                foreach (string file in Directory.GetFiles(dirPath))
                {
                    string ext = Path.GetExtension(file).ToLowerInvariant();
                    TreeNode node = new TreeNode(Path.GetFileName(file))
                    {
                        Tag = file
                    };

                    switch (ext)
                    {
                        case ".png":
                        case ".jpg":
                            node.ImageIndex = 1;
                            node.SelectedImageIndex = 1;
                            break;
                        case ".loc":
                            node.ImageIndex = 2;
                            node.SelectedImageIndex = 2;
                            break;
                        case ".pck":
                        case ".fui":
                            node.ImageIndex = 4;
                            node.SelectedImageIndex = 4;
                            break;
                        case ".nbt":
                            node.ImageIndex = 5;
                            node.SelectedImageIndex = 5;
                            break;
                        case ".col":
                            node.ImageIndex = 7;
                            node.SelectedImageIndex = 7;
                            break;
                        case ".txt":
                            node.ImageIndex = 6;
                            node.SelectedImageIndex = 6;
                            break;
                        default:
                            node.ImageIndex = 6;
                            node.SelectedImageIndex = 6;
                            break;
                    }
                    parentNode.Nodes.Add(node);
                }

                // Add subDirectories
                foreach (string subDir in Directory.GetDirectories(dirPath))
                {
                    TreeNode subNode = new TreeNode(Path.GetFileName(subDir))
                    {
                        Tag = subDir,
                        ImageIndex = 0,
                        SelectedImageIndex = 0
                    };
                    // Recurse
                    AddDirectoryNodes(subDir, subNode);
                    parentNode.Nodes.Add(subNode);
                }
            }
            catch (Exception ex)
            {
                // ignore per-file errors, but log
                Console.WriteLine($"Error reading directory {dirPath}: {ex.Message}");
            }
        }
        
        // Gets selected file size
        string FormatFileSize(long bytes) 
        {
            if (bytes >= 1024 * 1024)
                return (bytes / 1024f * 1024f).ToString("0.0") + " MB";
            if (bytes >= 1024)
                return (bytes / 1024).ToString("0.0") + " KB";
            return bytes + " Bytes";
        }

        #endregion

        #region Select file

        private void EntryList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (EntryList.SelectedNode == null || EntryList.SelectedNode.Tag == null) // If there are no files in the EntryList, return
                    return;

                string selectedPath = EntryList.SelectedNode.Tag.ToString(); // Selected file from EntryList current path 
                if (File.Exists(selectedPath))
                {
                    FileInfo fi = new FileInfo(selectedPath);
                    FileSize.Text = FormatFileSize(fi.Length);
                }
                string ext = Path.GetExtension(selectedPath).ToLowerInvariant();
               
                if (ext == ".png" || ext == ".jpg")
                {
                    statusStrip1.Visible = true;
                    SizeLabel2.Visible = true;
                    richTextBox1.Hide();
                    pictureBoxWithInterpolationMode2.Show();
                    pictureBoxWithInterpolationMode2.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBoxWithInterpolationMode2.InterpolationMode = InterpolationMode.NearestNeighbor; // DO NOT CHANGE UNLESS OTHER TEXTURE PACK

                    using (var fs = new FileStream(selectedPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (Image skinPicture = Image.FromStream(fs))
                    {
                        pictureBoxWithInterpolationMode2.SetImageWithFade(skinPicture, 200);
                        SizeLabel2.Text = $"{skinPicture.Width} x {skinPicture.Height}"; // Selected image width and height
                    }
                    return;
                }

                else if (ext == ".fui")
                {
                    //statusStrip1.Hide();
                    richTextBox1.Text = "";
                    richTextBox1.Hide();
                    pictureBoxWithInterpolationMode2.Hide();
                    return;
                }

                else if (ext == ".txt")
                {
                    richTextBox1.Show();
                    statusStrip1.Hide();
                    pictureBoxWithInterpolationMode2.Hide();
                    richTextBox1.Text = File.ReadAllText(selectedPath);
                    return;
                }
                else if (Directory.Exists(selectedPath))
                {
                    // Selected node is a folder - show nothing special
                    richTextBox1.Hide();
                    pictureBoxWithInterpolationMode2.Hide();
                    statusStrip1.Visible = false;
                    return;
                }
                else
                {
                    // Other file types
                    richTextBox1.Text = "";
                    richTextBox1.Hide();
                    pictureBoxWithInterpolationMode2.Hide();
                    statusStrip1.Visible = false;
                    return;
                }
            }
            catch 
            {
                
            }
        }

        private void DisposeImages()
        { 
            try
            {
                if (pictureBoxWithInterpolationMode2.Image != null)
                {
                    pictureBoxWithInterpolationMode2.Image.Dispose();
                    pictureBoxWithInterpolationMode2.Image = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch { }
        }

        
        #endregion

        #region Edit text when edited

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (EntryList.SelectedNode != null && EntryList.SelectedNode.Tag != null && Path.GetExtension(EntryList.SelectedNode.Tag.ToString()).ToLowerInvariant() == ".txt")
            {
                try
                {
                    File.WriteAllText(EntryList.SelectedNode.Tag.ToString(), richTextBox1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving text file:  {ex.Message}", "Saving error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        #endregion

        #region Open file when double clicked

        private void EntryList_DoubleClick(object sender, EventArgs e)
        {
            if (EntryList.SelectedNode.Tag != null)
            {
                string selected = EntryList.SelectedNode.Tag.ToString();
                switch (Path.GetExtension(selected).ToLowerInvariant())
                {
                    //Checks to see if selected minefile is a loc file
                    case (".loc"):
                        ARC.LOCEditor le = new ARC.LOCEditor(selected);
                        le.Show();
                        le.BringToFront();
                        break;

                    case (".swf"):
                        Messenger.MessageBox("Not supported");
                        break;

                    case (".png"):
                        extractToolStripMenuItem.PerformClick();
                        break;

                    case (".txt"):
                        extractToolStripMenuItem.PerformClick();
                        break;

                    //Checks to see if selected minefile is a col file
                    case (".col"):
                        Messenger.MessageBox("Not supported");
                        break;


                    //Checks to see if selected minefile is a fui file
                    case (".fui"):
                        Messenger.MessageBox("Not supported");
                        break;


                    // NBT or no extension - attempt to launch NBTExplorer if present
                    case (""):
                    default:
                        /*try
                        {
                            string nbtExe = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\PhoenixApplications\\ARCStudio" + "\\NBTEditor\\NBTExplorer.exe";
                            if (File.Exists(nbtExe))
                            {
                                Process proc = new Process();
                                proc.StartInfo.FileName = nbtExe;
                                proc.StartInfo.Arguments = selected;
                                proc.Start();
                            }
                            else
                            {
                                MessageBox.Show(".NBT Editor Coming Soon!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Could not open editor: " + ex.Message);
                        }*/
                        break;
                }

            }
        }

        #endregion

        #region Extract folder

        private void extractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (EntryList.SelectedNode == null) return;

            if (EntryList.SelectedNode.ImageIndex == 0)
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "Select where to extract the folder";
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        string sourceDir = EntryList.SelectedNode.Tag.ToString();
                        string targetDir = Path.Combine(fbd.SelectedPath, EntryList.SelectedNode.Text);

                        try
                        {
                            CopyDirectory(sourceDir, targetDir);
                            Messenger.MessageBox($"Folder extracted successfully to:\n{targetDir}");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Extraction failed:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                return;
            }

            else
            {
                SaveFileDialog sfd = new SaveFileDialog();

                string ext = Path.GetExtension(EntryList.SelectedNode.Tag.ToString()).ToLowerInvariant();
                switch (ext)
                {
                    case ".png":
                        sfd.Filter = "PNG Image | *.png";
                        break;
                    case ".loc":
                        sfd.Filter = "Localization | *.loc";
                        break;
                    case ".fui":
                        sfd.Filter = "Fuscated Universal Image | *.fui";
                        break;
                    case ".col":
                        sfd.Filter = "Color file | *.col";
                        break;
                    case "":
                        sfd.Filter = "NBT Data | *.nbt";
                        break;
                    default:
                        sfd.Filter = "All Files | *.*";
                        break;
                }
                sfd.FileName = EntryList.SelectedNode.Text;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (ext == ".binka")
                        {
                            System.Diagnostics.Process binkman = new System.Diagnostics.Process();
                            binkman.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\PhoenixApplications\\ARCStudio" + "\\BinkMan\\BinkMan.exe";
                            binkman.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\PhoenixApplications\\ARCStudio" + "\\BinkMan";
                            binkman.Start();
                            binkman.WaitForExit();
                            File.Copy(EntryList.SelectedNode.Tag.ToString(), sfd.FileName, true);
                        }
                        else
                            File.Copy(EntryList.SelectedNode.Tag.ToString(), sfd.FileName, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Extract failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CopyDirectory(string sourceDir, string destinationDir)
        {
            // Create destination if it doesn't exist
            Directory.CreateDirectory(destinationDir);

            // Copy all files
            foreach (var file in Directory.GetFiles(sourceDir))
            {
                string destFile = Path.Combine(destinationDir, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }

            // Copy all subdirectories
            foreach (var subDir in Directory.GetDirectories(sourceDir))
            {
                string destSubDir = Path.Combine(destinationDir, Path.GetFileName(subDir));
                CopyDirectory(subDir, destSubDir);
            }
        }


        #endregion

        #region Replace file

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (EntryList.SelectedNode == null || EntryList.SelectedNode.Tag == null) return;

            string arcFolderPath = EntryList.SelectedNode.Tag.ToString();

            if (EntryList.SelectedNode.ImageIndex == 0)
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "Select where to replace the folder";
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        string sourceFolder = fbd.SelectedPath;

                        ReplaceFolder(sourceFolder, arcFolderPath);
                        Messenger.MessageBox($"Folder replaced successfully from:\n{sourceFolder}", "Success", MessageBoxButtons.OK, MsgIcon.Success);
                        ReloadTree();
                    }
                }
                return;
            }
            else
            {
                OpenFileDialog sfd = new OpenFileDialog();
                sfd.Title = "Replace - ArcX Studio";
                sfd.CheckFileExists = true;
                string ext = Path.GetExtension(EntryList.SelectedNode.Tag.ToString()).ToLowerInvariant();
                switch (ext)
                {
                    case ".png":
                        sfd.Filter = "PNG Image | *.png";
                        break;
                    case ".txt":
                        sfd.Filter = "TXT File | *.txt";
                        break;
                    case ".loc":
                        sfd.Filter = "Localization | *.loc";
                        break;
                    case ".fui":
                        sfd.Filter = "Fuscated Universal Image | *.fui";
                        break;
                    case ".col":
                        sfd.Filter = "Color file | *.col";
                        break;
                    case "":
                        sfd.Filter = "NBT Data | *.nbt";
                        break;
                    default:
                        sfd.Filter = "All Files | *.*";
                        break;
                }
                sfd.FileName = EntryList.SelectedNode.Text;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.Copy(sfd.FileName, EntryList.SelectedNode.Tag.ToString(), true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Replace failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (ext == ".png")
                    {
                        pictureBoxWithInterpolationMode2.Invalidate(); // Refresh PictureBox
                    }
                }
            }
        }
        

        void ReloadTree()
        {
            EntryList.Nodes.Clear();
            openArc(currentFilePath);
        }

        private void ReplaceFolder(string sourceDir, string targetDir)
        { 
            if (Directory.Exists(targetDir))
                Directory.Delete(targetDir, true);
            Directory.CreateDirectory(targetDir);

            CopyFolder(sourceDir, targetDir);
          
        }

        private void CopyFolder(string sourceDir, string targetDir)
        {
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string name = Path.GetFileName(file);
                File.Copy(file, Path.Combine(targetDir, name), true);
            }

            foreach (string dir in Directory.GetDirectories(sourceDir))
            {
                string name = Path.GetFileName(dir);
                string newPath = Path.Combine(targetDir, name);
                Directory.CreateDirectory(newPath);
                CopyFolder(dir, newPath);
            }
        }

        #endregion

        #region Extract full arc

        private void extractFullArcToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (EntryList.Nodes.Count == 0)
            {
                MessageBox.Show("No ARC file loaded");
                return;
            }

            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string output = fbd.SelectedPath;
                    TreeNode root = EntryList.Nodes[0];
                    ExtractFromTree(root, output);
                    Messenger.MessageBox("Successfully Extracted!");
                }
            }
        }

        private void ExtractFromTree(TreeNode node, string outputRoot)
        {
            string srcPath = node.Tag.ToString();
            string destPath = Path.Combine(outputRoot, node.FullPath);
            if (node.ImageIndex == 0)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(destPath));
                File.Copy(srcPath, destPath, true);
            }
            else
            {
                Directory.CreateDirectory(destPath);
                foreach (TreeNode child in node.Nodes)
                    ExtractFromTree(child, outputRoot);
            }
        }

        #endregion

        #region Private methods

        private void SaveAsBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog()
            {
                Filter = "ARC File (*.arc)|*.arc",
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = fileDialog.FileName;
                SaveFile(filePath);
            }
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            Messenger.MessageBox("Still in development :/");
        }

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int dwAttribute, ref int value, int cbAttribute);
        private enum DWM_SYSTEMBACKDROP_TYPE
        {
            DWMSBT_AUTO = 0,
            DWMSBT_NONE = 1,
            DWMSBT_MAINWINDOW = 2,
            Acrylic = 3,
            Tabbed = 4
        }

        void SetBorderColor(Color color)
        {
            int colorRef = ColorTranslator.ToWin32(color);
            DwmSetWindowAttribute(this.Handle, DWMWA_BORDER_COLOR, ref colorRef, sizeof(int));
        }

        void mica()
        {
            int backdrop = (int)DWM_SYSTEMBACKDROP_TYPE.DWMSBT_MAINWINDOW;
            DwmSetWindowAttribute(this.Handle, DWMWA_SYSTEMBACKDROP_TYPE, ref backdrop, sizeof(int));
        }

        #endregion
    }
}
