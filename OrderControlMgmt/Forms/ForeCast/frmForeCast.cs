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
using UserAccessControl;

namespace OrderControlMgmt
{
    public partial class frmForeCast : Form
    {
        Variables v = new Variables();
        ImportPO_FDTP pO_FDTP = new ImportPO_FDTP();
        ImportPO_GLORY pO_GLORY = new ImportPO_GLORY();
        ImportPO_KOUSHIN pO_KOUSHIN = new ImportPO_KOUSHIN();
        PublicDataTransporter pdt = new PublicDataTransporter();
        
        public frmForeCast()
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
            v.sqlCommand = new SqlCommand("pcs_db.dbo.FCNO_Code", v.conn);
            v.sqlCommand.CommandType = CommandType.StoredProcedure;
            object obj = v.sqlCommand.ExecuteScalar();
            txtFCNo.Text = obj.ToString();

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
            v.query = "SELECT * FROM [pcs_db].[dbo].[DLR_Customers_2]  ";
            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                while (v.reader.Read())
                {
                    v.CustNickName = v.reader.GetString(v.reader.GetOrdinal("Abbreviation"));                   
                    //orderCtrl.metroComboBox1.Items.Add(v.ProductNo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void GetCustomerNickName()
        {
            v.query = "SELECT * FROM [pcs_db].[dbo].[DLR_Customers_2] WHERE CustomerID = '" + v.CustID + "' ";
            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                while (v.reader.Read())
                {
                    v.CustNickName = v.reader.GetString(v.reader.GetOrdinal("Abbreviation"));
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

        private void DisplayOrderList()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                string query = "SELECT * FROM [pcs_db].[dbo].[ADQ_ForeCast] WHERE FCNo = '" + txtFCNo.Text + "'";
                forecastDetailsBindingSource.DataSource = db.Query<ForecastDetails>(query, commandType: CommandType.Text);
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
            //GetCustomerID();
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
                        v.CustID = v.reader.GetString(v.reader.GetOrdinal("CustomerID"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            GetCustomerNickName();
        }
       

        #endregion

        #region BUTTON

        private void btnNewPO_Click(object sender, EventArgs e)
        {
            AutoID();
            cmbPartNo.Text = null;
            cmbInHouseNo.Text = null;
            txtPartName.Text = "";           
            //dtpDateCreated.Value = DateTime.Now;
            //dtpDateRequired.Value = DateTime.Now;
            txtFCQty.Text = "";
            txtUOM.Text = "";           
            txtRemarks.Text = "";           

            //
            //dgOrderList.Rows.Clear();

        }

        private void btnAddPO_Click(object sender, EventArgs e)
        {
            #region OG FORECAST TBL
            if (cmbPartNo.Text == "" || cmbInHouseNo.Text == "" || txtFCQty.Text == "" || txtPartName.Text == "" || txtUOM.Text == "")
            { Warning.Show("Fill All the Fields First!", "Warning"); }
            else if (txtFCQty.Text == "0" || txtFCQty.Text == "")
            { Warning.Show("The Qty Cannot Be 0 or Empty!", "Warning"); }
            else
            {
                v.query = "INSERT INTO [pcs_db].[dbo].[ADQ_ForeCast](FCNo, InHouseNo, CustNickName, PartNo, PartName, Rev, Qty, Qty_2, UOM, Remarks, POStatus, CreatedBy_ID, CreatedDate, Date) " +
                                      "VALUES('" + txtFCNo.Text + "', " +
                                      "'" + cmbInHouseNo.Text + "', " +
                                      "'" + v.CustNickName + "', " +
                                      "'" + cmbPartNo.Text + "', " +
                                      "'" + txtPartName.Text + "', " +                                      
                                      "'" + v.Revision + "', " +
                                      "'" + Convert.ToInt32(txtFCQty.Text) + "'," +
                                      "'" + Convert.ToInt32(txtFCQty.Text) + "'," +
                                      "'" + txtUOM.Text + "'," +
                                      "'" + txtRemarks.Text + "'," +
                                      "'ACTIVE'," +
                                      "'" + lblID.Text + "'," +
                                      "'" + DateTime.Now + "'," +
                                      "'" +dtpDate.Value.ToShortDateString()+ "' )";
                try
                {
                    v.conn = new SqlConnection(v.connString);
                    v.conn.Open();
                    v.sqlCommand = new SqlCommand(v.query, v.conn);
                    v.reader = v.sqlCommand.ExecuteReader();
                    while (v.reader.Read())
                    {

                    }
                    Save_Confirmation.Show("Forecast Item is saved!", "Successfully Added");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                DisplayOrderList();
                #endregion

                #region COPY FORECAST TBL
                v.query = "INSERT INTO [pcs_db].[dbo].[MOM_ForeCastSubPO](FCNo, InHouseNo, Date, Qty, Remarks, CreatedBy_ID, CreatedDate) " +
                                      "VALUES('" + txtFCNo.Text + "'," +
                                      "'" + cmbInHouseNo.Text + "', " +
                                      "'" + DateTime.Now.ToShortDateString() + "'," +
                                      "'" + Convert.ToInt32(txtFCQty.Text) + "'," +
                                      "'" + txtRemarks.Text + "'," +
                                      "'" + lblID.Text + "'," +
                                      "'" + DateTime.Now + "' )";
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
            #endregion
        }

        #endregion

        private void txtFCQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            pdt.TextInput_KeyPress(sender, e);
        }

        private void frmForeCast_Load(object sender, EventArgs e)
        {

        }

        private void cmbInHouseNo_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
