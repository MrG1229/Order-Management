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
using CustomMessageBox;
using UserAccessControl;

namespace OrderControlMgmt
{
    public partial class frmManualPO : Form
    {
        Variables v = new Variables();
        ForecastLoop fl = new ForecastLoop();
        PublicDataTransporter pdt = new PublicDataTransporter();
        
        public frmManualPO()
        {
            InitializeComponent();

            AutoID();
            GetPartNo();
            GetInHouseNo();
            GetCustomerName();
        }

        #region METHODS

        private void AutoID()
        {
            v.conn = new SqlConnection(v.connString);
            v.conn.Open();
            v.sqlCommand = new SqlCommand("pcs_db.dbo.PPONo_Code", v.conn);
            v.sqlCommand.CommandType = CommandType.StoredProcedure;
            object obj = v.sqlCommand.ExecuteScalar();
            txtPPONo.Text = obj.ToString();

        }

        public void GetPartNo()
        {
            v.query = "SELECT * FROM [pcs_db].[dbo].[DLR_Parts] WHERE PartStatus != 'Deleted' ";
            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                while (v.reader.Read())
                {
                    v.PartNo = v.reader.GetString(v.reader.GetOrdinal("CustomerPartNo"));
                    cmbPartNo.Items.Add(v.PartNo);
                    //orderCtrl.metroComboBox1.Items.Add(v.ProductNo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void GetInHouseNo()
        {
            v.query = "SELECT * FROM [pcs_db].[dbo].[DLR_Parts] WHERE PartStatus != 'Deleted' ";
            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                while (v.reader.Read())
                {
                    v.InHouseNo = v.reader.GetString(v.reader.GetOrdinal("InHouseNo"));
                    cmbInHouseNo.Items.Add(v.InHouseNo);
                    //orderCtrl.metroComboBox1.Items.Add(v.ProductNo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void GetCustomerName()
        {
            //v.query = "SELECT * FROM [pcs_db].[dbo].[DLR_Customers_2]  ";
            //try
            //{
            //    v.conn = new SqlConnection(v.connString);
            //    v.conn.Open();
            //    v.sqlCommand = new SqlCommand(v.query, v.conn);
            //    v.reader = v.sqlCommand.ExecuteReader();
            //    while (v.reader.Read())
            //    {
            //        v.CustNickName = v.reader.GetString(v.reader.GetOrdinal("Abbreviation"));
            //        cmbCustName.Items.Add(v.CustNickName);
            //        //cmbCustName2.Items.Add(v.CustNickName);
            //        //orderCtrl.metroComboBox1.Items.Add(v.ProductNo);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void SearchCustName()
        {
            v.query = "SELECT * FROM [pcs_db].[dbo].[DLR_Customers_2] WHERE CustomerID = '" + v.CustID + "'  ";
            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                if (v.reader.HasRows)
                {
                    while (v.reader.Read())
                    {
                        v.CustNickName = v.reader.GetString(v.reader.GetOrdinal("Abbreviation"));
                        txtCustName.Text = v.CustNickName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SelectByInHouseNo()
        {
            v.query = "SELECT * FROM [pcs_db].[dbo].[DLR_Parts] WHERE InHouseNo = '" + cmbInHouseNo.Text + "'  ";
            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                if (v.reader.HasRows)
                {
                    while (v.reader.Read())
                    {
                        v.PartNo = v.reader.GetString(v.reader.GetOrdinal("CustomerPartNo"));
                        cmbPartNo.Text = v.PartNo.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SelectByPartNo()
        {
            v.query = "SELECT * FROM [pcs_db].[dbo].[DLR_Parts] WHERE CustomerPartNo = '" + cmbPartNo.Text + "'  ";
            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                while (v.reader.Read())
                {

                    v.InHouseNo = v.reader.GetString(v.reader.GetOrdinal("InHouseNo"));
                    cmbInHouseNo.Text = v.InHouseNo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }               
      
        private void Forecast()
        {
            v.query = "SELECT TOP 1 * FROM [pcs_db].[dbo].[ADQ_ForeCast] WHERE InHouseNo = '" + cmbInHouseNo.Text + "' AND Qty_2 != 0  ";
            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                if(v.reader.HasRows)
                {
                    while (v.reader.Read())
                    {
                        v.Qty_2 = fl.FindAForecast_GetQty2(cmbInHouseNo.Text); //Gets the data needed           
                        v.DateCreated = fl.FindAForecast_GetDateCreated(cmbInHouseNo.Text); //Gets the data needed            
                        v.FCNo = fl.FindAForecast_GetFCNo(cmbInHouseNo.Text); //Gets the Forecast Number
                                                                              //
                        v.Qty = Convert.ToInt32(txtPOQty.Text);

                        MessageBox.Show(v.Qty_2.ToString());
                        MessageBox.Show(v.Qty.ToString());

                        //
                        if (v.Qty == v.Qty_2) //if both factors are equal
                        {
                            MessageBox.Show("Equal");
                            v.Remainder = 0;
                            fl.UpdateQty(cmbInHouseNo.Text, v.Remainder, v.DateCreated); //Updates the data to 0 if Qty == Qty2
                            fl.RecordForecast(txtPPONo.Text, v.FCNo, v.Qty);
                        }
                        else if (v.Qty < v.Qty_2) //if Qty is less than Qty_2
                        {
                            MessageBox.Show("PoQty < Qty_2");
                            v.Remainder = v.Qty_2 - v.Qty;
                            fl.UpdateQty(cmbInHouseNo.Text, v.Remainder, v.DateCreated); //Updates the data if Qty_2
                            fl.RecordForecast(txtPPONo.Text, v.FCNo, v.Qty);
                        }
                        else if (v.Qty > v.Qty_2)
                        {
                            v.Qty_2 = fl.FindAForecast_GetQty2(cmbInHouseNo.Text); //Gets the data needed           
                            v.DateCreated = fl.FindAForecast_GetDateCreated(cmbInHouseNo.Text); //Gets the data needed
                            v.FCNo = fl.FindAForecast_GetFCNo(cmbInHouseNo.Text); //Gets the Forecast Number

                            MessageBox.Show("PoQty > Qty_2");
                            v.Remainder = System.Math.Abs(v.Qty - v.Qty_2);

                            #region UPDATE
                            v.query = "UPDATE [pcs_db].[dbo].[ADQ_ForeCast] SET Qty_2 = '0' WHERE InHouseNo = '" + cmbInHouseNo.Text + "' " +
                                      "AND DateCreated = '" + v.DateCreated + "'    ";
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

                            #endregion

                            fl.RecordForecast(txtPPONo.Text, v.FCNo, v.Qty_2);

                            while (v.Remainder != 0)
                            {
                                MessageBox.Show(v.Remainder.ToString());
                                //v.Remainder = fl.WhileRemainder(cmbInHouseNo.Text, v.Qty, v.Remainder, v.DateCreated);
                                if (v.Remainder < v.Qty_2) //if remaining POQty is less than Qty2 || 3500 < 1500
                                {
                                    v.Qty_2 = fl.FindAForecast_GetQty2(cmbInHouseNo.Text); //Gets the data needed           
                                    v.DateCreated = fl.FindAForecast_GetDateCreated(cmbInHouseNo.Text); //Gets the data needed
                                    v.FCNo = fl.FindAForecast_GetFCNo(cmbInHouseNo.Text); //Gets the Forecast Number

                                    MessageBox.Show("v.Remainder < Qty_2");

                                    v.TQty = v.Qty_2 - v.Remainder;

                                    MessageBox.Show(v.TQty.ToString());

                                    #region UPDATE
                                    v.query = "UPDATE [pcs_db].[dbo].[ADQ_ForeCast] SET Qty_2 = '" + v.TQty + "' WHERE InHouseNo = '" + cmbInHouseNo.Text + "' " +
                                              "AND DateCreated = '" + v.DateCreated + "'    ";
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

                                    #endregion

                                    fl.RecordForecast(txtPPONo.Text, v.FCNo, v.Remainder);

                                    v.Remainder = 0;
                                }
                                else if (v.Remainder > v.Qty_2)
                                {
                                    MessageBox.Show("v.Remainder > Qty_2");
                                    MessageBox.Show(v.Remainder.ToString());

                                    v.Qty_2 = fl.FindAForecast_GetQty2(cmbInHouseNo.Text); //Gets the data needed           
                                    v.DateCreated = fl.FindAForecast_GetDateCreated(cmbInHouseNo.Text); //Gets the data needed
                                    v.FCNo = fl.FindAForecast_GetFCNo(cmbInHouseNo.Text); //Gets the Forecast Number

                                    v.Remainder = System.Math.Abs(v.Remainder - v.Qty_2);

                                    #region UPDATE
                                    v.query = "UPDATE [pcs_db].[dbo].[ADQ_ForeCast] SET Qty_2 = '0' WHERE InHouseNo = '" + cmbInHouseNo.Text + "' " +
                                              "AND DateCreated = '" + v.DateCreated + "'    ";
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

                                    #endregion

                                    fl.RecordForecast(txtPPONo.Text, v.FCNo, v.Qty_2);
                                }
                                else
                                {
                                    v.TQty = 0;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("There's something wrong");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No Forecast for InHouse No: " + cmbInHouseNo.Text);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }          
        }

        
        
        #endregion

        #region COMBOBOX       

        //DISPLAY ITEM INFO BY PART NO   
        private void cmbPartNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectByPartNo();
            
        }
        
        //DISPLAY ITEM INFO BY IN-HOUSE NO
        private void cmbInHouseNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectByInHouseNo();            
        }

        private void cmbInHouseNo_TextChanged(object sender, EventArgs e)
        {
            v.query = "SELECT * FROM [pcs_db].[dbo].[DLR_Parts] WHERE InHouseNo = '" + cmbInHouseNo.Text + "'  ";
            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                if (v.reader.HasRows)
                {
                    while (v.reader.Read())
                    {
                        v.PartName = v.reader.GetString(v.reader.GetOrdinal("PartName"));
                        txtPartName.Text = v.PartName;

                        v.Revision = v.reader.GetString(v.reader.GetOrdinal("Rev"));
                        //txtPartName.Text = v.PartName;

                        v.UOM = v.reader.GetString(v.reader.GetOrdinal("UOM"));
                        txtUOM.Text = v.UOM;

                        v.Currency = v.reader.GetString(v.reader.GetOrdinal("CurrencySell"));
                        txtCurrency.Text = v.Currency;

                        v.UnitPrice = v.reader.GetDouble(v.reader.GetOrdinal("UnitPriceSell"));
                        txtUnitPrice.Text = v.UnitPrice.ToString();

                        v.CustID = v.reader.GetString(v.reader.GetOrdinal("CustomerID"));
                        SearchCustName();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        #endregion

        #region BUTTON

        private void btnNewPO_Click(object sender, EventArgs e)
        {
            AutoID();
            cmbPartNo.Text = "";
            cmbInHouseNo.Text = "";
            txtPartName.Text = "";
            txtCustName.Text = "";
            dtpReceivedDate.Value = DateTime.Now;
            dtpOrderDate.Value = DateTime.Now;
            dtpReqDate.Value = DateTime.Now;
            txtPOQty.Text = "";
            txtUOM.Text = "";
            txtUnitPrice.Text = "";
            txtAmount.Text = "";
            txtCurrency.Text = "";
            txtPODetailNo.Text = "";
            txtPaperPONo.Text = "";
            txtRemarks.Text = "";
          
            //
            //dgOrderList.Rows.Clear();
        }

        private void Add_PO()
        {
            v.query = "INSERT INTO [pcs_db].[dbo].[ADQ_Orders](PPONo, PaperPONo, PODetailNo, InHouseNo, PartNo, PartName, Rev, CustNickName, PODate, OrderDate, ReqDate, POQty, UOM, " +
                    "ItemUnitPrice, POTotalAmount, Currency, Remarks, CreatedBy_ID, CreatedDate, POStatus, POBalance,POBalance1) " +
                                  "VALUES('" + txtPPONo.Text + "', '" + txtPaperPONo.Text + "' , '" + txtPODetailNo.Text + "', " +
                                  "'" + cmbInHouseNo.Text + "', '" + cmbPartNo.Text + "', " +
                                  "'" + txtPartName.Text + "', " +
                                  "'" + v.Revision + "', " +
                                  "'" + txtCustName.Text + "', " +
                                  "'" + dtpReceivedDate.Value + "', " +
                                  "'" + dtpOrderDate.Value + "'," +
                                  "'" + dtpReqDate.Value + "'," +
                                  "'" + Convert.ToInt32(txtPOQty.Text) + "'," +
                                  "'" + txtUOM.Text + "'," +
                                  "'" + Convert.ToDecimal(txtUnitPrice.Text) + "'," +
                                  "'" + Convert.ToDecimal(txtAmount.Text) + "'," +
                                  "'" + txtCurrency.Text + "'," +
                                  "'" + txtRemarks.Text + "'," +
                                  "'" + lblID.Text + "'," +
                                  "'" + DateTime.Now + "', " +
                                  "'ONGOING', '" + Convert.ToInt32(txtPOQty.Text) + "'," +
                                  "'" + Convert.ToInt32(txtPOQty.Text) + "' )";
            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                while (v.reader.Read())
                {

                }
                Save_Confirmation.Show("P.O is saved!", "Successfully Added");
            }
            catch 
            {
                Warning.Show("YOU CAN'T ADD DUPLICATE P.O DETAILS!!", "P.O Error");
            }
            //DisplayOrderList();
        }

        private void btnAddPO_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cmbPartNo.Text) || (string.IsNullOrWhiteSpace(cmbInHouseNo.Text) || (string.IsNullOrWhiteSpace(txtPartName.Text) || string.IsNullOrWhiteSpace(txtCustName.Text) || string.IsNullOrWhiteSpace(txtPOQty.Text) || string.IsNullOrWhiteSpace(txtUOM.Text) || string.IsNullOrWhiteSpace(txtUnitPrice.Text) || string.IsNullOrWhiteSpace(txtAmount.Text) || string.IsNullOrWhiteSpace(txtCurrency.Text) || string.IsNullOrWhiteSpace(txtPODetailNo.Text) || string.IsNullOrWhiteSpace(txtPaperPONo.Text))))
                {
                    Warning.Show("Please fill all the fields so you can proceed on saving the P.O", "P.O Error");
                }
                else if (txtPOQty.Text == "0")
                {
                    Warning.Show("The P.O Qty Cannot be 0!", "P.O Error");
                }
                else
                {
                    Add_PO(); // 
                              //Forecast(); // Looks for ForeCast Items after saving the P.O                               
                }
            }
            catch {}
        }
                
        #endregion

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

        private void txtPOQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            pdt.TextInput_KeyPress(sender, e);
        }

        private void txtPaperPONo_KeyPress(object sender, KeyPressEventArgs e)
        {
            pdt.TextNumInput_KeyPress(sender,e);
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            pdt.TextInput_KeyPress(sender, e);
        }

        private void txtPOQty_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtPOQty, "HIT THE ENTER KEY TO CALCULATE THE TOTAL AMOUNT");
        }
    }
}
