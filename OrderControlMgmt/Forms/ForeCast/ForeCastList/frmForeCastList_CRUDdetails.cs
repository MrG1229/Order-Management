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
using OrderControlMgmt.Forms.ForeCast.ForecastToPO;
using CustomMessageBox;


namespace OrderControlMgmt
{
    public partial class frmForeCastList_CRUDdetails : Form
    {
        Variables v = new Variables();
        int UpQty = 0;
        int diff = 0;
        int Qty1 = 0;
        int Qty2 = 0;

        frmForeCastToPOSolo frmFtoPO = new frmForeCastToPOSolo();

        public frmForeCastList_CRUDdetails()
        {
            InitializeComponent();            
        }        

        private void GetPODetails()
        {
            v.query = "SELECT * FROM [pcs_db].[dbo].[ADQ_ForeCast] WHERE FCNo = '" + txtFCNo.Text + "'  ";
            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                while (v.reader.Read())
                {                   
                    dtpDateCreated.Value = v.reader.GetDateTime(v.reader.GetOrdinal("CreatedDate"));
                    //dtpDateRequired.Value = v.reader.GetDateTime(v.reader.GetOrdinal("DateRequired"));
                    txtRemarks.Text = v.reader.GetString(v.reader.GetOrdinal("Remarks"));
                    //
                    txtPartNo.Text = v.reader.GetString(v.reader.GetOrdinal("PartNo"));
                    txtInHouseNo.Text = v.reader.GetString(v.reader.GetOrdinal("InHouseNo"));
                    txtPartName.Text = v.reader.GetString(v.reader.GetOrdinal("PartName"));
                    txtQty.Text = v.reader.GetInt32(v.reader.GetOrdinal("Qty")).ToString();
                    txtRemQty.Text = v.reader.GetInt32(v.reader.GetOrdinal("Qty_2")).ToString();
                    txtUOM.Text = v.reader.GetString(v.reader.GetOrdinal("UOM"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            ////Extraction  of Sub Quantities.....
            //v.query = "SELECT * FROM [pcs_db].[dbo].[MOM_ForeCastSubPO] WHERE FCNo = '" + txtFCNo.Text + "'  ";
            //try
            //{
            //    v.conn = new SqlConnection(v.connString);
            //    v.conn.Open();
            //    v.sqlCommand = new SqlCommand(v.query, v.conn);
            //    v.reader = v.sqlCommand.ExecuteReader();
            //    while (v.reader.Read())
            //    {
            //        //int num = v.reader.GetInt32(v.reader.GetOrdinal("Qty"));
            //        ////txtQty.Text = (Convert.ToInt32(txtQty.Text) - Convert.ToInt32(v.reader.GetString(v.reader.GetOrdinal("Qty")))).ToString(); // may error dito girl
            //        //txtQty.Text = (Convert.ToInt32(txtQty.Text) - num).ToString();
            //        //txtQty.Text = (Convert.ToInt32(txtQty.Text) - Convert.ToInt32(v.reader.GetInt32(v.reader.GetOrdinal("Qty")))).ToString();
            //        MessageBox.Show((Convert.ToInt32(txtQty.Text) - Convert.ToInt32(v.reader.GetInt32(v.reader.GetOrdinal("Qty")))).ToString());
            //    }
            //}
            //catch (Exception fx)
            //{
            //    MessageBox.Show(fx.ToString());
            //}
        }

        private void UpdateQty()
        {
            UpQty = Convert.ToInt32(txtQty.Text);
            // ex: 5000 > 1000. subtraction should apply
            if (v.Qty > UpQty)
            {
                diff = Math.Abs(UpQty - v.Qty);

                Qty1 = v.Qty - diff;
                Qty2 = v.Qty_2 - diff;
                //MessageBox.Show("Recorder Qty is greater than Updated Qty. So we have to subtract " + diff + " | " + Qty1);
            }
            else if (v.Qty < UpQty)
            {
                diff = Math.Abs(UpQty - v.Qty);

                Qty1 = v.Qty + diff;
                Qty2 = v.Qty_2 + diff;
                //MessageBox.Show("Recorded Qty is less than Update Qty. So we have to add " + diff + " | " + Qty1);
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void frmOrderList_CRUDdetails_Load(object sender, EventArgs e)
        {
            GetPODetails();
        }

        private void btnCancelPO_Click(object sender, EventArgs e)
        {
            DialogResult result = Warning_Confirmation.Show("Are you sure you want to cancel this FORECAST?", "Cancel Confirmation");
            if (result == DialogResult.Yes)
            {
                v.query = "INSERT INTO [pcs_db].[dbo].[ADQ_CancelledForecast](FCNo, isForecastCancelled, ForecastCancelReason) VALUES('" + txtFCNo.Text + "', 1, '" + txtReason.Text + "') ";
                try
                {
                    v.conn = new SqlConnection(v.connString);
                    v.conn.Open();
                    v.sqlCommand = new SqlCommand(v.query, v.conn);
                    v.reader = v.sqlCommand.ExecuteReader();
                    while (v.reader.Read())
                    {

                    }
                    Save_Confirmation.Show("Forecast # " + txtFCNo.Text + " is cancelled!", "Forecast Cancellation");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                v.query = "UPDATE [pcs_db].[dbo].[ADQ_ForeCast] SET POStatus = 'CANCELLED' WHERE FCNo = '" + txtFCNo.Text + "' ";
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
            else { }
            
        }

        //UPDATE BUTTON
        private void btnCreatePO_Click(object sender, EventArgs e)
        {
            //frmFtoPO.lblFCNo.Text = txtFCNo.Text;
            //frmFtoPO.nudQty.Maximum = Convert.ToInt32(txtQty.Text);
            //frmFtoPO.nudQty.Value = Convert.ToInt32(txtQty.Text);
            //frmFtoPO.lblMax.Text = Convert.ToInt32(txtQty.Text).ToString();
            //frmFtoPO.ShowDialog();

            

            DialogResult result = Warning_Confirmation.Show("Are you sure you want to update the quantity?", "Forecast Update Confirmation");
            if (result == DialogResult.Yes)
            {
                if (txtQty.Text == "" || txtQty.Text == "0")
                { Warning.Show("The Qty Cannot be 0 or Empty!", "QTY ERROR"); }
                else
                {
                    v.query = "SELECT * FROM [pcs_db].[dbo].[ADQ_ForeCast] WHERE FCNo = '" + txtFCNo.Text + "'  ";
                    try
                    {
                        v.conn = new SqlConnection(v.connString);
                        v.conn.Open();
                        v.sqlCommand = new SqlCommand(v.query, v.conn);
                        v.reader = v.sqlCommand.ExecuteReader();
                        while (v.reader.Read())
                        {
                            v.Qty = v.reader.GetInt32(v.reader.GetOrdinal("Qty"));
                            v.Qty_2 = v.reader.GetInt32(v.reader.GetOrdinal("Qty_2"));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    UpdateQty();

                    //MessageBox.Show(v.Qty.ToString() + "  " + diff.ToString() + "  "  + Qty1.ToString());
                    //MessageBox.Show(v.Qty_2.ToString() + "  " + diff.ToString() + "  "  + Qty2.ToString());


                    v.query = "UPDATE [pcs_db].[dbo].[ADQ_ForeCast] SET Qty = '" + Qty1 + "', Qty_2 = '" + Qty2 + "' WHERE FCNo = '" + txtFCNo.Text + "' ";
                    try
                    {
                        v.conn = new SqlConnection(v.connString);
                        v.conn.Open();
                        v.sqlCommand = new SqlCommand(v.query, v.conn);
                        v.reader = v.sqlCommand.ExecuteReader();
                        while (v.reader.Read())
                        {

                        }
                        Save_Confirmation.Show("Forecast # " + txtFCNo.Text + " Quantity is updated!", "Forecast");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    GetPODetails();
                    this.Close();
                }
            }
            else { }


            //v.query = "UPDATE [pcs_db].[dbo].[ADQ_ForeCast] SET Date = '" + dtpDateCreated.Value + "' WHERE FCNo = '" + txtFCNo.Text + "' ";
            //try
            //{
            //    v.conn = new SqlConnection(v.connString);
            //    v.conn.Open();
            //    v.sqlCommand = new SqlCommand(v.query, v.conn);
            //    v.reader = v.sqlCommand.ExecuteReader();
            //    while (v.reader.Read())
            //    {

            //    }
            //    Save_Confirmation.Show("Forecast # " + txtFCNo.Text + " Quantity is updated!", "Forecast");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}

        }

        

        private void txtQty_OnValueChanged(object sender, EventArgs e)
        {
            if(txtQty.Text != null)
            {
                btnUpdateFCQty.Visible = true;
            }
        }
    }
}
