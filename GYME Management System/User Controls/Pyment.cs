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
    public partial class Pyment : UserControl
    {
        AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
        SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = GYMMS; Integrated Security = True");
        SqlDataAdapter da;

        //Main logic for autocomplete
        public void auto()
        {
            da = new SqlDataAdapter("select Payment_ID from payment order by Payment_ID asc", con);
            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    coll.Add(dt.Rows[i]["Payment_ID"].ToString());
                }
            }

            else
            {
                MessageBox.Show("Customer not found!!! ", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

            txt_search.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_search.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_search.AutoCompleteCustomSource = coll;
        }

        public void fillgrid()
        {
            da = new SqlDataAdapter("select * from payment where Payment_ID = '" + txt_search.Text + "'", con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
        }
        public Pyment()
        {
            InitializeComponent();
        }

        void ClearData()
        {

            txt_pymentID.Clear();
            txt_year.Text = "";
            cmb_mounth.Text="";
            pymentDate.Text = "";
            txt_pymentMode.Text = "";
            txt_amount.Clear();
            cmb_pymentState.Text = "";
            txt_cusID.Text = "";
        }
        void LoadData()
        {
            string sql = "select * from Payment";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_year.Text == "" || cmb_mounth.Text == "" || txt_amount.Text == "")
            {
                MessageBox.Show("Plase Fill The Blanks ", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                txt_year.Focus();
            }
            else
            {
                string sql = "INSERT INTO Payment (Year,Month,P_Date,P_Mode,Amount_Paid,P_Status,Customer) VALUES('" + txt_year.Text + "','" + cmb_mounth.Text + "','" + pymentDate.Text + "','" + txt_pymentMode.Text + "','" + txt_amount.Text + "','" + cmb_pymentState.Text + "','" + txt_cusID.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("the New User is seccess fully saved ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadData();
                ClearData();
            }

        }

        private void txt_amount_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete these these Pyment", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {

                string sql = "DELETE FROM Payment WHERE Payment_ID = ('" + txt_pymentID.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(" The Selected PYMENT was seccessfully Deleted  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadData();
                ClearData();
            }
            else
            {

            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txt_year.Text == "" || cmb_mounth.Text == "" || txt_amount.Text == "")
            {
                MessageBox.Show("Plase Fill The Blanks ", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                
            }
            else
            {

                string sql = "UPDATE Payment SET Year ='" + txt_year.Text + "',Month ='" + cmb_mounth.Text + "',P_Date ='" + pymentDate.Text + "',P_Mode='" + txt_pymentMode.Text + "',Amount_Paid= '" + txt_amount.Text + "',P_Status='" + cmb_pymentState.Text + "',Customer ='" + txt_cusID.Text + "' WHERE Payment_ID = '" + txt_pymentID.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("the  PYMENT Data is seccess fully UPDATED  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadData();
                ClearData();
            }
        }

        private void Pyment_Load(object sender, EventArgs e)
        {
            LoadData();
            auto();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txt_pymentID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txt_year.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            cmb_mounth.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            pymentDate.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txt_pymentMode.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txt_amount.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            cmb_pymentState.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            txt_cusID.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            fillgrid();
        }
    }
}
