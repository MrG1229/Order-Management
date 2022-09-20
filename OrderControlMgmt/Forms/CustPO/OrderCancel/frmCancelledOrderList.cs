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

namespace OrderControlMgmt
{
    public partial class frmCancelledOrderList : Form
    {
        Variables v = new Variables();
        frmCancelledOrderList_CRUDdetails cancelPOCrudDetails = new frmCancelledOrderList_CRUDdetails();
        string filter = "";
        public static string ID;

        public frmCancelledOrderList()
        {
            InitializeComponent();

           
            GetInHouseNo();
            GetCustomerName();
        }

        #region METHODS       

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
                string query = "SELECT * FROM [pcs_db].[dbo].[viewCancelledPO] ORDER BY PPONo ASC"; //WHERE POStatus != 'CANCELLED'
                pODetailsBindingSource.DataSource = db.Query<PODetails>(query, commandType: CommandType.Text);
            }
            
            int i = 0;
            foreach (DataGridViewRow row in dgOrderList.Rows)
            {
                row.Cells["noDataGridViewTextBoxColumn"].Value = i+1;
                i++;
            }

            
        }

        private void Search()
        {
            try
            {
                // Check if text fields are not null before adding to filter.              
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
              

                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    string query = "SELECT * FROM [pcs_db].[dbo].[viewCancelledPO] WHERE " + filter + " AND OrderDate = '" + dtpReceivedDate.Value + "' ORDER BY PPONo ASC ";
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

            if (filter.Length > 0) filter += "AND ";

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                string query = "SELECT * FROM [pcs_db].[dbo].[viewCancelledPO] WHERE " + filter + " OrderDate = '" + dtpReceivedDate.Value + "' ORDER BY PPONo ASC";
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

        private void frmOrderList_CRUD_Load(object sender, EventArgs e)
        {
            DisplayPOList();
        }       

        private void dgOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ID.Trim() == "R0108")
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow data = this.dgOrderList.Rows[e.RowIndex];

                    v.PPONo = data.Cells["pPONoDataGridViewTextBoxColumn"].Value.ToString();
                    cancelPOCrudDetails.txtPPONo.Text = v.PPONo;

                    cancelPOCrudDetails.ShowDialog();

                    DisplayPOList();
                }
            }
            else
            {
                Warning.Show("YOU ARE NOT AUTHORIZED TO RESTSTORE A P.O!!","WARNING");
            }
        }

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

        #endregion
    }
}
//if (string.IsNullOrWhiteSpace(txtPPONo.Text))
//            {
//                DisplayPOList();
//    }
//            else
//            {

//            }
