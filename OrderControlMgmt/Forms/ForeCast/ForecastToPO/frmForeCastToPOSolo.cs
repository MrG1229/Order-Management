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
using CustomMessageBox;

namespace OrderControlMgmt.Forms.ForeCast.ForecastToPO
{
    public partial class frmForeCastToPOSolo : Form
    {
        public frmForeCastToPOSolo()
        {
            InitializeComponent();
        }

        Variables v = new Variables();

        string ID = "";

        private void frmForeCastToPOSolo_Load(object sender, EventArgs e)
        {
            //nudQty.Maximum = Convert.ToInt32(lblMax.Text);
        }

        private void btnCreatePO_Click(object sender, EventArgs e)
        {
            string remarks = "";

            if (nudQty.Value>0)
            {
                if (nudQty.Value==nudQty.Maximum)
                {
                    remarks = "COMPLETE";
                }
                else
                {
                    remarks = "PARTIAL";
                }

                DialogResult result = Warning_Confirmation.Show("Are you sure you want to cancel this P.O?", "Cancel Confirmation");
                if (result == DialogResult.Yes)
                {
                    //INSERT TO SUB FORECAST LIST
                    v.query = "INSERT INTO [pcs_db].[dbo].[MOM_ForeCastSubPO](FCNo, Date, Qty, Remarks, CreatedBy_ID) VALUES('" + lblFCNo.Text + "', '" + DateTime.Now.Date + "', '"+ Convert.ToInt32(nudQty.Value) +"', '"+ remarks +"','"+ ID +"')";
                    try
                    {
                        v.conn = new SqlConnection(v.connString);
                        v.conn.Open();
                        v.sqlCommand = new SqlCommand(v.query, v.conn);
                        v.reader = v.sqlCommand.ExecuteReader();
                        while (v.reader.Read())
                        {

                        }
                        Save_Confirmation.Show("Forecast # " + lblFCNo.Text + " is cancelled!", "Forecast Cancellation");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    //INSERT TO ADQ_ORDERS FOR PO
                    v.query = "INSERT INTO [pcs_db].[dbo].[ADQ_Orders](PaperPONo, PODetailNo, InHouseNo, PartNo, PartName, Rev, CustNickName, OrderDate, ReqDate, POQty, UOM, ItemUnitPrice, POTotalAmount, Currency, Remarks, PDSNo, LotNo, POStatus, CreatedBy_ID, CreatedDate, POBalance) VALUES('" + lblFCNo.Text + "', '" + DateTime.Now.Date + "', '" + Convert.ToInt32(nudQty.Value) + "', '" + remarks + "','" + ID + "')";
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
            }
        }
    }
}
