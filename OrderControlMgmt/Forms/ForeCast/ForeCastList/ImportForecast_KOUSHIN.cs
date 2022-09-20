using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderControlMgmt.Forms.ForeCast.ForeCastList
{
    public partial class ImportForecast_KOUSHIN : Form
    {
        Variables v = new Variables();
        SqlConnection con;
        string autoID;
        DataTable dtnoInh = new DataTable();
        frmFCNoInh Ninh = new frmFCNoInh();

        public ImportForecast_KOUSHIN()
        {
            InitializeComponent();
            con = new SqlConnection(v.ConnStringpcs);
           

            dtnoInh.Columns.Add("Item Code", typeof(string));
            dtnoInh.Columns.Add("Item Name", typeof(string));
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
            try
            {
                AutoID();
                string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                string[] monthabre = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
                int date1, matchCount = 0, xval = 0, colcount = 0;
                string date2 = "", colnamechk;

                con.Open();
                for (int i = 0; i < dgOrderList.Rows.Count; i++)// Row count 
                {
                    SqlDataAdapter adpchkInh = new SqlDataAdapter("select [InHouseNo],[Rev],[UOM] FROM [pcs_db].[dbo].[DLR_Parts] where [CustomerPartNo] = '" + dgOrderList.Rows[i].Cells[0].Value.ToString() + "' and [PartStatus] = 'ACTIVE'", con);
                    DataTable dtchkInh = new DataTable();
                    adpchkInh.Fill(dtchkInh);

                    if (dtchkInh.Rows.Count >= 1)
                    {
                        #region For Fitting 2 types of Format
                        for (int y = 0; y < monthabre.Count(); y++) // Array count
                        {
                            //MessageBox.Show(colname+"  <><><<<><><><>< "+monthabre[y].ToString());
                            colnamechk = dgOrderList.Columns[5].Name;

                            if (colnamechk.Contains(monthabre[y].ToString()))
                            {
                                colnamechk = months[y].ToString();
                                date1 = DateTime.ParseExact(colnamechk, "MMMM", CultureInfo.CurrentCulture).Month;
                                date2 = date1.ToString() + "/" + "01/" + DateTime.Now.Year.ToString();
                                matchCount = 1;
                            }
                        }

                        if (matchCount != 1)
                        {
                            xval = 7;
                            colcount = dgOrderList.ColumnCount;
                        }
                        else
                        {
                            xval = 5;
                            colcount = dgOrderList.ColumnCount - 2;
                        }
                        #endregion

                        for (int x = xval; x < colcount; x++) // Column count
                        {
                            #region Coverting Date
                            string colname = dgOrderList.Columns[x].Name;

                            for (int y = 0; y < monthabre.Count(); y++) // Array count
                            {
                                if (colname.Contains(monthabre[y].ToString()))
                                {
                                    colname = months[y].ToString();
                                    date1 = DateTime.ParseExact(colname, "MMMM", CultureInfo.CurrentCulture).Month;
                                    date2 = date1.ToString() + "/" + "01/" + DateTime.Now.Year.ToString();
                                    //matchCount = 1;
                                }
                            }
                            #endregion

                            #region Insert
                            if (dgOrderList.Rows[i].Cells[x].Value.ToString() != "" && dgOrderList.Rows[i].Cells[x].Value.ToString() != "0" && date2 != "")
                            {
                                int total = Convert.ToInt32(dgOrderList.Rows[i].Cells[x].Value.ToString());
                                SqlCommand cmdInsert = new SqlCommand("insert into [pcs_db].[dbo].[ADQ_ForeCast] ([FCNo],[InHouseNo],[CustNickName],[PartNo],[PartName],[Rev],[Qty],[Qty_2],[UOM],[Remarks],[POStatus],[CreatedBy_ID],[CreatedDate],[Date]) VALUES (@fc,@inh,'KMP',@ParNo,@ParN,@rev,@qty,@qty2,@uom,'','ACTIVE',@id,@Cdate,@date)", con);

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

                                total = 0;
                                AutoID();

                            }
                            #endregion
                        }
                    }
                    else
                    {
                        dtnoInh.Rows.Add(dgOrderList.Rows[i].Cells[0].Value.ToString(), dgOrderList.Rows[i].Cells[1].Value.ToString());

                    }
                    if (i == dgOrderList.Rows.Count - 1 && dtnoInh.Rows.Count >= 1)
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
                con.Close();
            }
            catch { }
        }
    }
}
