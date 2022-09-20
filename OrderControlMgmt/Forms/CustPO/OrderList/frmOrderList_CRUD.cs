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
using OrderControlMgmt.Forms.CustPO.OrderList;
using CustomMessageBox;

namespace OrderControlMgmt
{
    public partial class frmOrderList_CRUD : Form
    {
        Variables v = new Variables();
        frmOrderList_CRUDdetails poCrudDetails = new frmOrderList_CRUDdetails();
        frmDeleteBatchPO delBPO = new frmDeleteBatchPO();
        string filter = "";
        public static string ID;
        DataTable dtgetSelected = new DataTable();
        int counter = 0;

        public frmOrderList_CRUD()
        {
            InitializeComponent();

            GetPartNo();
            GetInHouseNo();
            GetCustomerName();
            DtAddCol();
        }

        #region METHODS

        public void GetPartNo()
        {
            //v.query = "SELECT * FROM [pcs_db].[dbo].[DLR_Parts] WHERE PartStatus != 'Deleted' ";
            //try
            //{
            //    v.conn = new SqlConnection(v.connString);
            //    v.conn.Open();
            //    v.sqlCommand = new SqlCommand(v.query, v.conn);
            //    v.reader = v.sqlCommand.ExecuteReader();
            //    while (v.reader.Read())
            //    {
            //        v.PartNo = v.reader.GetString(v.reader.GetOrdinal("CustomerPartNo"));
            //        cmbPartNo.Items.Add(v.PartNo);
            //        //orderCtrl.metroComboBox1.Items.Add(v.ProductNo);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
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
                    cmbCustName.Items.Add(v.CustNickName);
                    //cmbCustName2.Items.Add(v.CustNickName);
                    //orderCtrl.metroComboBox1.Items.Add(v.ProductNo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void DisplayPOList()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                string query = "SELECT * FROM [pcs_db].[dbo].[ADQ_Orders] WHERE POStatus != 'FINISHED' AND POStatus != 'CANCELLED' ORDER BY PPONo ASC"; //WHERE POStatus != 'CANCELLED'   WHERE POStatus IS NULL
                //string query = "SELECT dbo.MOM_PartsLogRecord.Date AS LastInspectionDate, dbo.ADQ_Orders.* FROM dbo.ADQ_Orders" +
                //    "INNER JOIN dbo.MOM_PartsLogRecord ON dbo.ADQ_Orders.InHouseNo = dbo.MOM_PartsLogRecord.InHouseNo" +
                //    "WHERE dbo.ADQ_Orders.POStatus != 'FINISHED' AND dbo.ADQ_Orders.POStatus != 'CANCELLED' ORDER BY PPONo ASC"; //WHERE POStatus != 'CANCELLED'   WHERE POStatus IS NULL
                pODetailsBindingSource.DataSource = db.Query<PODetails>(query, commandType: CommandType.Text);
            }

            int i = 0;
            foreach (DataGridViewRow row in dgOrderList.Rows)
            {
                row.Cells["noDataGridViewTextBoxColumn"].Value = i+1;
                i++;
            }            
        }       

        private void POforReInspection()
        {
            //using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            //{
            //    if (db.State == ConnectionState.Closed)
            //        db.Open();
            //    string query = "SELECT * FROM [pcs_db].[dbo].[viewPOListForReInspection] WHERE Date2 >= 1 AND POStatus != 'FINISHED' AND POStatus != 'CANCELLED' ORDER BY PPONo ASC"; //WHERE POStatus != 'CANCELLED'   WHERE POStatus IS NULL
            //    //string query = "SELECT dbo.MOM_PartsLogRecord.Date AS LastInspectionDate, dbo.ADQ_Orders.* FROM dbo.ADQ_Orders" +
            //    //    "INNER JOIN dbo.MOM_PartsLogRecord ON dbo.ADQ_Orders.InHouseNo = dbo.MOM_PartsLogRecord.InHouseNo" +
            //    //    "WHERE dbo.ADQ_Orders.POStatus != 'FINISHED' AND dbo.ADQ_Orders.POStatus != 'CANCELLED' ORDER BY PPONo ASC"; //WHERE POStatus != 'CANCELLED'   WHERE POStatus IS NULL
            //    pODetailsBindingSource1.DataSource = db.Query<PODetails>(query, commandType: CommandType.Text);
            //}

            //int i = 0;
            //foreach (DataGridViewRow row in dgPOReInspect.Rows)
            //{
            //    row.Cells["dataGridViewTextBoxColumn1"].Value = i + 1;
            //    i++;
            //}
        }
               
        private void Search()
        {
            try
            {
                // Check if text fields are not null before adding to filter.              
                if (!string.IsNullOrEmpty(cmbInHouseNo.Text)) //InHouseNo
                {
                    if (filter.Length > 0) filter += "AND ";
                    //filter += dgOrderList.Columns["inHouseNoDataGridViewTextBoxColumn"].HeaderText.ToString() + " = '" + cmbInHouseNo.Text + "' ";
                    filter += "InHouseNo = '" + cmbInHouseNo.Text + "' ";
                }
                else
                {
                    filter += "";
                }

                if (!string.IsNullOrEmpty(cmbCustName.Text)) //CustName
                {
                    if (filter.Length > 0) filter += "AND ";
                    filter += "CustNickName = '" + cmbCustName.Text + "' ";
                }
                else
                {
                    filter += "";
                }

                if (!string.IsNullOrEmpty(cmbPOStatus.Text)) //POStatus
                {
                    if (filter.Length > 0) filter += "AND ";
                    filter += "POStatus = '" + cmbPOStatus.Text + "' ";
                }
                else
                {
                    filter += "";
                }

                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    string query = "SELECT * FROM [pcs_db].[dbo].[ADQ_Orders] WHERE " + filter + " AND OrderDate = '" + dtpReceivedDate.Value + "' ORDER BY PPONo ASC ";
                    pODetailsBindingSource.DataSource = db.Query<PODetails>(query, commandType: CommandType.Text);
                    db.Close();
                }

                int i = 0;
                foreach (DataGridViewRow row in dgOrderList.Rows)
                {
                    row.Cells["noDataGridViewTextBoxColumn"].Value = i + 1;
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void EnaCanBtn()
        {
            counter = 0;
            for (int i = 0; i < dgOrderList.Rows.Count; i++)
            {
                try
                {
                    if (Convert.ToBoolean(dgOrderList.Rows[i].Cells["chk"].Value) == true)
                    {
                        counter++;
                    }
                }
                catch
                { }
            }

            if (counter > 1)
            {
                btnBCancelPO.Visible = true;
            }
            else
            {
                btnBCancelPO.Visible = false;
            }
        }

        public void DtAddCol()
        {
            dtgetSelected.Columns.Add("SytemPONo",typeof(string));
            dtgetSelected.Columns.Add("PONo",typeof(string));
            dtgetSelected.Columns.Add("PODetailNo",typeof(string));
            dtgetSelected.Columns.Add("InHouseNo",typeof(string));
            dtgetSelected.Columns.Add("PartNo",typeof(string));
            dtgetSelected.Columns.Add("PartName",typeof(string));
            dtgetSelected.Columns.Add("Rev",typeof(string));
            dtgetSelected.Columns.Add("DateImport",typeof(string));
            dtgetSelected.Columns.Add("OrederDate",typeof(string));
            dtgetSelected.Columns.Add("ReqDate",typeof(string));
            dtgetSelected.Columns.Add("POQty",typeof(string));
            dtgetSelected.Columns.Add("ItemUnitPrice",typeof(string));
            dtgetSelected.Columns.Add("POTotalAmount",typeof(string));
            dtgetSelected.Columns.Add("Currency",typeof(string));
        }

        #endregion

        #region FILTER


        #region COMBOBOX

        private void cmbInHouseNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter = "";            
            Search();           
        }

        private void cmbCustName_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter = "";            
            Search();            
        }

        private void cmbPOStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter = "";            
            Search();                      
        }

        #endregion

        private void dtpReceivedDate_ValueChanged(object sender, EventArgs e)
        {
            filter = "";
            if (!string.IsNullOrEmpty(cmbInHouseNo.Text)) //InHouseNo
            {
                if (filter.Length > 0) filter += "AND ";               
                filter += "InHouseNo = '" + cmbInHouseNo.Text + "' ";
            }
            else
            {
                filter += "";
            }

            if (!string.IsNullOrEmpty(cmbCustName.Text)) //CustName
            {
                if (filter.Length > 0) filter += "AND ";
                filter += "CustNickName = '" + cmbCustName.Text + "' ";
            }
            else
            {
                filter += "";
            }

            if (!string.IsNullOrEmpty(cmbPOStatus.Text)) //POStatus
            {
                if (filter.Length > 0) filter += "AND ";
                filter += "POStatus = '" + cmbPOStatus.Text + "' ";
            }
            else
            {
                filter += "";
            }

            if (filter.Length > 0) filter += "AND ";
           
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                string query = "SELECT * FROM [pcs_db].[dbo].[ADQ_Orders] WHERE " + filter + " OrderDate = '" + dtpReceivedDate.Value + "' ORDER BY PPONo ASC";
                pODetailsBindingSource.DataSource = db.Query<PODetails>(query, commandType: CommandType.Text);
            }
            
            int i = 0;
            foreach (DataGridViewRow row in dgOrderList.Rows)
            {
                row.Cells["noDataGridViewTextBoxColumn"].Value = i + 1;
                i++;
            }
        }

        #endregion

        #region TEXTCHANGED

        private void cmbInHouseNo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbInHouseNo.Text))
            {
                DisplayPOList();
            }            
        }

        private void cmbCustName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbCustName.Text))
            {
                DisplayPOList();
            }
        }

        private void cmbPOStatus_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbPOStatus.Text))
            {
                DisplayPOList();
            }
        }


        #endregion


        private void frmOrderList_CRUD_Load(object sender, EventArgs e)
        {
            DisplayPOList();
            POforReInspection();
        }

        private void dgOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgOrderList.Columns[e.ColumnIndex].Name != "chk")
            {
                if (ID.Trim() == "R0108")
                {
                    if (e.RowIndex >= 0)
                    {
                        DataGridViewRow data = this.dgOrderList.Rows[e.RowIndex];

                        v.PPONo = data.Cells["pPONoDataGridViewTextBoxColumn"].Value.ToString();
                        poCrudDetails.txtPPONo.Text = v.PPONo;

                        poCrudDetails.ShowDialog();

                        DisplayPOList();
                        POforReInspection();
                    }


                }
                else
                {
                    Warning.Show("YOU ARE NOT AUTHORIZED TO CANCEL A P.O!", "WARNING");

                }
            }
        }

        private void dgOrderList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgOrderList.Columns[e.ColumnIndex].Name == "chk")
            {
                try
                {
                    if (Convert.ToBoolean(dgOrderList.SelectedRows[0].Cells["chk"].Value) == true)
                    {
                        dgOrderList.SelectedRows[0].Cells["chk"].Value = false;
                    }
                    else
                    {
                        dgOrderList.SelectedRows[0].Cells["chk"].Value = true;
                    }
                }
                catch
                {
                    dgOrderList.SelectedRows[0].Cells["chk"].Value = true;
                }
            }
            EnaCanBtn();
        }

        private void btnCancelPO_Click(object sender, EventArgs e)
        {
              frmItemsForReInspection reIns = new frmItemsForReInspection();
              reIns.ShowDialog();
        }

        private void chkBCanPo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBCanPo.Checked == true)
            {
                for (int i = 0; i < dgOrderList.Rows.Count; i++)
                {
                    dgOrderList.Rows[i].Cells["chk"].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < dgOrderList.Rows.Count; i++)
                {
                    dgOrderList.Rows[i].Cells["chk"].Value = false;
                }
            }
            EnaCanBtn();
        }

        private void btnBCancelPO_Click(object sender, EventArgs e)
        {
            if (ID.Trim() == "R0108")
            {
                dtgetSelected.Rows.Clear();
                for (int i = 0; i < dgOrderList.Rows.Count; i++)
                {
                    try
                    {
                        if (Convert.ToBoolean(dgOrderList.Rows[i].Cells["chk"].Value) == true)
                        {
                            dtgetSelected.Rows.Add(dgOrderList.Rows[i].Cells["pPONoDataGridViewTextBoxColumn"].Value.ToString(),
                                dgOrderList.Rows[i].Cells["paperPONoDataGridViewTextBoxColumn"].Value.ToString(),
                                dgOrderList.Rows[i].Cells["pODetailNoDataGridViewTextBoxColumn"].Value.ToString(),
                                dgOrderList.Rows[i].Cells["inHouseNoDataGridViewTextBoxColumn"].Value.ToString(),
                                dgOrderList.Rows[i].Cells["partNoDataGridViewTextBoxColumn"].Value.ToString(),
                                dgOrderList.Rows[i].Cells["partNameDataGridViewTextBoxColumn"].Value.ToString(),
                                dgOrderList.Rows[i].Cells["revDataGridViewTextBoxColumn"].Value.ToString(),
                                dgOrderList.Rows[i].Cells["pODateDataGridViewTextBoxColumn"].Value.ToString(),
                                dgOrderList.Rows[i].Cells["orderDateDataGridViewTextBoxColumn"].Value.ToString(),
                                dgOrderList.Rows[i].Cells["reqDateDataGridViewTextBoxColumn"].Value.ToString(),
                                dgOrderList.Rows[i].Cells["pOQtyDataGridViewTextBoxColumn"].Value.ToString(),
                                dgOrderList.Rows[i].Cells["itemUnitPriceDataGridViewTextBoxColumn"].Value.ToString(),
                                dgOrderList.Rows[i].Cells["pOTotalAmountDataGridViewTextBoxColumn"].Value.ToString(),
                                dgOrderList.Rows[i].Cells["currencyDataGridViewTextBoxColumn"].Value.ToString());
                        }
                    }
                    catch
                    { }
                }
                delBPO.dgOrderList.DataSource = dtgetSelected;
                delBPO.ShowDialog();
            }
            else
            {
                Warning.Show("YOU ARE NOT AUTHORIZED TO CANCEL A P.O!", "WARNING");
            }
        }
    }
}
//if (string.IsNullOrWhiteSpace(txtPPONo.Text))
//            {
//                DisplayPOList();
//    }
//            else
//            {

//            }

//int i = 0;
//            foreach (DataGridViewRow row in dgOrderList.Rows)
//            {
//                row.Cells["noDataGridViewTextBoxColumn"].Value = i + 1;
//                i++;
//            } 