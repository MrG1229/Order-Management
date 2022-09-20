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
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;

namespace OrderControlMgmt.Class
{
    public class POStat
    {
        SqlConnection connection = new SqlConnection("Server = 192.168.1.97,1433; User ID = sa; Password = sinag_13; Database = pcs_db");
        public DataTable POCount( int year, int month)
        {
            DataTable OpenPOCount = new DataTable();
            DataRow dataRow;
            OpenPOCount.Columns.Add("CountEveryMonth");
            OpenPOCount.Columns.Add("Month");
            SqlCommand command;
            DateTime dateTime = DateTime.Now;


            if (connection.State == ConnectionState.Open)
                connection.Close();
            connection.Open();

            command = new SqlCommand(" SELECT COUNT(*) as POCount FROM [pcs_db].[dbo].[ADQ_Orders] Where MONTH(PODate)=@month AND YEAR(PODate)=@year AND POStatus  = 'ONGOING'", connection);
            command.Parameters.Add("@year", SqlDbType.Int).Value = year;
            command.Parameters.Add("@month", SqlDbType.Int).Value = month;

            foreach (DataRow row in ExecuteSelect(command).Rows)
            {
                dataRow = OpenPOCount.NewRow();
                dataRow["CountEveryMonth"] = DBNull.Value.Equals(row["POCount"]) ? 0 : row.Field<int>("POCount");
                dataRow["Month"] = month;
                OpenPOCount.Rows.Add(dataRow);
            }

            connection.Close();

            return OpenPOCount;
        }

        private DataTable ExecuteSelect(SqlCommand command)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
