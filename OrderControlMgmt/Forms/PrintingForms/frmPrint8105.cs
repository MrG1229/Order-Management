using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using OrderControlMgmt.Class;

namespace OrderControlMgmt.Forms
{
    public partial class frmPrint8105 : Form
    {     
        List<PEZA8105Details> _list;
        PEZA8105Details _pd;


        public frmPrint8105(PEZA8105Details pd, List<PEZA8105Details> list)
        {
            InitializeComponent();

            //
            _pd = pd;
            _list = list;
        }

        private void frmPrintPaySlip_Load(object sender, EventArgs e)
        {
            pezA_8105.SetDataSource(_list);
            //crystal_Report113thMonthPay1.SetParameterValue("pEmployeeName", _pd.EmployeeName);
            pezA_8105.SetParameterValue("pSINo", _pd.SINo);
            //crystal_Report113thMonthPayDetails1.SetParameterValue("pYear_2", _pd.Year_2);
            //crystal_Report113thMonthPayDetails1.SetParameterValue("pMonth_1", _pd.Month_1);
            //crystal_Report113thMonthPayDetails1.SetParameterValue("pMonth_2", _pd.Month_2);


            crystalReportViewer.ReportSource = pezA_8105;
            crystalReportViewer.Refresh();
        }
    }
}
