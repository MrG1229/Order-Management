using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
//
using OrderControlMgmt.Class;

namespace OrderControlMgmt.Forms
{
    public partial class frmPrintSalesInvoice : Form
    {     
        List<SalesInvoiceDetails> _list;
        SalesInvoiceDetails _pd;
        Variables v = new Variables();
        public string SINo = "";

        public frmPrintSalesInvoice(SalesInvoiceDetails pd, List<SalesInvoiceDetails> list)
        {
            InitializeComponent();

            //
            //_pd = pd;
            _list = list;
        }

        private void frmPrintPaySlip_Load(object sender, EventArgs e)
        {

            v.conn = new SqlConnection(v.ConnStringpcs);
            v.conn.Open();
            
            string query = "SELECT dbo.ADQ_SalesInvoice.DateCreated FROM dbo.ADQ_SalesInvoice WHERE SINo = '"+SINo+"'    ";
            SqlDataAdapter adp = new SqlDataAdapter(query,v.conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            string query1 = "SELECT [ReqDate]  FROM [pcs_db].[dbo].[viewSalesInvoiceList] WHERE SINo = '" + SINo + "'    ";
            SqlDataAdapter adp1 = new SqlDataAdapter(query1, v.conn);
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);

            TextObject datcre = (TextObject)salesInvoice1.ReportDefinition.Sections["Section2"].ReportObjects["DateCre"];
            TextObject dudate = (TextObject)salesInvoice1.ReportDefinition.Sections["Section2"].ReportObjects["DueDate"];
            datcre.Text = Convert.ToDateTime(dt.Rows[0][0].ToString()).ToString("MMMM dd yyyy");
            dudate.Text = Convert.ToDateTime(dt1.Rows[0][0].ToString()).ToString("MMMM dd yyyy");
            v.conn.Close();

            //crystal_Report113thMonthPay1.SetParameterValue("pEmployeeName", _pd.EmployeeName);

            //crystal_Report113thMonthPayDetails1.SetParameterValue("pYear_2", _pd.Year_2);
            //crystal_Report113thMonthPayDetails1.SetParameterValue("pMonth_1", _pd.Month_1);
            //crystal_Report113thMonthPayDetails1.SetParameterValue("pMonth_2", _pd.Month_2);
            salesInvoice1.SetDataSource(_list);
            salesInvoice1.SetParameterValue("pSINo", SINo);
            crystalReportViewer.ReportSource = salesInvoice1;
            crystalReportViewer.Refresh();
        }
    }
}
