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
using CrystalDecisions.CrystalReports.Engine;
using System.Web.Hosting;
using CrystalDecisions.Windows.Forms;

namespace GYME_Management_System.User_Controls
{
    public partial class Generate_Bill : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = GYMMS; Integrated Security = True");
   

        public Generate_Bill()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            ReportDocument cryRpt = new ReportDocument();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM GenerateBill  WHERE Payment_ID ='"+txt_year.Text+"' ", con) ;

            DataSet dst = new DataSet();

            sda.Fill(dst, "GenerateBill");
            cryRpt.Load(@"C:\Users\pc\Music\GYME\GYME Management System\GYME Management System\reportingBill.rpt ");
            cryRpt.SetDataSource(dst);
            crystalReportViewer1.ReportSource = cryRpt;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
