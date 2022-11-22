using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Win32;


namespace SkyHat
{
    public partial class Config : Form
    {
        private RegistryKey registry;

        public Config()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Configs are changed. Please confirm save", "Save configs confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            switch (result)
            {
                case DialogResult.Yes:
                    registry.SetValue("nameLeft", nameLeft.Text);
                    registry.SetValue("nameRight", nameRight.Text);
                    
                    registry.SetValue("telegramEnabled", telegramEnabled.Checked ? "1" : "0");
                    registry.SetValue("telegramUrl", telegramUrl.Text);
                    registry.SetValue("telegramHash", telegramHash.Text);

                    Close();
                    break;

                case DialogResult.No:
                    Close();
                    break;
            }
        }

        private void Config_Load(object sender, EventArgs e)
        {
            registry = Registry.CurrentUser.CreateSubKey("SOFTWARE\\mo\\SkyHat");

            // names
            nameLeft.Text  = registry.GetValue("nameLeft", "Left").ToString();
            nameRight.Text = registry.GetValue("nameRight", "Right").ToString();

            // telegram
            telegramEnabled.Checked = registry.GetValue("telegramEnabled", "0").ToString() == "1";
            telegramUrl.Text = registry.GetValue("telegramUrl", "https://astrohostel.ru/telegram/skyhat").ToString();
            telegramHash.Text = registry.GetValue("telegramHash", Guid.NewGuid()).ToString();

            telegramUrl.Enabled = telegramEnabled.Checked;
            telegramHash.Enabled = telegramEnabled.Checked;
            telegramPool.Enabled = telegramEnabled.Checked;

            Save.Enabled = false;
        }

        private void fields_TextChanged(object sender, EventArgs e)
        {
            Save.Enabled = true;
        }

        private void hash_Click(object sender, EventArgs e)
        {
            telegramHash.SelectAll();
            Clipboard.SetText(telegramHash.Text);

            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;

            toolTip1.SetToolTip(telegramHash, "Copied to clipboard");
        }

        private void telegramEnabled_CheckedChanged(object sender, EventArgs e)
        {
            telegramUrl.Enabled = telegramEnabled.Checked;
            telegramHash.Enabled = telegramEnabled.Checked;
            telegramPool.Enabled = telegramEnabled.Checked;

            Save.Enabled = true;
        }

    }
}
