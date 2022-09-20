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
using System.IO;
using ExcelDataReader;
using System.Configuration;
using Dapper;
using OrderControlMgmt.Class;
using System.Data.OleDb;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using OrderControlMgmt.Forms;

namespace OrderControlMgmt
{
    public partial class frmPOList : Form
    {
        Variables v = new Variables();
        ImportPO_FDTP pO_FDTP = new ImportPO_FDTP();
        ImportPO_GLORY pO_GLORY = new ImportPO_GLORY();
        ImportPO_KOUSHIN pO_KOUSHIN = new ImportPO_KOUSHIN();
        

        public frmPOList()
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
            v.query = "SELECT * FROM [pcs_db].[dbo].[YGA_Parts]  ";
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
            v.query = "SELECT * FROM [pcs_db].[dbo].[YGA_Parts]  ";
            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                while (v.reader.Read())
                {
                    v.InHouseNo = v.reader.GetString(v.reader.GetOrdinal("PartNo"));
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
            v.query = "SELECT * FROM [pcs_db].[dbo].[YGA_Customers]  ";
            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                while (v.reader.Read())
                {
                    v.CustNickName = v.reader.GetString(v.reader.GetOrdinal("Abbreviation"));
                    cmbCustName.Items.Add(v.CustNickName);
                    cmbCustName2.Items.Add(v.CustNickName);
                    //orderCtrl.metroComboBox1.Items.Add(v.ProductNo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SelectByInHouseNo()
        {
            v.query = "SELECT * FROM [pcs_db].[dbo].[YGA_Parts] WHERE PartNo = '" + cmbInHouseNo.Text + "'  ";
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
            v.query = "SELECT * FROM [pcs_db].[dbo].[YGA_Parts] WHERE CustomerPartNo = '" + cmbPartNo.Text + "'  ";
            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                while (v.reader.Read())
                {               

                    v.InHouseNo = v.reader.GetString(v.reader.GetOrdinal("PartNo"));
                    cmbInHouseNo.Text = v.InHouseNo;                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DisplayOrderList()
        {
            //using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            //{
            //    if (db.State == ConnectionState.Closed)
            //        db.Open();
            //    string query = "SELECT * FROM [pcs_db].[dbo].[ADQ_Orders] where PONo = '" + txtPPONo.Text + "'";
            //    pODetailsBindingSource.DataSource = db.Query<PODetails>(query, commandType: CommandType.Text);
            //}
        }

        //
        private void Import_FDTP()
        {
            using (OpenFileDialog of = new OpenFileDialog() { Filter = "Excel File|*.xls;*.xlsx;*.xlsm", ValidateNames = true })
            {
                if (of.ShowDialog() == DialogResult.OK)
                {

                    TextBoxPath.Text = of.FileName;

                    pO_FDTP.dgOrderList.Rows.Clear();
                    string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + TextBoxPath.Text + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                    OleDbConnection Con = new OleDbConnection(constr);
                    OleDbCommand OleConnection = new OleDbCommand("SELECT * FROM [Sheet1$A2:R1000]", Con);
                    Con.Open();

                    OleDbDataAdapter sda = new OleDbDataAdapter(OleConnection);
                    System.Data.DataTable data = new System.Data.DataTable();
                    sda.Fill(data);
                    pO_FDTP.dgOrderList.DataSource = data;

                    pO_FDTP.dgOrderList.ReadOnly = true;
                    //pO_FDTP.dgOrderList.Columns[0].Width = 320;
                    pO_FDTP.dgOrderList.ClearSelection();
                }
            }
            pnlContent1.Controls.Clear();
            //rf.lblUName.Text = lblUName.Text;
            pO_FDTP.TopLevel = false;
            //rf.TopMost = true;
            pO_FDTP.FormBorderStyle = FormBorderStyle.None;
            //rf.WindowState = FormWindowState.Maximized;
            pnlContent1.Controls.Add(pO_FDTP);
            pO_FDTP.Dock = DockStyle.Fill;
            pO_FDTP.Show();
            pO_FDTP.BringToFront();
            pO_FDTP.lblCustName.Text = cmbCustName2.Text;
            pO_FDTP.dtpDate.Value = dtpReceivedDate2.Value;
        }

        private void Import_GLORY()
        {
            using (OpenFileDialog of = new OpenFileDialog() { Filter = "Excel File|*.xls;*.xlsx;*.xlsm", ValidateNames = true })
            {
                if (of.ShowDialog() == DialogResult.OK)
                {

                    TextBoxPath.Text = of.FileName;

                    pO_GLORY.dgOrderList.Rows.Clear();
                    string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + TextBoxPath.Text + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                    OleDbConnection Con = new OleDbConnection(constr);
                    OleDbCommand OleConnection = new OleDbCommand("SELECT * FROM [Sheet1$A1:L1000]", Con);
                    Con.Open();

                    OleDbDataAdapter sda = new OleDbDataAdapter(OleConnection);
                    System.Data.DataTable data = new System.Data.DataTable();
                    sda.Fill(data);
                    pO_GLORY.dgOrderList.DataSource = data;

                    pO_GLORY.dgOrderList.ReadOnly = true;
                    //pO_GLORY.dgOrderList.Columns[0].Width = 320;
                    pO_GLORY.dgOrderList.ClearSelection();
                }
            }
            pnlContent1.Controls.Clear();
            //rf.lblUName.Text = lblUName.Text;
            pO_GLORY.TopLevel = false;
            //rf.TopMost = true;
            pO_GLORY.FormBorderStyle = FormBorderStyle.None;
            //rf.WindowState = FormWindowState.Maximized;
            pnlContent1.Controls.Add(pO_GLORY);
            pO_GLORY.Dock = DockStyle.Fill;
            pO_GLORY.Show();
            pO_GLORY.BringToFront();
            pO_GLORY.lblCustName.Text = cmbCustName2.Text;
            pO_GLORY.dtpDate.Value = dtpReceivedDate2.Value;
        }

        private void Import_KOUSHIN()
        {
            using (OpenFileDialog of = new OpenFileDialog() { Filter = "Excel File|*.xls;*.xlsx;*.xlsm", ValidateNames = true })
            {
                if (of.ShowDialog() == DialogResult.OK)
                {

                    TextBoxPath.Text = of.FileName;

                    pO_KOUSHIN.dgOrderList.Rows.Clear();
                    string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + TextBoxPath.Text + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                    OleDbConnection Con = new OleDbConnection(constr);
                    OleDbCommand OleConnection = new OleDbCommand("SELECT * FROM [POList$A8:S1000]", Con);
                    Con.Open();

                    OleDbDataAdapter sda = new OleDbDataAdapter(OleConnection);
                    System.Data.DataTable data = new System.Data.DataTable();
                    sda.Fill(data);
                    pO_KOUSHIN.dgOrderList.DataSource = data;

                    pO_KOUSHIN.dgOrderList.ReadOnly = true;
                    //pO_KOUSHIN.dgOrderList.Columns[0].Width = 320;
                    pO_KOUSHIN.dgOrderList.ClearSelection();
                }
            }
            pnlContent1.Controls.Clear();
            //rf.lblUName.Text = lblUName.Text;
            pO_KOUSHIN.TopLevel = false;
            //rf.TopMost = true;
            pO_KOUSHIN.FormBorderStyle = FormBorderStyle.None;
            //rf.WindowState = FormWindowState.Maximized;
            pnlContent1.Controls.Add(pO_KOUSHIN);
            pO_KOUSHIN.Dock = DockStyle.Fill;
            pO_KOUSHIN.Show();
            pO_KOUSHIN.BringToFront();
            pO_KOUSHIN.lblCustName.Text = cmbCustName2.Text;
            pO_KOUSHIN.dtpDate.Value = dtpReceivedDate2.Value;
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
            v.query = "SELECT * FROM [pcs_db].[dbo].[YGA_Parts] WHERE PartNo = '" + cmbInHouseNo.Text + "'  ";
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

                        v.CustNickName = v.reader.GetString(v.reader.GetOrdinal("CustomerCD"));
                        cmbCustName.Text = v.CustNickName;

                        v.UnitPrice = v.reader.GetString(v.reader.GetOrdinal("UnitPriceSell"));
                        txtUnitPrice.Text = v.UnitPrice.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmbCustName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustName2.Text == "FDTP")
            {
                btnChooseFile.Enabled = true;
                TextBoxPath.Enabled = true;
            }
            else if (cmbCustName2.Text == "GPI")
            {
                btnChooseFile.Enabled = true;
                TextBoxPath.Enabled = true;
            }
            else if (cmbCustName2.Text == "KMP")
            {
                btnChooseFile.Enabled = true;
                TextBoxPath.Enabled = true;
            }
            else { }
        }

        #endregion

        #region BUTTON

        private void btnNewPO_Click(object sender, EventArgs e)
        {
            AutoID();
            cmbPartNo.Text = "";
            cmbInHouseNo.Text = "";
            txtPartName.Text = "";
            cmbCustName.Text = "";
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
            cmbCustName2.Text = "";
            dtpReceivedDate2.Value = DateTime.Now;
            TextBoxPath.Text = "";
            cmbSheetName.Text = "";
            cmbSheetName.Items.Clear();

            //
            //dgOrderList.Rows.Clear();

        }

        private void btnAddPO_Click(object sender, EventArgs e)
        {
            v.query = "INSERT INTO [pcs_db].[dbo].[ADQ_Orders](PPONo, PaperPONo, PODetailNo, InHouseNo, PartNo, PartName, Rev, CustNickName, PODate, OrderDate, ReqDate, POQty, UOM, " +
                    "ItemUnitPrice, POTotalAmount, Currency, Remarks) " +
                                  "VALUES('" + txtPPONo.Text + "', '" + txtPaperPONo.Text + "' , '" + txtPODetailNo.Text + "', " +
                                  "'" + cmbInHouseNo.Text + "', '" + cmbPartNo.Text + "', " +
                                  "'" + txtPartName.Text + "', " +
                                  "'" + v.Revision + "', " +
                                  "'" + cmbCustName.Text + "', " +
                                  "'" + dtpReceivedDate.Value + "', " +
                                  "'" + dtpOrderDate.Value + "'," +
                                  "'" + dtpReqDate.Value + "'," +
                                  "'" + Convert.ToInt32(txtPOQty.Text) + "'," +
                                  "'" + txtUOM.Text + "'," +
                                  "'" + Convert.ToDecimal(txtUnitPrice.Text) + "'," +
                                  "'" + Convert.ToDecimal(txtAmount.Text) + "'," +
                                  "'" + txtCurrency.Text + "'," +                                  
                                  "'" + txtRemarks.Text + "' )";
            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                while (v.reader.Read())
                {

                }
                MessageBox.Show("Okay!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            DisplayOrderList();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            if (cmbCustName2.Text == "FDTP")
            {
                Import_FDTP();
            }
            else if (cmbCustName2.Text == "GPI")
            {
                Import_GLORY();
            }
            else if (cmbCustName2.Text == "KMP")
            {
                Import_KOUSHIN();
            }
            else { }
        }
               

        #endregion

        private void dgOrderList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //dgOrderList.Rows[e.RowIndex].Cells[2].Value = (e.RowIndex + 1).ToString();
        }

        private void txtPOQty_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {                
                v.Amount = Convert.ToDecimal(txtPOQty.Text) * Convert.ToDecimal(txtUnitPrice.Text);
                txtAmount.Text = v.Amount.ToString("N4");                    
            }
        }        

       
    }
}
