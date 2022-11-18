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

            nameLeft.Text  = registry.GetValue("nameLeft", "Left").ToString();
            nameRight.Text = registry.GetValue("nameRight", "Right").ToString();

            Save.Enabled = false;
        }

        private void nameLeft_TextChanged(object sender, EventArgs e)
        {
            Save.Enabled = true;
        }

        private void nameRight_TextChanged(object sender, EventArgs e)
        {
            Save.Enabled = true;
        }
       
    }
}
