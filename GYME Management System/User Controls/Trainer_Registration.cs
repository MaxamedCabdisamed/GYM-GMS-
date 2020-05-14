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


namespace GYME_Management_System
{
    public partial class Trainer_Registration : UserControl
    {
        AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
        SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = GYMMS; Integrated Security = True");
        SqlDataAdapter da;

        //Main logic for autocomplete
        public void auto()
        {
            da = new SqlDataAdapter("select T_Name from trainer order by T_Name asc", con);
            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    coll.Add(dt.Rows[i]["T_Name"].ToString());
                }
            }

            else
            {
                MessageBox.Show("Name not found!!! ", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

            txt_search.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_search.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_search.AutoCompleteCustomSource = coll;
        }

        public void fillgrid()
        {
            da = new SqlDataAdapter("select * from trainer where T_Name = '" + txt_search.Text + "'", con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
        }

        public Trainer_Registration()
        {
            InitializeComponent();
            LoadData();
           
        }

        

        void ClearData()
        {

            txt_tID.Text = "";
            txt_tname.Text = "";
            cmb_tgender.Text = "";
            txt_tphone.Text = "";
            txt_address.Text = "";
        }
        void LoadData()
        {
            string sql = "SELECT * FROM TRAINER";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Trainer_Registration_Load(object sender, EventArgs e)
        {
            auto();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_tname.Text == "" || cmb_tgender.Text == "" || txt_tphone.Text == "")
            {
                MessageBox.Show("Plase Fill The Blanks ", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                txt_tname.Focus();
            }
            else
            {
                string sql = "INSERT INTO TRAINER (T_Name,T_Gender,T_Phone,T_Address) VALUES('" + txt_tname.Text + "','" + cmb_tgender.Text + "','" + txt_tphone.Text + "',+'" + txt_address.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("the New Trainer is seccess fully saved ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadData();
                ClearData();
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete these  Trainer", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {

                string sql = "DELETE FROM TRAINER WHERE Trainer_ID = ('" + txt_tID.Text+ "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(" The Selected trainer was seccessfully Deleted  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadData();
                ClearData();
            }
            else
            {

            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txt_tname.Text == "" || cmb_tgender.Text == "" || txt_tphone.Text == "")
            {
                MessageBox.Show("Plase Fill The Blanks ", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                txt_tname.Focus();
            }
            else
            {
                string sql = "UPDATE  TRAINER SET T_Name = '" + txt_tname.Text + "',T_Gender = '" + cmb_tgender.Text + "',T_Phone = '" + txt_tphone.Text + "', T_Address ='" + txt_address.Text + "' WHERE Trainer_ID = '" + txt_tID.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("the New Trainer is seccess fully Updated ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadData();
                ClearData();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txt_tID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txt_tname.Text= dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            cmb_tgender.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txt_tphone.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txt_address.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            fillgrid();
             


        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql = "select * from TRAINER where T_Name like ''" + txt_search.Text + "'%'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
