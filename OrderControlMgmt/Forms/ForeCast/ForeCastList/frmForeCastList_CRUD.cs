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

namespace OrderControlMgmt
{
    public partial class frmForeCastList_CRUD : Form
    {
        Variables v = new Variables();
        frmForeCastList_CRUDdetails fcCrudDetails = new frmForeCastList_CRUDdetails();
        public string lblID;
        string filter = "";

        public frmForeCastList_CRUD()
        {
            InitializeComponent();

            GetCustomerName();
            GetInHouseNo();
            
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
                string query = "SELECT * FROM [pcs_db].[dbo].[ADQ_ForeCast] WHERE POStatus = 'ACTIVE' ORDER BY FCNo ASC"; //WHERE POStatus != 'CANCELLED'
                forecastDetailsBindingSource.DataSource = db.Query<ForecastDetails>(query, commandType: CommandType.Text);
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

                

                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    string query = "SELECT * FROM [pcs_db].[dbo].[ADQ_ForeCast] WHERE " + filter + " AND Date = '" + dtpDateCreated.Value + "' ORDER BY FCNo ASC ";
                    forecastDetailsBindingSource.DataSource = db.Query<ForecastDetails>(query, commandType: CommandType.Text);
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

        #region TEXTCHANGED

        private void cmbInHouseNo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbInHouseNo.Text))
            {
                DisplayPOList();
            }
            else
            {
                filter = "";
                Search();
            }
        }

        private void cmbCustName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbCustName.Text))
            {
                DisplayPOList();
            }
            else
            {
                filter = "";
                Search();
            }
        }


        #endregion

        private void dtpDateCreated_ValueChanged(object sender, EventArgs e)
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
                string query = "SELECT * FROM [pcs_db].[dbo].[ADQ_ForeCast] WHERE " + filter + " Date = '" + dtpDateCreated.Value + "' ORDER BY FCNo ASC ";
                forecastDetailsBindingSource.DataSource = db.Query<ForecastDetails>(query, commandType: CommandType.Text);
                db.Close();
            }

            int i = 0;
            foreach (DataGridViewRow row in dgOrderList.Rows)
            {
                row.Cells["noDataGridViewTextBoxColumn"].Value = i + 1;
                i++;
            }
        }

        #endregion

        #region DATAGRID

        private void dgOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow data = this.dgOrderList.Rows[e.RowIndex];

                v.FCNo = data.Cells["fCNoDataGridViewTextBoxColumn"].Value.ToString();
                fcCrudDetails.txtFCNo.Text = v.FCNo;

                fcCrudDetails.ShowDialog();


                DisplayPOList();
            }
        }

        private void dgOrderList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgOrderList.Rows.Count > 0)
            {
                for (int i = dgOrderList.Rows.Count - 1; i > 0; i--)
                {
                    if (Convert.ToInt32(dgOrderList.Rows[i].Cells["qtyDataGridViewTextBoxColumn"].Value.ToString()) <= 0)
                    {
                        dgOrderList.Rows.RemoveAt(i);
                    }
                }
            }
        }

        #endregion

        private void frmOrderList_CRUD_Load(object sender, EventArgs e)
        {
            DisplayPOList();
        }       
        
        private void btnNewFC_Click(object sender, EventArgs e)
        {
            //frmForeCast foreCast = new frmForeCast();
            //foreCast.lblID.Text = lblID;
            //foreCast.ShowDialog();

           // DisplayPOList();
        }

        private void forecastDetailsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

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