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
    public partial class ChangeUserRole : UserControl
    {
        public ChangeUserRole()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = GYMMS; Integrated Security = True");

        private void btn_update_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE Users SET  UserRole = +'" + cmb_UserRole.Text + "' WHERE Username= '" + txt_UName.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("the  User Data is seccess fully UPDATED  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
    }
}
