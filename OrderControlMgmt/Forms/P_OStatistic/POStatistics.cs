using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderControlMgmt.Class;

namespace OrderControlMgmt.Forms.P_OStatistic
{
    public partial class POStatistics : Form
    {
        POStat postat = new POStat();
        public POStatistics()
        {
            InitializeComponent();
            nudDYearly.Maximum = DateTime.Now.Year;
            nudDYearly.Minimum = 2000;
            nudDYearly.Value = DateTime.Now.Year;
        }

        private void nudDYearly_ValueChanged(object sender, EventArgs e)
        {
            int totalMonths = 12; //to get the abreviation of the month
            chart1.Series["OpenPOCount"].Points.Clear();
            for (int month = 1; month <= totalMonths; month++)
            {
                foreach (DataRow row in postat.POCount(Convert.ToInt32(nudDYearly.Value.ToString()), month).Rows)
                {
                    chart1.Series["OpenPOCount"].Points.AddXY(CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(month), Convert.ToInt32(row.Field<string>("CountEveryMonth").ToString()));
                }
            }
        }
    }
}
