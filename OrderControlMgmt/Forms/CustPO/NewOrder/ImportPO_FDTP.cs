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
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using OrderControlMgmt.Class;
using System.Data.OleDb;
using System.IO;
using ExcelDataReader;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using DataTable = System.Data.DataTable;
using CustomMessageBox;
using OrderControlMgmt.Forms.CustPO.NewOrder;

namespace OrderControlMgmt.Forms
{
    public partial class ImportPO_FDTP : Form
    {
        
        Variables v = new Variables();
        ForecastLoop fl = new ForecastLoop();
        frmNotMatchedInh NoMInh ;
        DataTable dt = new DataTable();
        frmNotMatchedInh frm = new frmNotMatchedInh();
        int counter = 0;
        string indi;

        public ImportPO_FDTP()
        {
            InitializeComponent();
            AutoID();

            dt.Columns.Add("OrderDate", typeof(string));
            dt.Columns.Add("PO No", typeof(string));
            dt.Columns.Add("PO Detail No", typeof(string));
            dt.Columns.Add("PartNo", typeof(string));
            dt.Columns.Add("Rev", typeof(string));
            dt.Columns.Add("PartName", typeof(string));
            dt.Columns.Add("ReqDate", typeof(string));
            dt.Columns.Add("POQty", typeof(string));
            dt.Columns.Add("Backlog Qty", typeof(string));
            dt.Columns.Add("InspectingQty", typeof(string));
            dt.Columns.Add("Acceptable Qty", typeof(string));
            dt.Columns.Add("UOM", typeof(string));
            dt.Columns.Add("Currency", typeof(string));
            dt.Columns.Add("ItemUnitPrice", typeof(string));
            dt.Columns.Add("POTotalAmount", typeof(string));
            dt.Columns.Add("POBalance", typeof(string));
        }

        private void AutoID()
        {
            v.conn = new SqlConnection(v.connString);
            v.conn.Open();
            v.sqlCommand = new SqlCommand("pcs_db.dbo.PPONo_Code", v.conn);
            v.sqlCommand.CommandType = CommandType.StoredProcedure;
            object obj = v.sqlCommand.ExecuteScalar();
            v.PPONo = obj.ToString();

        }
    
        private void btnSaveImport_Click(object sender, EventArgs e)
        {
            try
            {
                dt.Rows.Clear();
                for (int i = 0; i < dgOrderList.Rows.Count; i++)
                {
                    string query = "SELECT [InHouseNo] FROM [pcs_db].[dbo].[DLR_Parts] WHERE CustomerPartNo = '" + dgOrderList.Rows[i].Cells[3].Value.ToString() + "' AND [PartStatus] = 'ACTIVE' ";
                    SqlDataAdapter adpGetInh = new SqlDataAdapter(query,v.conn);
                    DataTable dtGetInh = new DataTable();
                    adpGetInh.Fill(dtGetInh);

                    string query1 = "SELECT [PODetailNo] FROM [pcs_db].[dbo].[ADQ_Orders] WHERE [PODetailNo] = '" + dgOrderList.Rows[i].Cells[2].Value.ToString() + "'  ";
                    SqlDataAdapter adpDupliChk = new SqlDataAdapter(query1, v.conn);
                    DataTable dtDupliChk = new DataTable();
                    adpDupliChk.Fill(dtDupliChk);

                    if (dtGetInh.Rows.Count == 1 && dtDupliChk.Rows.Count == 0)
                    {
                        v.query = "INSERT INTO [pcs_db].[dbo].[ADQ_Orders] (PPONo, PaperPONo, PODetailNo, InHouseNo, PartNo, PartName, Rev, CustNickName, PODate, OrderDate, ReqDate, POQty, UOM, ItemUnitPrice, POTotalAmount, Currency, CreatedBy_ID, CreatedDate, POStatus, POBalance)  VALUES (@PPono,@PaperPo,@PoDet,@Inh,@PartNo,@PartN,@Rev,@CustN,@PoD,@OrD,@ReqD,@PoQty,@Uom,@Iup,@POtotal,@Curr,@CreB,@CreD,@POStat,@POBal)";

                        v.sqlCommand = new SqlCommand(v.query,v.conn);

                        v.sqlCommand.Parameters.AddWithValue("@PPono",v.PPONo);
                        v.sqlCommand.Parameters.AddWithValue("@PaperPo",dgOrderList.Rows[i].Cells[1].Value.ToString());
                        v.sqlCommand.Parameters.AddWithValue("@PoDet", dgOrderList.Rows[i].Cells[2].Value.ToString());
                        v.sqlCommand.Parameters.AddWithValue("@Inh", dtGetInh.Rows[0][0].ToString());
                        v.sqlCommand.Parameters.AddWithValue("@PartNo", dgOrderList.Rows[i].Cells[3].Value.ToString());
                        v.sqlCommand.Parameters.AddWithValue("@PartN", dgOrderList.Rows[i].Cells[5].Value.ToString());
                        v.sqlCommand.Parameters.AddWithValue("@Rev", dgOrderList.Rows[i].Cells[4].Value.ToString());
                        v.sqlCommand.Parameters.AddWithValue("@CustN", "FDTP");
                        v.sqlCommand.Parameters.AddWithValue("@PoD", dtpDate.Value);
                        v.sqlCommand.Parameters.AddWithValue("@OrD", dgOrderList.Rows[i].Cells[0].Value.ToString());
                        v.sqlCommand.Parameters.AddWithValue("@ReqD", dgOrderList.Rows[i].Cells[6].Value.ToString());
                        v.sqlCommand.Parameters.AddWithValue("@PoQty", dgOrderList.Rows[i].Cells[7].Value.ToString());
                        v.sqlCommand.Parameters.AddWithValue("@Uom", dgOrderList.Rows[i].Cells[11].Value.ToString());
                        v.sqlCommand.Parameters.AddWithValue("@Iup", dgOrderList.Rows[i].Cells[13].Value.ToString());
                        v.sqlCommand.Parameters.AddWithValue("@POtotal", dgOrderList.Rows[i].Cells[14].Value.ToString());
                        v.sqlCommand.Parameters.AddWithValue("@Curr", dgOrderList.Rows[i].Cells[12].Value.ToString());
                        v.sqlCommand.Parameters.AddWithValue("@CreB",lblID.Text);
                        v.sqlCommand.Parameters.AddWithValue("@CreD",DateTime.Now);
                        v.sqlCommand.Parameters.AddWithValue("@POStat","ONGOING");
                        v.sqlCommand.Parameters.AddWithValue("@POBal", dgOrderList.Rows[i].Cells[7].Value.ToString());

                        v.sqlCommand.ExecuteNonQuery();
                        //counter++;
                        AutoID();
                    }
                    else if (dtGetInh.Rows.Count == 0)
                    {
                        dt.Rows.Add(dgOrderList.Rows[i].Cells[0].Value.ToString(), dgOrderList.Rows[i].Cells[1].Value.ToString(), dgOrderList.Rows[i].Cells[2].Value.ToString(), dgOrderList.Rows[i].Cells[3].Value.ToString(), dgOrderList.Rows[i].Cells[4].Value.ToString(), dgOrderList.Rows[i].Cells[5].Value.ToString(), dgOrderList.Rows[i].Cells[6].Value.ToString(), dgOrderList.Rows[i].Cells[7].Value.ToString(), dgOrderList.Rows[i].Cells[8].Value.ToString(), dgOrderList.Rows[i].Cells[9].Value.ToString(), dgOrderList.Rows[i].Cells[10].Value.ToString(), dgOrderList.Rows[i].Cells[11].Value.ToString(), dgOrderList.Rows[i].Cells[12].Value.ToString(), dgOrderList.Rows[i].Cells[13].Value.ToString(), dgOrderList.Rows[i].Cells[14].Value.ToString(), dgOrderList.Rows[i].Cells[7].Value.ToString());
                    }

                    if (i == dgOrderList.Rows.Count - 1 && dt.Rows.Count >= 1)
                    {
                        //MessageBox.Show(counter.ToString());
                        NoMInh = new frmNotMatchedInh();
                        NoMInh.dgvNoInhList.DataSource = dt;
                        Save_Confirmation.Show("SOME ITEM'S HAVE UN MATCHED INHOUSE P.O HAS BEEN CREATED", "COMFIRMATION");
                        NoMInh.Show();
                    }
                    else if (i == dgOrderList.Rows.Count - 1)
                    {
                        Save_Confirmation.Show("ALL ITEM'S THAT HAS MATCHED INHOUSE P.O HAS BEEN CREATED", "COMFIRMATION");
                    }
                }

                #region Old Codes
                //foreach (DataGridViewRow row in dgOrderList.Rows)
                //{
                //InHouseNo

                #region GET INHOUSE NO

                //v.query = "SELECT * FROM [pcs_db].[dbo].[DLR_Parts] WHERE CustomerPartNo = '" + row.Cells[3].Value + "'  ";
                //try
                //{
                //    v.conn = new SqlConnection(v.connString);
                //    v.conn.Open();
                //    v.sqlCommand = new SqlCommand(v.query, v.conn);
                //    v.reader = v.sqlCommand.ExecuteReader();
                //    if (v.reader.HasRows)
                //    {
                //        while (v.reader.Read())
                //        {
                //            v.InHouseNo = v.reader.GetString(v.reader.GetOrdinal("InHouseNo"));
                //        }
                //        #region INSERT P.O

                //        v.query = "INSERT INTO [pcs_db].[dbo].[ADQ_Orders]" +
                //            "(PPONo, PaperPONo, PODetailNo, InHouseNo, PartNo, PartName, Rev, CustNickName, PODate, OrderDate, ReqDate, POQty, UOM, ItemUnitPrice, POTotalAmount, " +
                //            "Currency, CreatedBy_ID, CreatedDate, POStatus, POBalance) " +
                //            "VALUES (" +
                //            "'" + v.PPONo + "', '" + row.Cells[1].Value + "', '" + row.Cells[2].Value + "', '" + v.InHouseNo + "', '" + row.Cells[3].Value + "', " +
                //            "'" + row.Cells[5].Value + "', " +
                //            "'" + row.Cells[4].Value + "', '" + lblCustName.Text + "', '" + dtpDate.Value + "', " +
                //            "'" + row.Cells[0].Value + "', " +
                //            "'" + row.Cells[6].Value + "', " +
                //            "'" + row.Cells[7].Value + "'," +
                //            "'" + row.Cells[11].Value + "', " +
                //            "'" + row.Cells[13].Value + "', " +
                //            "'" + row.Cells[14].Value + "', " +
                //            "'" + row.Cells[12].Value + "'," +
                //            "'" + lblID.Text + "'," +
                //            "'" + DateTime.Now + "', " +
                //            "'ONGOING', '" + row.Cells[7].Value + "' )";

                //        try
                //        {
                //            v.conn = new SqlConnection(v.connString);
                //            v.conn.Open();
                //            v.sqlCommand = new SqlCommand(v.query, v.conn);
                //            v.reader = v.sqlCommand.ExecuteReader();
                //            while (v.reader.Read())
                //            {

                //            }

                //            for (int i = dgOrderList.Rows.Count; i >= 0; i--)
                //            {
                //                if (i == 0)
                //                {
                //                    indi = "FINISH";
                //                }
                //            }
                //        }
                //        catch (Exception ex)
                //        {
                //            //MessageBox.Show(ex.ToString());                        
                //            Warning.Show("Sorry, but the file you're trying to import already exists. Please choose another file.", "P.O IMPORT FAILED");
                //            break;
                //        }

                //        #endregion
                //    }
                //    else
                //    {
                //        counter++;

                //         while (v.reader.Read())
                //         {
                //             if (!v.reader.HasRows)
                //             {
                //                 v.InHouseNo = v.reader.GetString(v.reader.GetOrdinal("InHouseNo"));
                //             }
                //         }

                //         dt.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value, row.Cells[5].Value, row.Cells[6].Value, row.Cells[7].Value, row.Cells[8].Value, row.Cells[9].Value, row.Cells[10].Value,row.Cells[11].Value,row.Cells[12].Value, row.Cells[13].Value, row.Cells[14].Value, row.Cells[7].Value);

                //            frm.dgvNoInhList.DataSource = dt;

                //        //NoMInh.dgvNoInhList.DataSource =
                //        //NoMInh.ShowDialog();
                //        //DialogResult result = Warning.Show("There are Parts listed that doesn't match any of our records. Please check Parts Management", "P.O IMPORT FAILED");
                //        //if (result == DialogResult.Yes)
                //        //{
                //        //    break;
                //        //}
                //        //else
                //        //{
                //        //    break;
                //        //}
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.ToString());
                //}

                #endregion

                #region INSERT P.O

                //v.query = "INSERT INTO [pcs_db].[dbo].[ADQ_Orders]" +
                //    "(PPONo, PaperPONo, PODetailNo, InHouseNo, PartNo, PartName, Rev, CustNickName, PODate, OrderDate, ReqDate, POQty, UOM, ItemUnitPrice, POTotalAmount, " +
                //    "Currency, CreatedBy_ID, CreatedDate, POStatus, POBalance) " +
                //    "VALUES (" +
                //    "'" + v.PPONo + "', '" + row.Cells[1].Value + "', '" + row.Cells[2].Value + "', '" + v.InHouseNo + "', '" + row.Cells[3].Value + "', " +
                //    "'" + row.Cells[5].Value + "', " +
                //    "'" + row.Cells[4].Value + "', '" + lblCustName.Text + "', '" + dtpDate.Value + "', " +
                //    "'" + row.Cells[0].Value + "', " +
                //    "'" + row.Cells[6].Value + "', " +
                //    "'" + row.Cells[7].Value + "'," +
                //    "'" + row.Cells[11].Value + "', " +
                //    "'" + row.Cells[13].Value + "', " +
                //    "'" + row.Cells[14].Value + "', " +
                //    "'" + row.Cells[12].Value + "'," +
                //    "'" + lblID.Text + "'," +
                //    "'" + DateTime.Now + "', " +
                //    "'ONGOING', '" + row.Cells[7].Value + "' )";

                //try
                //{
                //    v.conn = new SqlConnection(v.connString);
                //    v.conn.Open();
                //    v.sqlCommand = new SqlCommand(v.query, v.conn);
                //    v.reader = v.sqlCommand.ExecuteReader();
                //    while (v.reader.Read())
                //    {

                //    }
                //    Save_Confirmation.Show("P.O is saved!", "Successfully Added");
                //}
                //catch (Exception ex)
                //{
                //    //MessageBox.Show(ex.ToString());                        
                //    Warning.Show("Sorry, but it seems that the file you imported doesn't fit, or it already exists. Please seek I.T Dept.", "INVALID P.O FORMAT");
                //    break;
                //}

                #endregion

                #region FORECAST

                //v.query = "SELECT TOP 1 * FROM [pcs_db].[dbo].[ADQ_ForeCast] WHERE InHouseNo = '" + v.InHouseNo + "' AND Qty_2 != 0  ";
                //try
                //{
                //    v.conn = new SqlConnection(v.connString);
                //    v.conn.Open();
                //    v.sqlCommand = new SqlCommand(v.query, v.conn);
                //    v.reader = v.sqlCommand.ExecuteReader();
                //    if (v.reader.HasRows)
                //    {
                //        while (v.reader.Read())
                //        {
                //            v.Qty_2 = fl.FindAForecast_GetQty2(v.InHouseNo); //Gets the data needed           
                //            v.DateCreated = fl.FindAForecast_GetDateCreated(v.InHouseNo); //Gets the data needed            
                //            v.FCNo = fl.FindAForecast_GetFCNo(v.InHouseNo); //Gets the Forecast Number
                //                                                            //
                //            v.Qty = Convert.ToInt32(row.Cells[7].Value);

                //            MessageBox.Show(v.Qty_2.ToString());
                //            MessageBox.Show(v.Qty.ToString());

                //            //
                //            if (v.Qty == v.Qty_2) //if both factors are equal
                //            {
                //                MessageBox.Show("Equal");
                //                v.Remainder = 0;
                //                fl.UpdateQty(v.InHouseNo, v.Remainder, v.DateCreated); //Updates the data to 0 if Qty == Qty2
                //                fl.RecordForecast(v.PPONo, v.FCNo, v.Qty);
                //            }
                //            else if (v.Qty < v.Qty_2) //if Qty is less than Qty_2
                //            {
                //                MessageBox.Show("PoQty < Qty_2");
                //                v.Remainder = v.Qty_2 - v.Qty;
                //                fl.UpdateQty(v.InHouseNo, v.Remainder, v.DateCreated); //Updates the data if Qty_2
                //                fl.RecordForecast(v.PPONo, v.FCNo, v.Qty);
                //            }
                //            else if (v.Qty > v.Qty_2)
                //            {
                //                v.Qty_2 = fl.FindAForecast_GetQty2(v.InHouseNo); //Gets the data needed           
                //                v.DateCreated = fl.FindAForecast_GetDateCreated(v.InHouseNo); //Gets the data needed
                //                v.FCNo = fl.FindAForecast_GetFCNo(v.InHouseNo); //Gets the Forecast Number

                //                MessageBox.Show("PoQty > Qty_2");
                //                v.Remainder = System.Math.Abs(v.Qty - v.Qty_2);

                //                #region UPDATE
                //                v.query = "UPDATE [pcs_db].[dbo].[ADQ_ForeCast] SET Qty_2 = '0' WHERE InHouseNo = '" + v.InHouseNo + "' " +
                //                          "AND DateCreated = '" + v.DateCreated + "'    ";
                //                try
                //                {
                //                    v.conn = new SqlConnection(v.connString);
                //                    v.conn.Open();
                //                    v.sqlCommand = new SqlCommand(v.query, v.conn);
                //                    v.reader = v.sqlCommand.ExecuteReader();
                //                    while (v.reader.Read())
                //                    {

                //                    }
                //                }
                //                catch (Exception ex)
                //                {
                //                    MessageBox.Show(ex.ToString());
                //                }

                //                #endregion

                //                fl.RecordForecast(v.PPONo, v.FCNo, v.Qty_2);

                //                while (v.Remainder != 0)
                //                {
                //                    MessageBox.Show(v.Remainder.ToString());
                //                    //v.Remainder = fl.WhileRemainder(cmbInHouseNo.Text, v.Qty, v.Remainder, v.DateCreated);
                //                    if (v.Remainder < v.Qty_2) //if remaining POQty is less than Qty2 || 3500 < 1500
                //                    {
                //                        v.Qty_2 = fl.FindAForecast_GetQty2(v.InHouseNo); //Gets the data needed           
                //                        v.DateCreated = fl.FindAForecast_GetDateCreated(v.InHouseNo); //Gets the data needed
                //                        v.FCNo = fl.FindAForecast_GetFCNo(v.InHouseNo); //Gets the Forecast Number

                //                        MessageBox.Show("v.Remainder < Qty_2");

                //                        v.TQty = v.Qty_2 - v.Remainder;

                //                        MessageBox.Show(v.TQty.ToString());

                //                        #region UPDATE
                //                        v.query = "UPDATE [pcs_db].[dbo].[ADQ_ForeCast] SET Qty_2 = '" + v.TQty + "' WHERE InHouseNo = '" + v.InHouseNo + "' " +
                //                                  "AND DateCreated = '" + v.DateCreated + "'    ";
                //                        try
                //                        {
                //                            v.conn = new SqlConnection(v.connString);
                //                            v.conn.Open();
                //                            v.sqlCommand = new SqlCommand(v.query, v.conn);
                //                            v.reader = v.sqlCommand.ExecuteReader();
                //                            while (v.reader.Read())
                //                            {

                //                            }
                //                        }
                //                        catch (Exception ex)
                //                        {
                //                            MessageBox.Show(ex.ToString());
                //                        }

                //                        #endregion

                //                        fl.RecordForecast(v.PPONo, v.FCNo, v.Remainder);

                //                        v.Remainder = 0;
                //                    }
                //                    else if (v.Remainder > v.Qty_2)
                //                    {
                //                        MessageBox.Show("v.Remainder > Qty_2");
                //                        MessageBox.Show(v.Remainder.ToString());

                //                        v.Qty_2 = fl.FindAForecast_GetQty2(v.InHouseNo); //Gets the data needed           
                //                        v.DateCreated = fl.FindAForecast_GetDateCreated(v.InHouseNo); //Gets the data needed
                //                        v.FCNo = fl.FindAForecast_GetFCNo(v.InHouseNo); //Gets the Forecast Number

                //                        v.Remainder = System.Math.Abs(v.Remainder - v.Qty_2);

                //                        #region UPDATE
                //                        v.query = "UPDATE [pcs_db].[dbo].[ADQ_ForeCast] SET Qty_2 = '0' WHERE InHouseNo = '" + v.InHouseNo + "' " +
                //                                  "AND DateCreated = '" + v.DateCreated + "'    ";
                //                        try
                //                        {
                //                            v.conn = new SqlConnection(v.connString);
                //                            v.conn.Open();
                //                            v.sqlCommand = new SqlCommand(v.query, v.conn);
                //                            v.reader = v.sqlCommand.ExecuteReader();
                //                            while (v.reader.Read())
                //                            {

                //                            }
                //                        }
                //                        catch (Exception ex)
                //                        {
                //                            MessageBox.Show(ex.ToString());
                //                        }

                //                        #endregion

                //                        fl.RecordForecast(v.PPONo, v.FCNo, v.Qty_2);
                //                    }
                //                    else
                //                    {
                //                        v.TQty = 0;
                //                    }
                //                }
                //            }
                //            else
                //            {
                //                MessageBox.Show("There's something wrong");
                //            }
                //        }
                //    }
                //    else
                //    {
                //        //MessageBox.Show("No Forecast for InHouse No: " + v.InHouseNo);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.ToString());
                //}                    

                #endregion

                //}

                //if (indi == "FINISH")
                //{
                //    Save_Confirmation.Show("ALL ITEM'S THAT HAS MATCHED INHOUSE P.O HAS BEEN CREATED", "COMFIRMATION");
                //}

                //if (counter > 0)
                //{
                //  frm.Show();
                //}
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                //Warning.Show("Sorry, but it seems that the file you imported doesn't fit, or it may have some changes. Please seek I.T Dept.", "INVALID P.O FORMAT");
            }          
        }

        private void ImportPO_FDTP_Load(object sender, EventArgs e)
        {

        }
    }
}
