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


    public partial class Report : UserControl
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

            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteCustomSource = coll;
        }

        void LoadTrainerData()
        {
            string sql = "SELECT * FROM TRAINER";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
        }
        void LoadCustomerData()
        {
            string sql = "SELECT * FROM CUSTOMER ";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void fillgrid()
        {
            da = new SqlDataAdapter("select * from trainer where T_Name = '" + textBox1.Text + "'", con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                dataGridView2.DataSource = dt;
            }
        }

        //Main logic for autocomplete
        public void auto2()
        {
            da = new SqlDataAdapter("  SELECT C_Name FROM CUSTOMER order by C_Name asc", con);
            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    coll.Add(dt.Rows[i]["C_Name"].ToString());
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

        public void fillgrid2()
        {
            da = new SqlDataAdapter("select * from customer where C_Name = '" + txt_search.Text + "'", con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
        }
        public Report()
        {
            InitializeComponent();
            auto();
            auto2();
            LoadCustomerData();
                LoadTrainerData();

        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fillgrid();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
               

            auto();
            auto2();


        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
           
             

            
        }

        private void Report_Load(object sender, EventArgs e)
        {
            auto();
            auto2();
            
        }

        private void txt_search_TextChanged_1(object sender, EventArgs e)
        {
            fillgrid2();
        }
    }
}
