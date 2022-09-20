using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using OrderControlMgmt.Reports;
using OrderControlMgmt.Forms.PrintingForms;


namespace OrderControlMgmt.Forms.PrintingForms
{
    public partial class frmPrintFiles : Form
    {
        Variables varr = new Variables();
        public frmPrintFiles()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; 
            load();
            
        }

        #region "METHOD"
        public void load()
        {
            try
            {
                string user = "sa", pass = "sinag_13";
                SqlConnection conn = new SqlConnection(varr.ConnString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from " + frmPrintPeza.selection + " where ControlNo = '" + frmPrintPeza.CNo + "'", conn);
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds, frmPrintPeza.selection);

                if (frmPrintPeza.selection == "GGG_PEZA8105")
                {

                    PEZA_8105 list = new PEZA_8105();
                    list.SetDataSource(ds);
                    list.SetDatabaseLogon(user, pass);
                    crystalReportViewer1.ReportSource = list;
                    crystalReportViewer1.Refresh();
                }
                else if (frmPrintPeza.selection == "GGG_PEZA8106")
                {
                    PEZA_8106 list = new PEZA_8106();
                    list.SetDataSource(ds);
                    list.SetDatabaseLogon(user, pass);
                    crystalReportViewer1.ReportSource = list;
                    crystalReportViewer1.Refresh();
                }
                else if (frmPrintPeza.selection == "GGG_PEZA8112")
                {
                    PEZA_8112 list = new PEZA_8112();
                    list.SetDataSource(ds);
                    list.SetDatabaseLogon(user, pass);
                    crystalReportViewer1.ReportSource = list;
                    crystalReportViewer1.Refresh();
                }
                else if (frmPrintPeza.selection == "GGG_BoatNote")
                {
                    BoatNote list = new BoatNote();
                    list.SetDataSource(ds);
                    list.SetDatabaseLogon(user, pass);
                    crystalReportViewer1.ReportSource = list;
                    crystalReportViewer1.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.toString());
            }
        }
        #endregion
        }
}
