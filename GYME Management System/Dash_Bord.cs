using GYME_Management_System.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYME_Management_System
{

    public partial class Dash_Bord : Form
    {

        Customers cus = new Customers();
        Trainer_Registration tr = new Trainer_Registration();
        Users_Registration usr = new Users_Registration();
        Settings set = new Settings();
        Pyment py = new Pyment();
        Generate_Bill gb = new Generate_Bill();
        Home hm = new Home();
        Report rp = new Report();



        public Dash_Bord()
        {
            InitializeComponent();
        }

        void Movesidepanel(Control btn)
        {
            movePanel.Top = btn.Top;
            movePanel.Height = btn.Height;
        }

        private void Dash_Bord_Load(object sender, EventArgs e)
        {
            hm.Dock = DockStyle.Fill;
            desktopPanel.Controls.Clear();
            desktopPanel.Controls.Add(hm);
        }

      

        private void btn_player_Click(object sender, EventArgs e)
        {
            
            


        }

        private void btn_Trainer_Click(object sender, EventArgs e)
        {
          
               


        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            Movesidepanel(btn_report);
        }

        private void btn_users_Click(object sender, EventArgs e)
        {
            
        }
        private void btn_settings_Click(object sender, EventArgs e)
        {
           
        }

        private void movesidepanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void trainer_Registration1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Byment_Click(object sender, EventArgs e)
        {
           

        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            

    
        }

        private void button1_Click(object sender, EventArgs e)
        {
          

        }

        private void MenueVerticle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btn_report_Click_1(object sender, EventArgs e)
        {
            Movesidepanel(btn_report);

            rp.Dock = DockStyle.Fill;
            desktopPanel.Controls.Clear();
            desktopPanel.Controls.Add(rp);
        }

        private void btn_Home_Click_1(object sender, EventArgs e)
        {
            Movesidepanel(btn_Home);

            hm.Dock = DockStyle.Fill;
            desktopPanel.Controls.Clear();
            desktopPanel.Controls.Add(hm);
        }

        private void btn_settings_Click_1(object sender, EventArgs e)
        {
            Movesidepanel(btn_settings);

            set.Dock = DockStyle.Fill;
            desktopPanel.Controls.Clear();
            desktopPanel.Controls.Add(set);
        }

        private void btn_GenerateBill_Click(object sender, EventArgs e)
        {
            Movesidepanel(btn_GenerateBill);

            gb.Dock = DockStyle.Fill;
            desktopPanel.Controls.Clear();
            desktopPanel.Controls.Add(gb);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void btn_player_Click_1(object sender, EventArgs e)
        {
            Movesidepanel(btn_player);
            cus.Dock = DockStyle.Fill;
            desktopPanel.Controls.Clear();
            desktopPanel.Controls.Add(cus);
        }

        private void btn_users_Click_1(object sender, EventArgs e)
        {
            Movesidepanel(btn_users);

            usr.Dock = DockStyle.Fill;
            desktopPanel.Controls.Clear();
            desktopPanel.Controls.Add(usr);
        }

        private void btn_Byment_Click_1(object sender, EventArgs e)
        {
            Movesidepanel(btn_Byment);

            py.Dock = DockStyle.Fill;
            desktopPanel.Controls.Clear();
            desktopPanel.Controls.Add(py);
        }

        private void btn_Trainer_Click_1(object sender, EventArgs e)
        {
            Movesidepanel(btn_Trainer);
            tr.Dock = DockStyle.Fill;
            desktopPanel.Controls.Clear();
            desktopPanel.Controls.Add(tr);
        }
    }
}
