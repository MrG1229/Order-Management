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
using OrderControlMgmt.Class;

namespace OrderControlMgmt.Forms.ForeCast.ForeCastList
{
    public partial class ImportForecast_FDTP : Form
    {
        Variables v = new Variables();
        SqlConnection con;
        string autoID;
        DataTable dtnoInh = new DataTable();
        frmFCNoInh Ninh = new frmFCNoInh();

        public ImportForecast_FDTP()
        {
            InitializeComponent();
            con = new SqlConnection(v.ConnStringpcs);


            dtnoInh.Columns.Add("Item Code", typeof(string));
            dtnoInh.Columns.Add("Item Name", typeof(string));
        }

        private void ImportForecast_FDTP_Load(object sender, EventArgs e)
        {
            //RemoveRows();
        }

        #region Method
        public void RemoveRows()
        {
            for (int u = 0; u < 5; u++)
            {
                for (int i = 0; i < dgOrderList.Rows.Count; i++)
                {
                    if (dgOrderList.Rows[i].Cells["F21"].Value.ToString() != "Unarrange")
                    {
                        dgOrderList.Rows.RemoveAt(i);
                    }
                }
            }
        }

        public void RemoveAnusedCol()
        {
            dgOrderList.Columns[14].HeaderText = "Customer PartNo";
            dgOrderList.Columns[17].HeaderText = "Part Name";
            dgOrderList.Columns["DemandFluctuationAlarm"].Visible = false;
            string col1 = dgOrderList.Columns[37].Name;
            //MessageBox.Show(col1);
            dgOrderList.Columns[col1].Visible = false;

            for (int i = 1; i <= 39; i++)
            {
                string colName = "F" + i;
                if (colName != "F4" && colName != "F15" && colName != "F18" && colName != "F38")
                {
                    dgOrderList.Columns[colName].Visible = false;
                }
            }
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
        #endregion

        private void btnSaveImport_Click(object sender, EventArgs e)
        {
            try
            {
                AutoID();
                string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                string[] monthabre = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
                int date1;
                string date2 = "";

                con.Open();
                for (int i = 0; i < dgOrderList.Rows.Count; i++)// Row count 
                {
                    SqlDataAdapter adpchkInh = new SqlDataAdapter("select [InHouseNo],[Rev],[UOM] FROM [pcs_db].[dbo].[DLR_Parts] where [CustomerPartNo] = '" + dgOrderList.Rows[i].Cells[14].Value.ToString() + "' and [PartStatus] = 'ACTIVE'", con);
                    DataTable dtchkInh = new DataTable();
                    adpchkInh.Fill(dtchkInh);

                    if (dtchkInh.Rows.Count >= 1)
                    {
                        for (int x = 39; x <= 50; x++) // Column count
                        {
                            #region Converting Date
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
                            if (dgOrderList.Rows[i].Cells[x].Value.ToString() != "" && dgOrderList.Rows[i].Cells[x].Value.ToString() != "0")
                            {
                                int total = Convert.ToInt32(dgOrderList.Rows[i].Cells[x].Value.ToString());

                                SqlCommand cmdInsert = new SqlCommand("insert into [pcs_db].[dbo].[ADQ_ForeCast] ([FCNo],[InHouseNo],[CustNickName],[PartNo],[PartName],[Rev],[Qty],[Qty_2],[UOM],[Remarks],[POStatus],[CreatedBy_ID],[CreatedDate],[Date]) VALUES (@fc,@inh,'FDTP',@ParNo,@ParN,@rev,@qty,@qty2,@uom,'','ACTIVE',@id,@Cdate,@date)", con);

                                cmdInsert.Parameters.AddWithValue("@fc", autoID);
                                cmdInsert.Parameters.AddWithValue("@inh", dtchkInh.Rows[0][0].ToString());
                                cmdInsert.Parameters.AddWithValue("@ParNo", dgOrderList.Rows[i].Cells[14].Value.ToString());
                                cmdInsert.Parameters.AddWithValue("@ParN", dgOrderList.Rows[i].Cells[17].Value.ToString());
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
                        dtnoInh.Rows.Add(dgOrderList.Rows[i].Cells[14].Value.ToString(), dgOrderList.Rows[i].Cells[17].Value.ToString());

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
