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
    public partial class Customers : UserControl
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

        public Customers()
        {
            InitializeComponent();
        }

        void ClearData()
        {

            txt_CustomerID.Clear();
            txt_CustomerName.Text = "";
            cmb_CustGender.Text = "";
            txt_age.Text = "";
            txt_Hight.Text = "";
            txt_Weight.Text = "";
            cmb_Customer.Text = "";
            date_Registration.Text = "";
            txt_Phone.Text = "";
            txt_Address.Clear();
            cmb_TrainerID.Text = "";
           
        }
        void LoadData()
        {
            string sql = "SELECT * FROM CUSTOMER ";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_CustomerName.Text == "" || cmb_CustGender.Text == "" || date_Registration.Text == "")
            {
                MessageBox.Show("Plase Fill The Blanks ", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                
            }
            else
            {
                string sql = "INSERT INTO CUSTOMER (C_Name,C_Gender,C_Age,C_Height,C_Weight,C_Shift,C_DOR,C_Phone,C_Address,Trainer) VALUES('" + txt_CustomerName.Text + "','" + cmb_CustGender.Text + "','" + txt_age.Text + "','" + txt_Hight.Text + "','" + txt_Weight.Text + "' ,'" + txt_age.Text + "','" + date_Registration.Text + "','" + txt_Phone.Text + "','" + txt_Address.Text + "','" + cmb_TrainerID.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("the New CUSTOMER is seccess fully saved ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                LoadData();
                ClearData();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Are you sure to delete these these Pyment", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {

                    string sql = "DELETE FROM CUSTOMER WHERE Customer_ID= ('" + txt_CustomerID.Text + "')";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show(" The Selected Customer was seccessfully Deleted  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    LoadData();
                    ClearData();
                }
                else
                {

                }
            }
            catch
            {
                MessageBox.Show("You  cannot delete this field until you delete it's related field.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
          
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            fillgrid();
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            auto();
            LoadData();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE CUSTOMER SET C_Name ='" + txt_CustomerName.Text + "',C_Gender ='" + cmb_CustGender.Text + "',C_Age ='" + txt_age.Text + "',C_Height ='" + txt_Hight.Text + "',C_Weight ='" + txt_Weight.Text + "',C_Shift ='" + cmb_Customer.Text + "',C_DOR ='" + date_Registration.Text + "',C_Phone ='" + txt_Phone.Text + "',C_Address ='" + txt_Address.Text + "',Trainer='" + cmb_TrainerID.Text + "' WHERE Customer_ID='" + txt_CustomerID.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("the New CUSTOMER is seccess fully saved ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            LoadData();
            ClearData();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txt_CustomerID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txt_CustomerName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            cmb_CustGender.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txt_age.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txt_Hight.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

            txt_Weight.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            cmb_Customer.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            date_Registration.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            txt_Phone.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
             txt_Address.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            cmb_TrainerID.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
        }

        private void txt_CustomerName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
