using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderControlMgmt.Forms.PrintingForms;
using System.Data.SqlClient;
using OrderControlMgmt.Reports;


namespace OrderControlMgmt.Forms.PrintingForms
{
    public partial class frmPrintShow : Form
    {
        Variables varr = new Variables();
        string user = "sa", pass = "sinag_13";
        public static string name;
        public frmPrintShow()
        {
            InitializeComponent();
            load();
            this.WindowState = FormWindowState.Maximized;
            this.Text = name;
        }

        #region "METHOD"

        public void load()
        {
            try
            {
                SqlConnection conn = new SqlConnection(varr.ConnString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from "+frmPrintPeza.selection+" where ControlNo = '"+frmPrintPeza.CNo+"'",conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
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
                    
                    if (frmPrintPeza.long12 == "long")
                    {
                        PEZA_8112_Long list = new PEZA_8112_Long();
                        list.SetDataSource(ds);
                        list.SetDatabaseLogon(user, pass);
                        crystalReportViewer1.ReportSource = list;
                        crystalReportViewer1.Refresh();
                    }
                    else
                    {
                        PEZA_8112 list = new PEZA_8112();
                        list.SetDataSource(ds);
                        list.SetDatabaseLogon(user, pass);
                        crystalReportViewer1.ReportSource = list;
                        crystalReportViewer1.Refresh();
                    }
                }
                else if (frmPrintPeza.selection == "GGG_BoatNote")
                {
                    BoatNote list = new BoatNote();
                    list.SetDataSource(ds);
                    list.SetDatabaseLogon(user, pass);
                    crystalReportViewer1.ReportSource = list;
                    crystalReportViewer1.Refresh();
                }

                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion
    }
}
