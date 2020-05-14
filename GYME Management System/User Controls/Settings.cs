using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYME_Management_System.User_Controls
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ForgottPassword fg = new ForgottPassword();
            fg.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Users_Registration usr = new Users_Registration();
            usr.Dock = DockStyle.Fill;
            SettingPanel.Controls.Clear();
            SettingPanel.Controls.Add(usr);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePassword chp = new ChangePassword();
            chp.Dock = DockStyle.Fill;
            SettingPanel.Controls.Clear();
            SettingPanel.Controls.Add(chp);
        }
    }
}
