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
using OrderControlMgmt.Properties;
using CustomMessageBox;
using System.IO;

namespace OrderControlMgmt
{
    public partial class frmCancelledOrderList_CRUDdetails : Form
    {
        Variables v = new Variables();
        string imgpath = @"\\192.168.1.10\Sinag-Files\DEPT - PRODUCTION CONTROL\P.O Canceled Files\";
        string path;
        public frmCancelledOrderList_CRUDdetails()
        {
            InitializeComponent();
            
        }        

        private void GetPODetails()
        {
            //pbAttachedFile.Image = null;
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
                    txtRemarks.Text = v.reader.GetString(v.reader.GetOrdinal("Remarks"));
                    //
                    txtPartNo.Text = v.reader.GetString(v.reader.GetOrdinal("PartNo"));
                    txtInHouseNo.Text = v.reader.GetString(v.reader.GetOrdinal("InHouseNo"));
                    txtPartName.Text = v.reader.GetString(v.reader.GetOrdinal("PartName"));
                    txtPOQty.Text = v.reader.GetInt32(v.reader.GetOrdinal("POQty")).ToString();
                    txtUOM.Text = v.reader.GetString(v.reader.GetOrdinal("UOM"));
                    txtUnitPrice.Text = v.reader.GetDecimal(v.reader.GetOrdinal("ItemUnitPrice")).ToString("N4");
                    txtAmount.Text = v.reader.GetDecimal(v.reader.GetOrdinal("POTotalAmount")).ToString("N4");
                    txtCurrency.Text = v.reader.GetString(v.reader.GetOrdinal("Currency"));

                    if (v.reader["FilePath"].GetType() != typeof(DBNull))
                    {
                        path = Path.Combine(imgpath, v.reader.GetString(23));
                        pbAttachedFile.Image = Image.FromFile(path);

                        FileStream fs = File.OpenRead(path);
                        pbAttachedFile.Image = Image.FromStream(fs);

                        fs.Close();
                    }
                    else
                    {
                        pbAttachedFile.Image = Properties.Resources.icons8_no_image_50;
                    }

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
            DialogResult result = Warning_Confirmation.Show("Are you sure you want to restore this P.O?", "Restoration Confirmation");
            if (result == DialogResult.Yes)
            {             
                v.query = "UPDATE [pcs_db].[dbo].[ADQ_Orders] SET POStatus = 'ONGOING',[FilePath] = NULL WHERE PPONo = '" + txtPPONo.Text + "' ";
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
                Save_Confirmation.Show("P.O # " + txtPPONo.Text + " is restored! Please check the P.O List", "Restoration Confirmed");

                v.query = "DELETE FROM [pcs_db].[dbo].[ADQ_CancelledPO] WHERE PPONo = '" + txtPPONo.Text + "' ";
                try
                {
                    v.conn = new SqlConnection(v.connString);
                    v.conn.Open();
                    v.sqlCommand = new SqlCommand(v.query, v.conn);
                    v.reader = v.sqlCommand.ExecuteReader();
                    while (v.reader.Read())
                    {

                    }

                    if (File.Exists(path) == true)
                    {
                        File.Delete(path);
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

        private void frmCancelledOrderList_CRUDdetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                frmCancelledOrderList f = new frmCancelledOrderList();
                //f.dgOrderList.Refresh();
                f.DisplayPOList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
