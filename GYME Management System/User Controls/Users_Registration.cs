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

    public partial class Users_Registration : UserControl
    {

        public Users_Registration()
        {
            InitializeComponent();
            LoadData();
        }

        SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = GYMMS; Integrated Security = True");

        private void Users_Registration_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void ClearData()
        {

            txt_UserID.Clear();
            txt_UName.Text = "";
            txt_Email.Clear();
            txt_Password.Clear();
            cmb_UserRole.Text = "";
        }
        void LoadData()
        {
            string sql = "select * from Users";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_UName.Text == "" || txt_Email.Text == "" || txt_Password.Text == "")
            {
                MessageBox.Show("Plase Fill The Blanks ", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                txt_UName.Focus();
            }
            else
            {
                string sql = "INSERT INTO USERS (Username,Email,Password,UserRole) VALUES('" + txt_UName.Text + "','" + txt_Email.Text + "','" + txt_Password.Text + "',+'" + cmb_UserRole.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("the New User is seccess fully saved ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadData();
                ClearData();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete these user", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {

                string sql = "DELETE FROM Users WHERE User_ID = ('" + txt_UserID.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(" The Selected user was seccessfully Deleted  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadData();
                ClearData();
            }
            else
            {

            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txt_UName.Text == "" || txt_Email.Text == "" || txt_Password.Text == "")
            {
                MessageBox.Show("Plase Fill The Blanks ", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                txt_UName.Focus();
            }
            else
            {
                string sql = "UPDATE Users SET Username = '" + txt_UName.Text + "',Email = '" + txt_Email.Text + "',Password = '" + txt_Password.Text + "',UserRole = +'" + cmb_UserRole.Text + "' WHERE User_ID = '" + txt_UserID.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("the  User Data is seccess fully UPDATED  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadData();
                ClearData();
            }

        }

        private void btn_close_Click(object sender, EventArgs e)
        {


            ClearData();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txt_UserID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txt_UName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txt_Email.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txt_Password.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            cmb_UserRole.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            
          
        }
    }
}
