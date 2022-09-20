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
using OrderControlMgmt.Class;

namespace OrderControlMgmt.Forms.ForeCast.ForeCastList
{
    public partial class ImportForecast_GPI : Form
    {
        Variables v = new Variables();
        SqlConnection con;
        string autoID;
        DataTable dtnoInh = new DataTable();
        frmFCNoInh Ninh = new frmFCNoInh();

        public ImportForecast_GPI()
        {
            InitializeComponent();
            con = new SqlConnection(v.ConnStringpcs);
           
            dtnoInh.Columns.Add("Item Code",typeof(string));
            dtnoInh.Columns.Add("Item Name",typeof(string));
            //noInh.Columns.Add("",typeof(string));
        }

        private void AutoID()
        {
            v.conn = new SqlConnection(v.connString);
            v.conn.Open();
            v.sqlCommand = new SqlCommand("pcs_db.dbo.FCNO_Code", v.conn);
            v.sqlCommand.CommandType = CommandType.StoredProcedure;
            object obj = v.sqlCommand.ExecuteScalar();
            autoID = obj.ToString();

        }

        private void btnSaveImport_Click(object sender, EventArgs e)
        {
            AutoID();

            string res,date2,res1, colname1 = "";
            int date1,date1_1;
            int count = 0 , total = 0, count1 = 0, finisher = 0, ccc = 0, matchCounter = 0;

            con.Open();
            try
            {
                for (int i = 1; i < dgOrderList.Rows.Count; i++)//row count starts in 1 because theres no row 0
                {
                    SqlDataAdapter adpchkInh = new SqlDataAdapter("select [InHouseNo],[Rev],[UOM] FROM [pcs_db].[dbo].[DLR_Parts] where [CustomerPartNo] = '" + dgOrderList.Rows[i].Cells[0].Value.ToString() + "' and [PartStatus] = 'ACTIVE'", con);
                    DataTable dtchkInh = new DataTable();
                    adpchkInh.Fill(dtchkInh);

                    if (dtchkInh.Rows.Count >= 1)
                    {
                        for (int x = 3; x < dgOrderList.ColumnCount; x++)// column count
                        {

                            #region Initialization
                            string colname = dgOrderList.Columns[x].Name;

                            if (x != dgOrderList.ColumnCount - 1)
                            {
                                colname1 = dgOrderList.Columns[x + 1].Name;
                            }

                            foreach (char c in colname)
                            {
                                count++;
                            }

                            foreach (char c in colname1)
                            {
                                count1++;
                            }

                            if (count < 10)
                            {
                                res = colname.Trim();
                                date1 = Convert.ToDateTime(res).Month;

                                date2 = date1.ToString() + "/" + "01/" + DateTime.Now.Year.ToString();
                                count = 0;

                            }
                            else
                            {
                                res = colname.Remove(6);
                                date1 = Convert.ToDateTime(res).Month;

                                date2 = date1.ToString() + "/" + "01/" + DateTime.Now.Year.ToString();
                                count = 0;
                            }

                            if (count1 < 10) // this is for data comparison
                            {
                                res1 = colname1.Trim();
                                date1_1 = Convert.ToDateTime(res1).Month;

                                date2 = date1.ToString() + "/" + "01/" + DateTime.Now.Year.ToString();
                                count1 = 0;

                            }
                            else
                            {
                                res1 = colname1.Remove(6);
                                date1_1 = Convert.ToDateTime(res1).Month;

                                date2 = date1.ToString() + "/" + "01/" + DateTime.Now.Year.ToString();
                                count1 = 0;
                            }

                            if (date1 == date1_1 && x != dgOrderList.ColumnCount - 1) // this is for adding all quantity that has the same date
                            {
                                if (ccc == 0)
                                {
                                    total = Convert.ToInt32(dgOrderList.Rows[i].Cells[x].Value.ToString()) + Convert.ToInt32(dgOrderList.Rows[i].Cells[x + 1].Value.ToString());
                                    ccc = 1;
                                }
                                else
                                {
                                    total = total + Convert.ToInt32(dgOrderList.Rows[i].Cells[x + 1].Value.ToString());
                                }
                                matchCounter = 1;
                            }
                            else
                            {
                                if (matchCounter == 0)
                                {
                                    total = Convert.ToInt32(dgOrderList.Rows[i].Cells[x].Value.ToString());
                                }
                                finisher = 1;
                            }
                            #endregion

                            #region Insert
                            if (finisher == 1 && total != 0)
                            {
                                SqlCommand cmdInsert = new SqlCommand("insert into [pcs_db].[dbo].[ADQ_ForeCast] ([FCNo],[InHouseNo],[CustNickName],[PartNo],[PartName],[Rev],[Qty],[Qty_2],[UOM],[Remarks],[POStatus],[CreatedBy_ID],[CreatedDate],[Date]) VALUES (@fc,@inh,'GPI',@ParNo,@ParN,@rev,@qty,@qty2,@uom,'','ACTIVE',@id,@Cdate,@date)", con);

                                cmdInsert.Parameters.AddWithValue("@fc", autoID);
                                cmdInsert.Parameters.AddWithValue("@inh", dtchkInh.Rows[0][0].ToString());
                                cmdInsert.Parameters.AddWithValue("@ParNo", dgOrderList.Rows[i].Cells[0].Value.ToString());
                                cmdInsert.Parameters.AddWithValue("@ParN", dgOrderList.Rows[i].Cells[1].Value.ToString());
                                cmdInsert.Parameters.AddWithValue("@rev", dtchkInh.Rows[0][1].ToString());
                                cmdInsert.Parameters.AddWithValue("@qty", total);
                                cmdInsert.Parameters.AddWithValue("@qty2", total);
                                cmdInsert.Parameters.AddWithValue("@uom", dtchkInh.Rows[0][2].ToString());
                                cmdInsert.Parameters.AddWithValue("@id", lblID.Text);
                                cmdInsert.Parameters.AddWithValue("@Cdate", DateTime.Now);
                                cmdInsert.Parameters.AddWithValue("@date", date2);

                                cmdInsert.ExecuteNonQuery();
                                AutoID();
                                total = 0;
                                finisher = 0;
                                ccc = 0;
                                
                            }
                            if (finisher == 1 && total == 0)
                            {
                                finisher = 0;
                                matchCounter = 0;
                            }
                            #endregion
                        }

                    }
                    else
                    {
                        dtnoInh.Rows.Add(dgOrderList.Rows[i].Cells[0].Value.ToString(), dgOrderList.Rows[i].Cells[1].Value.ToString());
                    }

                    if (i == dgOrderList.Rows.Count - 2 && dtnoInh.Rows.Count >= 1)
                    {
                        Ninh.dgvNoInhList.DataSource = dtnoInh;
                        MessageBox.Show("SAVED SUCCESSFULLY!");
                        Ninh.Show();
                    }
                    else if (i == dgOrderList.Rows.Count - 1)
                    {
                        MessageBox.Show("SAVED SUCCESSFULLY!");
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
            con.Close();
            //get inh, GPI, rev
            //get inh, cust nickname (DLR_Customer_2), rev
        }
    }
}
