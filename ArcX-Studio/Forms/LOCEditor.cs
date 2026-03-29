using DarkModeForms;
using Lang;
using Lang.models;
using System;
using System.Windows.Forms;

namespace ArcX_Studio.ARC
{
    public partial class LOCEditor : Form
    {
        private DarkModeCS dm = null;
        string openedloc = "";

        public LOCEditor(string localise)
        {
            InitializeComponent();
            menuStrip1.Renderer = new MenuRenderer();
            DarkModeCS.ExcludeFromProcessing(menuStrip1);
            openedloc = localise;
            LanguagesParser languagesParser = new LanguagesParser();
            languagesContainer_0 = languagesParser.Parse(localise);
            method_5();
            method_4(languagesContainer_0);

            dm = new DarkModeCS(this)
            {
                ColorMode = DarkModeCS.DisplayMode.DarkMode
            };
        }

        private void tbMessage_TextChanged(object sender, EventArgs e)
        {
            if (messageEntry_0 != null)
            {
                messageEntry_0.Message = tbMessage.Text;
            }
        }

        void method_5()
        {
            messageEntry_0 = null;
            tbMessage.Clear();
        }

        private void method_4(LanguagesContainer languagesContainer_1)
        {
            foreach (string text in languagesContainer_1.Languages.Keys)
            {
                ListViewItem listViewItem = new ListViewItem(text);
                listViewItem.Tag = languagesContainer_1.Languages[text];
                duohnRabql.Items.Add(listViewItem);
            }
        }

        private void method_6(global::System.Collections.Generic.List<MessageEntry> list_0)
        {
            lvMessages.Items.Clear();
            int num = 1;
            foreach (MessageEntry messageEntry in list_0)
            {
                ListViewItem listViewItem = new ListViewItem(num.ToString());
                listViewItem.Tag = messageEntry;
                listViewItem.SubItems.Add(messageEntry.Message);
                lvMessages.Items.Add(listViewItem);
                num++;
            }
        }

        private void duohnRabql_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (duohnRabql.SelectedItems.Count > 0)
            {
                method_5();
                LanguageEntry languageEntry = duohnRabql.SelectedItems[0].Tag as LanguageEntry;
                method_6(languageEntry.Messages);
            }
        }

        private void lvMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvMessages.SelectedItems.Count > 0)
            {
                MessageEntry messageEntry = this.lvMessages.SelectedItems[0].Tag as MessageEntry;
                this.messageEntry_0 = messageEntry;
                this.tbMessage.Text = messageEntry.Message;
            }
        }

        private void saveLoc_Click(object sender, EventArgs e)
        {
            if (this.languagesContainer_0 != null)
            {
                if (!string.IsNullOrWhiteSpace(openedloc))
                {
                    LanguageBuilder languageBuilder = new LanguageBuilder();
                    languageBuilder.Build(languagesContainer_0, openedloc);
                    Messenger.MessageBox("Languages save has completed.", "Save completed", MessageBoxButtons.OK, MsgIcon.Success);
                }
            }
        }
    }
}
