using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace OrderControlMgmt
{
    public class ForecastLoop
    {
        Variables v = new Variables();

        public int FindAForecast_GetQty2(string InHouseNo)
        {
            v.query = "SELECT TOP 1 * FROM [pcs_db].[dbo].[ADQ_ForeCast] WHERE InHouseNo = '" + InHouseNo + "' AND Qty_2 != 0  ";
            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                while (v.reader.Read())
                {
                    //v.Qty = Convert.ToInt32(txtPOQty.Text); v.DateCreated = v.reader.GetDateTime(v.reader.GetOrdinal("DateCreated"));
                    v.Qty_2 = v.reader.GetInt32(v.reader.GetOrdinal("Qty_2"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return v.Qty_2;
        }

        public DateTime FindAForecast_GetDateCreated(string InHouseNo)
        {
            v.query = "SELECT TOP 1 * FROM [pcs_db].[dbo].[ADQ_ForeCast] WHERE InHouseNo = '" + InHouseNo + "' AND Qty_2 != 0  ";
            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                while (v.reader.Read())
                {                   
                    v.DateCreated = v.reader.GetDateTime(v.reader.GetOrdinal("DateCreated"));                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return v.DateCreated;
        }

        public string FindAForecast_GetFCNo(string InHouseNo)
        {
            v.query = "SELECT TOP 1 * FROM [pcs_db].[dbo].[ADQ_ForeCast] WHERE InHouseNo = '" + InHouseNo + "' AND Qty_2 != 0  ";
            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                while (v.reader.Read())
                {
                    v.FCNo = v.reader.GetString(v.reader.GetOrdinal("FCNo"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return v.FCNo;
        }


        //UPDATES THE QTY_2(1st loop)
        public void UpdateQty(string InHouseNo, int Quantity, DateTime DateCreated)
        {
            v.query = "UPDATE [pcs_db].[dbo].[ADQ_ForeCast] SET Qty_2 = '" + Quantity + "' WHERE InHouseNo = '" + InHouseNo + "' " +
                "AND DateCreated = '" + DateCreated + "'    ";
            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                while (v.reader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //SAVES EVERY QTY AND DEDUCTION
        public void RecordForecast(string PONo, string ForecastNo, int FCQty)
        {
            v.query = "INSERT INTO [pcs_db].[dbo].[ADQ_ForecastRecords] (PPONo,FCNo,FCQtyDeducted,Date) " +
                "VALUES('" + PONo + "', '" + ForecastNo + "', '" + FCQty + "', '" + DateTime.Now + "')";
            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                while (v.reader.Read())
                {

                }
                //Save_Confirmation.Show("P.O is saved!", "Successfully Added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
