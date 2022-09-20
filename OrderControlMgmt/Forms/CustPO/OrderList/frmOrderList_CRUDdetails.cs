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
using OrderControlMgmt.Forms;
using CustomMessageBox;
using System.IO;
using UserAccessControl;

namespace OrderControlMgmt
{
    public partial class frmOrderList_CRUDdetails : Form
    {
        Variables v = new Variables();
        PublicDataTransporter key = new PublicDataTransporter();
        string imgpath = @"\\192.168.1.10\Sinag-Files\DEPT - PRODUCTION CONTROL\P.O Canceled Files\";

        public frmOrderList_CRUDdetails()
        {
            InitializeComponent();            
        }        

        private void GetPODetails()
        {
            v.query = "SELECT * FROM [pcs_db].[dbo].[ADQ_Orders] WHERE PPONo = '" + txtPPONo.Text + "'  ";
            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                while (v.reader.Read())
                { 
                    txtPaperPONo.Text = v.reader.GetString(v.reader.GetOrdinal("PaperPONo"));
                    txtPODetailNo.Text = v.reader.GetString(v.reader.GetOrdinal("PODetailNo"));
                    txtCustName.Text = v.reader.GetString(v.reader.GetOrdinal("CustNickName"));
                    dtpReceivedDate.Value = v.reader.GetDateTime(v.reader.GetOrdinal("PODate"));
                    dtpOrderDate.Value = v.reader.GetDateTime(v.reader.GetOrdinal("OrderDate"));
                    dtpReqDate.Value = v.reader.GetDateTime(v.reader.GetOrdinal("ReqDate"));
                    //txtRemarks.Text = v.reader.GetString(v.reader.GetOrdinal("Remarks")); //do not null this
                    ////
                    txtPartNo.Text = v.reader.GetString(v.reader.GetOrdinal("PartNo"));
                    txtInHouseNo.Text = v.reader.GetString(v.reader.GetOrdinal("InHouseNo"));
                    txtPartName.Text = v.reader.GetString(v.reader.GetOrdinal("PartName"));
                    txtPOQty.Text = v.reader.GetInt32(v.reader.GetOrdinal("POQty")).ToString();
                    txtUOM.Text = v.reader.GetString(v.reader.GetOrdinal("UOM"));
                    txtUnitPrice.Text = v.reader.GetDecimal(v.reader.GetOrdinal("ItemUnitPrice")).ToString("N4");
                    txtAmount.Text = v.reader.GetDecimal(v.reader.GetOrdinal("POTotalAmount")).ToString("N4");
                    txtCurrency.Text = v.reader.GetString(v.reader.GetOrdinal("Currency"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmOrderList_CRUDdetails_Load(object sender, EventArgs e)
        {
            GetPODetails();
        }

        private void btnCancelPO_Click(object sender, EventArgs e)
        {
            string FileName = txtPaperPONo.Text + "_" + DateTime.Now.ToString("yyyyMMdd_HH_mm") + ".jpg";

            if (txtReason.Text.Length < 30)
            { Warning.Show("ADD A CANCELLATION REASON ATLEAST 30 CHARACTERS!!", "WARNING"); }
            else if (lblAttPath.BackColor != Color.Green)
            { Warning.Show("SELECT AN ATTACHMENT FIRST!!", "WARNING"); }
            else
            {
                DialogResult result = Warning_Confirmation.Show("Are you sure you want to cancel this P.O?", "Cancel Confirmation");
                if (result == DialogResult.Yes)
                {
                    
                    v.query = "INSERT INTO [pcs_db].[dbo].[ADQ_CancelledPO](PPONo, isPOCancelled, POCancelReason) VALUES('" + txtPPONo.Text + "', 1, '" + txtReason.Text + "') ";
                    try
                    {
                        v.conn = new SqlConnection(v.connString);
                        v.conn.Open();
                        v.sqlCommand = new SqlCommand(v.query, v.conn);
                        v.reader = v.sqlCommand.ExecuteReader();
                        while (v.reader.Read())
                        {

                        }
                        System.IO.File.Copy(lblAttPath.Text, imgpath + FileName);
                        Save_Confirmation.Show("P.O # " + txtPPONo.Text + " is cancelled!", "P.O Cancellation");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    v.query = "UPDATE [pcs_db].[dbo].[ADQ_Orders] SET FilePath = '"+FileName+"', POStatus = 'CANCELLED' WHERE PPONo = '" + txtPPONo.Text + "' ";
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
                    this.Close();
                }
                else { }
            }
            
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Choose Image(*.JPG;*.PNG;) | *.jpg;*.png;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                lblAttPath.Text = open.FileName;
                lblAttPath.BackColor = Color.Green;
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnUpPoQty_Click(object sender, EventArgs e)
        {
            v.conn.Close();
            v.conn.Open();
            SqlDataAdapter adpchkPds = new SqlDataAdapter("select [PDSNo],[POTotalAmount],[POQty] FROM [pcs_db].[dbo].[ADQ_Orders] where [PODetailNo] = '" + txtPODetailNo.Text + "'", v.conn);
            DataTable dtchkPds = new DataTable();
            adpchkPds.Fill(dtchkPds);

            if (dtchkPds.Rows[0][0].ToString() != "")
            { Warning.Show("YOU CAN'T UPDATE THE QUANTITY OF THIS P.O, BECAUSE THERES ALREADY A CREATED M.O!!", "WARNING"); }
            else if (dtchkPds.Rows[0][1].ToString() == txtAmount.Text && dtchkPds.Rows[0][2].ToString() != txtPOQty.Text)
            { Warning.Show("PLEASE HIT THE ENTER KEY FIRST BEFORE UPDATING!!", "WARNING"); }
            else
            {
                if (dtchkPds.Rows[0][2].ToString() != txtPOQty.Text)
                {
                    SqlCommand cmd = new SqlCommand("update [pcs_db].[dbo].[ADQ_Orders] set [POQty] = @poQty,[POTotalAmount] = @total where [PODetailNo] = '" + txtPODetailNo.Text + "'", v.conn);
                    cmd.Parameters.AddWithValue("@poQty",txtPOQty.Text);
                    cmd.Parameters.AddWithValue("@total",Convert.ToDecimal(txtAmount.Text));
                    cmd.ExecuteNonQuery();
                    Save_Confirmation.Show("SUCCESSFULLY SAVED","SAVED");
                    this.Close();
                }
            }

            v.conn.Close();
        }

        private void txtPOQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            key.TextInput_KeyPress(sender,e);
        }

        private void txtPOQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPOQty.Text == "")
                {
                    //Do nothing
                }
                else if (txtPOQty.Text != "" && txtUnitPrice.Text != "")
                {
                    v.Amount = Convert.ToDecimal(txtPOQty.Text) * Convert.ToDecimal(txtUnitPrice.Text);
                    txtAmount.Text = v.Amount.ToString("N4");
                }
            }
        }
    }
}
