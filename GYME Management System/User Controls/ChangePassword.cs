using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GYME_Management_System.User_Controls
{
    public partial class ChangePassword : UserControl
    {
        public ChangePassword()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = GYMMS; Integrated Security = True");

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE Users SET Password = '" + txt_Password.Text + "'WHERE Username = '" + txt_UName.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("the  User Password is seccess fully Changed ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
    }
}
